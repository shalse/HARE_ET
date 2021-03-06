using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ET_Project_GUI.Data;
using ET_Project_GUI.ET_Calibration;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using ET_Project_GUI.DB_Wrapper;
using ET_Project_GUI.DB_Interface;

namespace ET_Project_GUI
{
    public partial class MainForm : Form
    {
        //DLL for escape key
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        //DLL for mouseclick
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        //global variables
        private ETController ETDevice;
        private ETCalibrate calibrateET;
        private ETController.AccuracyStruct m_AccuracyData;
        private CustomScreenCapture screenVideo;
        private ETTrackingMonitor trackingMonitor;
        private bool updatePoints;
        private bool serverListenerEnabled;
        private bool recordData;
        private ETSampleManager dataPoints;
        private int dataSampleRate;
        bool mouseHijack = false;

        /// <summary>
        /// This is the main form that we will use in a windows based environment. It also sets the default selections for the dropdown/combo boxes
        /// </summary>
        public MainForm()
        {

            //init components
            ETDevice = new ETController();
            calibrateET = new ETCalibrate();
            screenVideo = new CustomScreenCapture();
            updatePoints = true;
            serverListenerEnabled = true;
            recordData = false;
            dataPoints = new ETSampleManager(ETDevice);
            dataPoints.startDataFeedback();
            dataSampleRate = 5;
            //init ui components (auto generated)
            InitializeComponent();

            //setup the default combobox selections
            callibrationPointComboBox.SelectedIndex = 2;
            targetShapeComboBox.SelectedIndex = 0;
            dataExportComboBox.SelectedIndex = 0;
            dataSampleRateComboBox.SelectedIndex = 2;
            

            Thread serverListener = new Thread(new ThreadStart(startServerListener));
            serverListener.Name = "Server Listener Thread";
            serverListener.Start();

            //setup Escape key to exit ET mouse control 
            RegisterHotKey(this.Handle, this.GetHashCode(), 0, (int) Keys.Escape);
        }
        //used to handle escape key
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                mouseHijack = false;
                Console.WriteLine("Escape Key Detected");
            }
            base.WndProc(ref m);
        }

        private void onProgramClose()
        {
            //stop recoding the avi video on close (prevents corruption of avi file)
            this.screenVideo.stopRecording();

            //kill the update point thread
            updatePoints = false;

            //kill the socket listener
            serverListenerEnabled = false;
            foreach (ClientHandler element in clientList)
            {
                if (element != null && element.running == true)
                {
                    element.running = false;
                }
            }
        }


//*******************************************
//      CALIBRATION
//*******************************************
        //button click handler used to load and connect the application to the eye tracking server
        private void Cal_Connect_Button_Click(object sender, EventArgs e)
        {


            // "Future release" launch SMI Eye tracker server automatically
            
            ETConnection connectToEyeTracker = new ETConnection();
            int res = connectToEyeTracker.connect(ETDevice);

            if (res == 104)//res 104 is used if no server has been started
            {
                DialogResult messagebox = MessageBox.Show("Could not connect to SMI Eye Tracker\n\nPlease check the Eye Tracker server has been started", "Error Connecting to Eye Tracker Server",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (messagebox == DialogResult.Retry)
                {
                    Cal_Connect_Button_Click(sender, e);
                }

            }
            else if (res != 1)//any other message (see SMI manual for error codes)
            {
                //display message box
                MessageBox.Show("Could not connect to Eye Tracker!", "Error Connecting to Eye Tracker Server",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else//connection succesful enable next step
            {
                //Display eye position on the observation monitor
                trackingMonitor = new ETTrackingMonitor(ETDevice, observationMonitorPictureBox);

                //m_EyeImageCallback = new GetEyeImageCallback(GetEyeImageCallbackFunction);
                //ETDevice.iV_SetEyeImageCallback(m_EyeImageCallback);


                //enable trackingmonitor and eyeimage monitor button (code should auto load this view first time)
                Obs_TrackingMonitor_Button.Enabled = true;
                Obs_EyeImageMonitor_Button.Enabled = true;

                //Allow/Enable the next step (Calibration)
                Cal_Calibrate_Button.Enabled = true;

                //start the ET positition data updater
              
                Thread etPoisitionUpdater = new Thread(new ThreadStart(updateETEyePosition));
                etPoisitionUpdater.Name = "Update ET position data Thread";
                etPoisitionUpdater.Start();

            }
        }

        // button click handler used to calibrate the eye tracker
        private void Cal_Calibrate_Button_Click(object sender, EventArgs e)
        {
            if (calibrateET.Calibrate(ETDevice) != 1)
            {
                DialogResult messagebox = MessageBox.Show("Calibration for the Eye Tracker failed", "Error Calibrating Eye Tracker",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (messagebox == DialogResult.Retry)
                {
                    Cal_Calibrate_Button_Click(sender, e);
                }
            }
            else
            {
                Cal_Validate_Button.Enabled = true;
            }
        }

        //button click handler used to validate the eye tracker calibration
        private void Cal_Validate_Button_Click(object sender, EventArgs e)
        {
            ETValidate etVal = new ETValidate(ETDevice, calibrationAccuracyPictureBox);
            int result = etVal.validate();

            if (result != 1)
            {
                DialogResult messagebox = MessageBox.Show("Validation for the Eye Tracker failed, Error #: " + result, "Error Validating Eye Tracker",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (messagebox == DialogResult.Retry)
                {
                    Cal_Validate_Button_Click(sender, e);
                }
            }
            else
            {
                //succesfully validated (accuracy image is automatically displayed)
                //enable CheckAccuracyButton
                Cal_CheckAccuracy_Button.Enabled = true;
                DataRec_SaveCalAcc_Button.Enabled = true;
            }
        }
        //button click handler that loads a larger view of the accuracy image
        private void Cal_CheckAccuracy_Button_Click(object sender, EventArgs e)
        {
            int ret = 0;
            try
            {
                ret = ETDevice.iV_GetAccuracy(ref m_AccuracyData, 1);
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("iV_GetAccuracy Exception: " + exc.Message);
            }
            if (ret != 1)
            {
                DialogResult messagebox = MessageBox.Show("Could not load accuracy image for the Eye Tracker, Error #: " + ret, "Error Loading Accuracy Image for Eye Tracker",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (messagebox == DialogResult.Retry)
                {
                    Cal_CheckAccuracy_Button_Click(sender, e);
                }
            }
            else
            {
                //success
            }
        }

//*******************************************
//      DATA RECORDING SECTION
//*******************************************

        // button click handler used save the accuracy image to a png file for later reference
        private void DataRec_SaveCalAcc_Button_Click(object sender, EventArgs e)
        {
            //Save calibration data to a png file
            try
            {
                calibrationAccuracyPictureBox.Image.Save("CalibrationAccuracy.png", ImageFormat.Png);
                MessageBox.Show("Calibration Accuracy Image Saved as CalibrationAccuracy.png", "Image Saved", MessageBoxButtons.OK);
            }
            catch (NullReferenceException ex)
            {
                //file not valid
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        // button click handler used to start recording eye tracker data (eye position) at a selected sample rate to out built in database.
        private void DataRec_StartDataRec_Button_Click(object sender, EventArgs e)
        {
            recordData = true;
            switch (dataSampleRateComboBox.SelectedIndex)
            {
                case 0:
                    dataSampleRate = 1;
                    break;
                case 1:
                    dataSampleRate = 2;
                    break;
                case 2:
                    dataSampleRate = 5;
                    break;
                case 3:
                    dataSampleRate = 7;
                    break;
                case 4:
                    dataSampleRate = 10;
                    break;
                case 5:
                    dataSampleRate = 20;
                    break;

            }
        }

        //button click handler used to stop recording data and the AVI video
        private void DataRec_StopDataRec_Button_Click(object sender, EventArgs e)
        {
            screenVideo.stopRecording();
        }

//*******************************************
//      OBSERVATION SECTION
//*******************************************
        // button click handler used to load the eye position monitor (show your eyes are in correct position). It is only enabled after your have succesfully connected to the ET.
        private void Obs_TrackingMonitor_Button_Click(object sender, EventArgs e)
        {
            trackingMonitor = new ETTrackingMonitor(ETDevice, observationMonitorPictureBox);
        }

        // button click handler used to load a live black and white video of your eyes
        private void Obs_EyeImageMonitor_Button_Click(object sender, EventArgs e)
        {
            //This does not work due to an access violation, it seems to be cause by the picture box being to big for the call back
            //ETEyeImageMonitor bwEyeVid = new ETEyeImageMonitor(ETDevice, observationMonitorPictureBox);
            //workaround, not in design but it is stable
            int ret = 0;
            try
            {
                ret = ETDevice.iV_ShowEyeImageMonitor();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("iV_ShowEyeImageMonitor Exception: " + exc.Message);
            }

        }

//*******************************************
//      APPLICATIONS SECTION
//******************************************
        //button click handler used to load the Simon Says game
        private void App_SimonSays_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"..\..\..\..\ET_Apps\cicero_v1.exe";
                if (File.Exists(path))
                {
                    Process launcher = new Process();
                    launcher.StartInfo.FileName = path;
                    launcher.Start();

                }
                else
                {
                    Console.WriteLine("exe not found @ " + Directory.GetCurrentDirectory() + path);
                    throw new Exception("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't find exe file");
                App_OtherApps_Button_Click(sender, e);
            }
        }

        // This  is the button click handler used to load the Maze game
        private void App_Maze_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"..\..\..\..\ET_Apps\Maze_v1.exe";
                if (File.Exists(path))
                {
                    Process launcher = new Process();
                    launcher.StartInfo.FileName = path;
                    launcher.Start();

                }
                else
                {
                    Console.WriteLine("exe not found @ " + Directory.GetCurrentDirectory() + path);
                    throw new Exception("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't find exe file");
                App_OtherApps_Button_Click(sender, e);
            }
        }

        //button click handler used to load/launch any .exe file
        private void App_OtherApps_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Executables|*.exe|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            DialogResult res = openFileDialog.ShowDialog();

            if (File.Exists(openFileDialog.FileName) && res == DialogResult.OK)
            {
                Console.WriteLine("Launch: " + openFileDialog.FileName.ToString());
                Process launcher = new Process();
                launcher.StartInfo.FileName = openFileDialog.FileName.ToString();
                launcher.Start();
                //start the video and ET data recorder
                recordData = true;
                startRecordingData();
            }
            else if (res == DialogResult.Cancel)
            {
            }
            else
            {
                MessageBox.Show("Error opening file!"); //Error message if the file does not open
            }
        }
//*******************************************
//      SUPPORT FUNCTIONS SECTION
//******************************************
        //used when any of the calibration data has changed (from the combo boxes)
        private void callibrationDataChanged(object sender, EventArgs e)
        {
            //int ret = 0;
            int[] calibrationPoints = { 1, 2, 5, 9 };
            int displayDevice = 0;
            int targetSize = 20;

            ETController.CalibrationStruct calData;
            calData.displayDevice = displayDevice;
            calData.autoAccept = 1;
            calData.method = calibrationPoints[callibrationPointComboBox.SelectedIndex];
            calData.visualization = 1;
            calData.speed = 0;
            calData.targetShape = targetShapeComboBox.SelectedIndex + 2;
            calData.backgroundColor = 50;
            calData.foregroundColor = 250;
            calData.targetSize = targetSize;
            calData.targetFilename = "";

            calibrateET.SetupData = calData;
        }
        //Thread used to send out any ET data where needed (continously called in its own thread)
        private void updateETEyePosition()
        {
            int count = 0;
            int stare = 0;
            int mouseX = 0;
            int mouseY = 0;
            while (updatePoints)
            {
                int xPos = (int)((dataPoints.etPositionData.leftEye.gazeX + dataPoints.etPositionData.rightEye.gazeX) / 2);
                int yPos = (int)((dataPoints.etPositionData.leftEye.gazeY + dataPoints.etPositionData.rightEye.gazeY) / 2);
                const int MOUSEEVENTF_LEFTDOWN = 0x02;
                const int MOUSEEVENTF_LEFTUP = 0x04;


                if (mouseHijack)
                {
                    //hijack the mouse
                    Cursor.Position = new Point(xPos, yPos);

                    //in range
                    if ((xPos <= mouseX + 15 && xPos >= mouseX - 15) && (yPos <= mouseY + 15 || yPos >= mouseY - 15))
                    {
                        stare++;
                        if (stare == 1)
                        {
                            mouseX = xPos;
                            mouseY = yPos;
                        }
                    }
                    //out of range
                    else
                    {
                        stare = 0;
                        mouseX = xPos;
                        mouseY = yPos;
                    }
                    if (stare == 40)
                    {
                        
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0);
                        stare = 0;
                    }

                }

                //send to AVI recorder
                screenVideo.CurrentEyePosition = new Point(xPos, yPos);

                //save at sample rate
                if (count * 50 > (1000 / dataSampleRate))
                {
                    saveETDataToDB(xPos,yPos);
                    count = 0;
                }
                count++;
                Thread.Sleep(50);

                
            }
        }
        private void saveETDataToDB(int xPos, int yPos)
        {
            DBWrapper db = new DBWrapper();
            EyeTrackerORM testData = new EyeTrackerORM(xPos, yPos, DateTime.Now, 1);//change game ids
            db.AddEyeTrackerData(testData);
            
        }
        //*******************************************
        //      Testing area
        //*******************************************
        private List<ClientHandler> clientList;
        private void startServerListener()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            TcpListener serverSocket = new TcpListener(IPAddress.Parse(localIP), 10000);
            TcpClient clientSocket = default(TcpClient);
            clientList = new List<ClientHandler>();

            int counter = 0;

            serverSocket.Start();
            Console.WriteLine(" >> " + "Server Started");

            counter = 0;
            while (serverListenerEnabled)
            {
                if(!serverSocket.Pending())
                {
                    Thread.Sleep(500);
                    continue;
                }
                else
                {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                    ClientHandler client = new ClientHandler();
                    clientList.Add(client);
                    client.startClient(clientSocket, Convert.ToString(counter));
                    Thread clientThread = new Thread(new ThreadStart(client.doListen));
                    clientThread.Name = "Client " + counter + " Thread";
                    client.newMessageToSend = newMessageRecieved;
                    clientThread.Start();
                }
            }

            serverSocket.Stop();
            Console.WriteLine(" >> " + "exit");
            Console.ReadLine();
        }

        private void newMessageRecieved(string inMsg)
        {
            DataParser dataParse = new DataParser();
            if(inMsg == "START")
            {
                mouseHijack = true;
                startRecordingData();            
            }
            else if (dataParse.parseDataString(inMsg) == "Success")
            {
                handleData(dataParse.storageTable);
            }
            else 
            {
                //bad data
            }

        }

        private void handleData(Dictionary<string, string> dictionary)
        {
            Console.WriteLine("Data parsed and receive succesful");
            if (dictionary.ContainsKey("Game Type"))
            {
                string title = dictionary["Game Type"];
                DBWrapper db = new DBWrapper();
                switch (title)
                {
                    case "!SAY":
                        SimonORM sayData = new SimonORM(dictionary);
                        db.AddSimonData(sayData);
                        break;
                    case "!MAZ":
                        MazeORM mazData = new MazeORM(dictionary);
                        db.AddMazeData(mazData);
                        break;
                }
            }

        }
        private void startRecordingData()
        {
            if (recordData)
            {
                recordData = false;
                try
                {
                    Console.WriteLine("Recording data");
                    Thread aviThread = new Thread(new ThreadStart(screenVideo.CaptureVideo));
                    aviThread.Name = "AVI Recording Thread";
                    aviThread.Start();

                    Thread vidTimer = new Thread(new ThreadStart(screenVideo.startVideoTimer));
                    vidTimer.Name = "Avi timer Thread";
                    vidTimer.Start();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not start video recording thread: " + ex);
                }
            }
        }

        private void DatExp_ExportButton_Click(object sender, EventArgs e)
        {
            DBWrapper db = new DBWrapper();
            db.ExportDataToCSV();

        }

    }
}