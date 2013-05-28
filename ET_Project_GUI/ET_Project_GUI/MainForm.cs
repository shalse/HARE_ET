﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ET_Project_GUI.Network;
using ET_Project_GUI.ET_Calibration;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;
using ET_Project_GUI.Testing;
using System.Net.Sockets;
using System.Net;

namespace ET_Project_GUI
{
    public partial class MainForm : Form
    {


 

        //global variables
        private ETController ETDevice;
        private ETCalibrate calibrateET;
        private ETController.AccuracyStruct m_AccuracyData;
        private CustomScreenCapture screenVideo;
        private ETTrackingMonitor trackingMonitor; 
        private bool updatePoints;
        private bool serverListenerEnabled;
        private ETSampleManager dataPoints;

        
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
            dataPoints = new ETSampleManager(ETDevice);
            dataPoints.startDataFeedback();

            //init ui components (auto generated)
            InitializeComponent();

            //setup the default combobox selections
            callibrationPointComboBox.SelectedIndex = 2;
            targetShapeComboBox.SelectedIndex = 0;
            dataSampleRateComboBox.SelectedIndex = 2;
            
            //start the server to listen for incoming connections
            Thread serverListener = new Thread(new ThreadStart(startServerListener));
            serverListener.Name = "Server Listener Thread";
            serverListener.Start();
            
           
        }
        private void onProgramClose()
        {
            //stop recoding the avi video on close (prevents corruption of avi file)
            this.screenVideo.stopRecording();

            //kill the update point thread
            updatePoints = false;
            //kill the socket listener
            serverListenerEnabled = false;

        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        //*******************************************
        //      CALIBRATION
        //*******************************************
        /// <summary>
        /// This is the button click handler used to load and connect the application to the eye tracking server
        /// </summary>
        /// <param name="sender">Auto generated by the button</param>
        /// <param name="e">Auto generated by the button</param>
        private void Cal_Connect_Button_Click(object sender, EventArgs e)
        {

            // TODO "Future release" launch SMI Eye tracker server automatically

            //disable the remote view button as this will be dedicated as a "subject computer"
            Obs_RemoteView_Button.Enabled = false;

            ETConnection connectToEyeTracker = new ETConnection();
            int res =  connectToEyeTracker.connect(ETDevice);


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

        /// <summary>
        /// This  is the button click handler used to calibrate the eye tracker
        /// </summary>
        /// <param name="sender">Auto generated by the button</param>
        /// <param name="e">Auto generated by the button</param>
        private void Cal_Calibrate_Button_Click(object sender, EventArgs e)
        {
            if(calibrateET.Calibrate(ETDevice) != 1)
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
        /// <summary>
        /// This  is the button click handler used to validate the eye tracker calibration
        /// </summary>
        /// <param name="sender">Auto generated by the button</param>
        /// <param name="e">Auto generated by the button</param>
        private void Cal_Validate_Button_Click(object sender, EventArgs e)
        {
            ETValidate etVal = new ETValidate(ETDevice, calibrationAccuracyPictureBox);
            int result = etVal.validate();
            
            if (result != 1)
            {
                DialogResult messagebox = MessageBox.Show("Validation for the Eye Tracker failed, Error #: "+result, "Error Validating Eye Tracker",
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
        /// <summary>
        /// This  is the button click handler that loads a larger view of the accuracy image
        /// </summary>
        /// <param name="sender">Auto generated by the button</param>
        /// <param name="e">Auto generated by the button</param>
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
                MessageBox.Show("Calibration Accuracy Image Saved", "Image Saved", MessageBoxButtons.OK); 
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: "+ex.Message);
                //file not valid
            }

        }

        // button click handler used to start recording eye tracker data (eye position) at a selected sample rate to out built in database.
        private void DataRec_StartDataRec_Button_Click(object sender, EventArgs e)
        {
            //AVI video recording thread
            try
            {
                Thread aviThread = new Thread(new ThreadStart(screenVideo.CaptureVideo));
                aviThread.Name = "AVI Recording Thread";
                aviThread.Start();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not start video recording thread: "+ex);
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

        // button click handler used to load the remote view. Note that this option will become disabled if you are connected to the eye tracker. The purpose
        private void Obs_RemoteView_Button_Click(object sender, EventArgs e)
        {
            //disable all calibration buttons as this will be the "experimenters computer"
            Cal_Connect_Button.Enabled = false;
            Cal_Calibrate_Button.Enabled = false;
            Cal_Validate_Button.Enabled = false;
            Cal_CheckAccuracy_Button.Enabled = false;

            // TODO "SHANE" add logic for loading remote view
        }
        
//*******************************************
//      APPLICATIONS SECTION
//******************************************
        //button click handler used to load the Simon Says game
        private void App_SimonSays_Button_Click(object sender, EventArgs e)
        {
            // TODO "SHANE/MATT" add logic for loading simon says app
        }

        // This  is the button click handler used to load the Maze game
        private void App_Maze_Button_Click(object sender, EventArgs e)
        {
            // TODO "SHANE/MATT" add logic for loading maze app
        }

        //button click handler used to load the Keyboard control app
        private void App_KeyboardControl_Button_Click(object sender, EventArgs e)
        {
            // TODO "PETER" add logic for loading keyboard control app
        }
    
        //button click handler used to load the Mouse control app
        private void App_MouseControl_Button_Click(object sender, EventArgs e)
        {
            // TODO "PETER/JOSH" add logic for loading mouse control app
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
                Process launcher = new Process();
                launcher.StartInfo.FileName = openFileDialog.FileName.ToString();
                launcher.Start();
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
        //used to start the TCP server for sending et data to the applications and recieveing data from the games 
        private void startServerListener()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            socket.Bind(new IPEndPoint(IPAddress.Parse(localIP), 10000));
            //TODO "SHANE" code/decode messages
            Console.WriteLine("Local Address: "+localIP);
            socket.Listen(100);
            while (serverListenerEnabled)
            {
                Socket client = socket.Accept();
                var bounds = Screen.PrimaryScreen.Bounds;
                var bitmap = new Bitmap(bounds.Width, bounds.Height);
                try
                {
                    while (serverListenerEnabled)
                    {
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CopyFromScreen(bounds.X, 0, bounds.Y, 0, bounds.Size);
                        }
                        //bitmap = new Bitmap(bitmap, new Size((int)(bounds.Width * 0.25), (int)(bounds.Height * 0.25)));


                        // bitmap.GetThumbnailImage(bounds.Width * 0.25, bounds.Height * 0.25);
                        byte[] imageData;
                        using (var stream = new MemoryStream())
                        {

                            bitmap.Save(stream, ImageFormat.Png);

                            imageData = stream.ToArray();
                        }
                        var lengthData = BitConverter.GetBytes(imageData.Length);
                        if (client.Send(lengthData) < lengthData.Length) break;
                        if (client.Send(imageData) < imageData.Length) break;
                        Thread.Sleep(1000);
                    }
                }
                catch
                {
                    break;
                }
            }
        }
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
        //Thread used to send out any ET data where needed
        private void updateETEyePosition()
        {
            while (updatePoints)
            {
                int xPos = (int)((dataPoints.etPositionData.leftEye.gazeX + dataPoints.etPositionData.rightEye.gazeX) / 2);
                int yPos = (int)((dataPoints.etPositionData.leftEye.gazeY + dataPoints.etPositionData.rightEye.gazeY) / 2);
                
                //send to AVI recorder
                screenVideo.CurrentEyePosition = new Point(xPos, yPos);

                Thread.Sleep(100);
            }
        }
//*******************************************
//      Testing area
//*******************************************

 
    }
}
