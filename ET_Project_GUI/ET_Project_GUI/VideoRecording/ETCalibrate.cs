using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.ET_Calibration
{
    class ETCalibrate
    {
        private ETController.CalibrationStruct m_CalibrationData;
        public ETCalibrate()
        {
            int calibrationPoints = 5;
            int displayDevice = 0;
            int targetSize = 20;
            displayDevice = 0;
            calibrationPoints = 5;

            m_CalibrationData.displayDevice = displayDevice;
            m_CalibrationData.autoAccept = 1;
            m_CalibrationData.method = calibrationPoints;
            m_CalibrationData.visualization = 1;
            m_CalibrationData.speed = 0;
            m_CalibrationData.targetShape = 2;
            m_CalibrationData.backgroundColor = 20;
            m_CalibrationData.foregroundColor = 250;
            m_CalibrationData.targetSize = targetSize;
            m_CalibrationData.targetFilename = "";
        }
        //calibrate given eyetracker
        public int Calibrate(ETController etController)
        {
            int ret = 0;
            

            ret = etController.iV_SetupCalibration(ref m_CalibrationData);
            if (ret == 1) Console.WriteLine("iV_SetupCalibration: Calibration set up successfully");
            if (ret == 101) Console.WriteLine("iV_SetupCalibration: no connection established");
            if (ret == 111) Console.WriteLine("iV_SetupCalibration: eye tracking device required for this function is not connected");
            if (ret == 112) Console.WriteLine("iV_SetupCalibration: parameter out of range");
            if (ret == 113) Console.WriteLine("iV_SetupCalibration: eye tracking device required for this calibration method is not connected");

            if (ret == 1)
            {
                ret = etController.iV_Calibrate();
                if (ret == 1) Console.WriteLine("iV_Calibrate: Calibration started successfully");
                if (ret == 3) Console.WriteLine("iV_Calibrate: Calibration was aborted");
                if (ret == 101) Console.WriteLine("iV_Calibrate: no connection established");
                if (ret == 111) Console.WriteLine("iV_Calibrate: eye tracking device required for this function is not connected");
                if (ret == 113) Console.WriteLine("iV_Calibrate: eye tracking device required for this calibration method is not connected");
                return ret;
            }
            else
            {
                return ret;
            }
        }
        //option to change the default values of calibration setup
        public ETController.CalibrationStruct SetupData
        {
            get { return m_CalibrationData; }
            set { m_CalibrationData = value; }
        }
    }
}
