﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AviFile;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ET_Project_UI
{
    public partial class EyeTrackerForm : Form
    {
       
        //Setup a logger
        Logger debugLog = new Logger("Log.txt");
        //declarations
        ETController ETDevice;
        ETController.AccuracyStruct m_AccuracyData;
        ETController.CalibrationStruct m_CalibrationData;
        ETController.ImageStruct m_AccuracyImageData;


        // callback routine declaration
        private delegate void CalibrationCallback(ETController.CalibrationPointStruct calibrationPointData);
        private delegate void GetTrackingMonitorCallback(ETController.ImageStruct imageData);


        //callback function instances
        CalibrationCallback m_CalibrationCallback;
        GetTrackingMonitorCallback m_TrackingMonitorCallback;

        // delegates which will be used by invoking functions 
        public delegate void DisplayTrackingMonitor();

    public EyeTrackerForm()
        {
            InitializeComponent();

            ETDevice = new ETController();
            m_CalibrationCallback = new CalibrationCallback(CalibrationCallbackFunction);
            m_TrackingMonitorCallback = new GetTrackingMonitorCallback(GetTrackingMonitorCallbackFunction);
        }

        public string getLocalIPAddress()
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
            return localIP;
        }
        
        
        
        //The following methods are used as the button handlers 
        
       


        
        //The following methods are used for the menu items
        //File -> Connect
        //Connect
        private void Connect_Click(object sender, EventArgs e)
        {
            Connection connectToEyeTracker = new Connection();
            if (connectToEyeTracker.connect(ETDevice) != 1)
            {
                MessageBox.Show("Error Connection to EyeTracker");
                StatusBarLabel.Text = "Failed to connect to EyeTracker";
            }
            else
            {
                CalibrateButton.Enabled = true;
                ShowEyePlacementButton.Enabled = true;
                StatusBarLabel.Text = "Connected";
            }
        }

        //File -> Disconnect

        //TODO

        //File -> Save

        //TODO

        //File -> Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //Help -> About
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About tempAboutForm = new About();
            tempAboutForm.Show();
        }

        //Callibrate
        private void Callibrate_Click(object sender, EventArgs e)
        {
            int ret = 0;
            int calibrationPoints = 5;
            int displayDevice = 0;
            int targetSize = 20;

            try
            {

                displayDevice = 0;
                calibrationPoints = 5;

                m_CalibrationData.displayDevice = displayDevice;
                m_CalibrationData.autoAccept = 1;
                m_CalibrationData.method = calibrationPoints;
                m_CalibrationData.visualization = 1;
                m_CalibrationData.speed = 0;
                m_CalibrationData.targetShape = 2;
                m_CalibrationData.backgroundColor = 230;
                m_CalibrationData.foregroundColor = 250;
                m_CalibrationData.targetSize = targetSize;
                m_CalibrationData.targetFilename = "";

                ret = ETDevice.iV_SetupCalibration(ref m_CalibrationData);
                if (ret == 1) Console.WriteLine("iV_SetupCalibration: Calibration set up successfully");
                if (ret == 101) Console.WriteLine("iV_SetupCalibration: no connection established");
                if (ret == 111) Console.WriteLine("iV_SetupCalibration: eye tracking device required for this function is not connected");
                if (ret == 112) Console.WriteLine("iV_SetupCalibration: parameter out of range");
                if (ret == 113) Console.WriteLine("iV_SetupCalibration: eye tracking device required for this calibration method is not connected");

                ret = ETDevice.iV_Calibrate();
                if (ret == 1)
                {
                    Console.WriteLine("iV_Calibrate: Calibration started successfully");
                    VerifyButton.Enabled = true;
                }
                if (ret == 3) Console.WriteLine("iV_Calibrate: Calibration was aborted");
                if (ret == 101) Console.WriteLine("iV_Calibrate: no connection established");
                if (ret == 111) Console.WriteLine("iV_Calibrate: eye tracking device required for this function is not connected");
                if (ret == 113) Console.WriteLine("iV_Calibrate: eye tracking device required for this calibration method is not connected");

            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Calibration Exception: " + exc.Message);
            }

        }
        //get the accuracy of the calibration
        private void GetAccuracy_Click(object sender, EventArgs e)
        {
            int ret = 0;

            try
            {
                ret = ETDevice.iV_GetAccuracy(ref m_AccuracyData, 1);
                if (ret == 1) Console.WriteLine("Accuracy - Dev X: " + m_AccuracyData.deviationXLeft + " Dev Y: " + m_AccuracyData.deviationYLeft);
                if (ret == 2) Console.WriteLine("Accuracy - iV_GetAccuracy: no new data  available");
                if (ret == 101) Console.WriteLine("Accuracy - iV_GetAccuracy: no connection established");
                if (ret == 103) Console.WriteLine("Accuracy - iV_GetAccuracy: system is not validated ");
                if (ret == 112) Console.WriteLine("Accuracy - iV_GetAccuracy: parameter out of range");
            }
            catch (System.Exception exc)
            {
                 Console.WriteLine("iV_GetAccuracy Exception: " + exc.Message);
            }
        }
        //validation
        private void Verify_Click(object sender, EventArgs e)
        {
            int ret = 0;

            try
            {
                ret = ETDevice.iV_Validate();
                if (ret == 1) Console.WriteLine("iV_Validate: Validation started successfully");
                if (ret == 3) Console.WriteLine("iV_Validate: Validation was aborted");
                if (ret == 101) Console.WriteLine("iV_Validate: no connection established");
                if (ret == 111) Console.WriteLine("iV_Validate: eye tracking device required for this function is not connected");
                if (ret == 113) Console.WriteLine("iV_Validate: eye tracking device required for this validation method is not connected");


            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Validation Exception: " + exc.Message);
            }

            ret = ETDevice.iV_GetAccuracyImage(ref m_AccuracyImageData);
            if (ret == 1)
            {
                Console.WriteLine("iV_GetAccuracyImage: iV_GetAccuracyImage executed successfully");

                ShowAccuracyImage(m_AccuracyImageData);
            }
            else Console.WriteLine("iV_GetAccuracyImage: Error with iV_GetAccuracyImage");
        }
        

        //callbacks
        void CalibrationCallbackFunction(ETController.CalibrationPointStruct calibrationPoint)
        {
            Console.WriteLine("Data from CalibrationCallback - Number:" + calibrationPoint.number + " PosX:" + calibrationPoint.positionX + " PosY:" + calibrationPoint.positionY);
        }
        void GetTrackingMonitorCallbackFunction(ETController.ImageStruct image)
        {
            Bitmap trackingmonitorbmp;
            trackingmonitorbmp = new Bitmap(image.imageWidth, image.imageHeight, image.imageWidth * 3, PixelFormat.Format24bppRgb, image.imageBuffer);
            UpdateTrackingMonitor(trackingmonitorbmp);
        }
        public void UpdateTrackingMonitor(Bitmap trackingMonitorBmp)
        {
            try
            {
                if (EyeTrackingPicture.InvokeRequired)
                {
                    // create grayscale color table
                    EyeTrackingPicture.BeginInvoke((DisplayTrackingMonitor)delegate
                    {
                        EyeTrackingPicture.Image = trackingMonitorBmp;
                    });
                }
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
        }
        public void UpdateAccuracyImage(Bitmap AccuracyImageBmp)
        {
            try
            {
                AccuracyImage.Image = AccuracyImageBmp;
                //AccuracyImage.Image = ResizeBitmap(AccuracyImageBmp,273,153);

            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Accuracy Image Exception: " + exc.Message);
            }
        }

        private void ShowAccuracyImage(ETController.ImageStruct image)
        {
            Bitmap AccuracyImagebmp;
            Console.WriteLine("Showing picture: Width: " + m_AccuracyImageData.imageWidth + "Height: " + image.imageHeight);
            AccuracyImagebmp = new Bitmap(image.imageWidth, image.imageHeight, image.imageWidth * 3, PixelFormat.Format24bppRgb, image.imageBuffer);
            UpdateAccuracyImage(AccuracyImagebmp);
        }

        private void AccuracyImage_Click(object sender, EventArgs e)
        {

        }

        private void ShowEyePlacementButton_Click(object sender, EventArgs e)
        {
            ETDevice.iV_SetTrackingMonitorCallback(m_TrackingMonitorCallback);

        }

        private CustomScreenCapture screenVideo = new CustomScreenCapture();


        private void startVidRec_Click(object sender, EventArgs e)
        {
            debugLog.Write("Video recording Started");
            //Start the AVI recording
            Thread aviThread = new Thread(new ThreadStart(screenVideo.CaptureVideo));
      
            aviThread.Start();
            
            //testing
            while (!aviThread.IsAlive);
        }

        private void stopVidRec_Click(object sender, EventArgs e)
        {
            screenVideo.stopRecording();
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            Thread serverListener = new Thread(new ThreadStart(startServerListener));
            //serverListener.Name = "Server Listener Thread";
            serverListener.Start();
        }

        private void startServerListener()
        {

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Parse("75.102.73.129"), 23456));
                socket.Listen(100);
                while (true)
                {
                    using (var client = socket.Accept())
                    {
                        var bounds = Screen.PrimaryScreen.Bounds;
                        var bitmap = new Bitmap(bounds.Width, bounds.Height);
                        try
                        {
                            while (true)
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
            }


            //Socket sck;
            //Console.WriteLine("Server Started...");
            //sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //sck.Bind(new IPEndPoint(IPAddress.Parse("75.102.73.129"), 7777));

            //while (true)
            //{
            //    sck.Listen(100);
            //    Socket accepted = sck.Accept();
            //    byte[] tempImage = new byte[1024];
            //    int cnt = 0;
                
            //    while (accepted.Connected)
            //    {
            //        //works!!!
            //        //byte[] data = new byte[4];
            //        //data = Encoding.UTF8.GetBytes("Sup pup "+cnt);
            //        //cnt++;
            //        //sendData(accepted, data);
            //   // if (accepted.Connected)
            //   // {
            //        try
            //        {
            //            if (cnt == 0)
            //            {
            //                byte[] bmpBytes = ReadImageFile("test.jpg");
            //                Console.WriteLine("Sending Data");
            //                sendData(accepted, bmpBytes);
            //            }
            //            cnt++;
            //        }
            //        catch (SocketException ex)
            //        {
            //            Console.WriteLine("Something went wrong -> " + ex);
            //        }
            //    }
            //    if (!accepted.Connected)
            //    {
            //        Console.WriteLine("Client has disconnected");
            //    }
            //}
        }
        private void sendData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataLeft = size;
            int dataSent;

            //this sends the data in a buffer (the first 4 bytes are always the data size)
            byte[] dataSize = new byte[4];
            dataSize = BitConverter.GetBytes(data.Length);
            dataSent = s.Send(dataSize);
            Console.WriteLine("DataSize is = "+BitConverter.ToInt32(dataSize,0));
           
            //Send the actual data 
            while (total < size)
            {
                dataSent = s.Send(data, total, dataLeft, SocketFlags.None);
                total += dataSent;
                dataLeft -= dataSent;
            }
        }
        private static byte[] ReadImageFile(String img)
        {
            FileInfo fileInfo = new FileInfo(img);
            byte[] buf = new byte[fileInfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            //fileInfo.Delete ();
            GC.ReRegisterForFinalize(fileInfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }
    }
    
}
