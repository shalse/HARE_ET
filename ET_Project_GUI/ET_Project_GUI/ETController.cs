using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ET_Project_GUI
{
    class ETController
    {
        //import from DLL
        [DllImport("iViewXAPI.dll", EntryPoint = "iV_Connect")]
        private static extern int Unmanaged_Connect(StringBuilder sendIPAddress, int sendPort, StringBuilder recvIPAddress, int receivePort);

        [DllImport("iViewXAPI.dll", EntryPoint = "iV_Calibrate")]
        private static extern int Unmanaged_Calibrate();

        [DllImport("iViewXAPI.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "iV_SetCalibrationCallback")]
        private static extern void Unmanaged_SetCalibrationCallback(MulticastDelegate calibrationCallbackFunction);

        [DllImport("iViewXAPI.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "iV_SetTrackingMonitorCallback")]
        private static extern void Unmanaged_SetTrackingMonitorCallback(MulticastDelegate trackingMonitorCallbackFunction);

        [DllImport("iViewXAPI.dll", EntryPoint = "iV_GetAccuracy")]
        private static extern int Unmanaged_GetAccuracy(ref AccuracyStruct accuracyData, int visualization);

        [DllImport("iViewXAPI.dll", EntryPoint = "iV_GetAccuracyImage")]
        private static extern int Unmanaged_GetAccuracyImage(ref ImageStruct imageData);

        [DllImport("iViewXAPI.dll", EntryPoint = "iV_SetupCalibration")]
        private static extern int Unmanaged_SetupCalibration(ref CalibrationStruct calibrationData);

        [DllImport("iViewXAPI.dll", EntryPoint = "iV_Validate")]
        private static extern int Unmanaged_Validate();

        //func from DLL
        //Connect
        public int iV_Connect(StringBuilder sendIP, int sendPort, StringBuilder receiveIP, int receivePort)
        {
            return Unmanaged_Connect(sendIP, sendPort, receiveIP, receivePort);
        }

        //Calibrate
        public int iV_Calibrate()
        {
            return Unmanaged_Calibrate();
        }

        //get the accuracy
        public int iV_GetAccuracy(ref AccuracyStruct accuracyData, int visualization)
        {
            return Unmanaged_GetAccuracy(ref accuracyData, visualization);
        }
        //get the accuracy image
        public int iV_GetAccuracyImage(ref ImageStruct image)
        {
            return Unmanaged_GetAccuracyImage(ref image);
        }
        //Set callibration callback
        public void iV_SetCalibrationCallback(MulticastDelegate calibrationCallback)
        {
            Unmanaged_SetCalibrationCallback(calibrationCallback);
        }
        //used for the tracking of your eyes
        public void iV_SetTrackingMonitorCallback(MulticastDelegate trackingMonitorCallback)
        {
            Unmanaged_SetTrackingMonitorCallback(trackingMonitorCallback);
        }
        //Setup Calibrate
        public int iV_SetupCalibration(ref CalibrationStruct calibrationData)
        {
            return Unmanaged_SetupCalibration(ref calibrationData);
        }
        //validate
        public int iV_Validate()
        {
            return Unmanaged_Validate();
        }
        //structs
        public struct AccuracyStruct
        {
            public double deviationXLeft;
            public double deviationYLeft;
            public double deviationXRight;
            public double deviationYRight;
        };
        public struct CalibrationPointStruct
        {
            public int number;
            public int positionX;
            public int positionY;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct CalibrationStruct
        {
            public int method;
            public int visualization;
            public int displayDevice;
            public int speed;
            public int autoAccept;
            public int foregroundColor;
            public int backgroundColor;
            public int targetShape;
            public int targetSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string targetFilename;
        };
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct ImageStruct
        {
            public int imageHeight;
            public int imageWidth;
            public int imageSize;
            public IntPtr imageBuffer;
        };
    }
}
