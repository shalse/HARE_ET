using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ET_Project_GUI.ET_Calibration
{
    class ETTrackingMonitor
    {
        private delegate void GetTrackingMonitorCallback(ETController.ImageStruct imageData);
        private delegate void DisplayTrackingMonitor();
        private GetTrackingMonitorCallback m_TrackingMonitorCallback;
        private PictureBox pictureBoxReference;
    
        public ETTrackingMonitor(ETController ETDevice, PictureBox inPicBox)
        {
            m_TrackingMonitorCallback = new GetTrackingMonitorCallback(GetTrackingMonitorCallbackFunction);
            ETDevice.iV_SetTrackingMonitorCallback(m_TrackingMonitorCallback);
            pictureBoxReference = inPicBox;
            
        }
        private void GetTrackingMonitorCallbackFunction(ETController.ImageStruct image)
        {
            Bitmap trackingmonitorbmp;
            trackingmonitorbmp = new Bitmap(image.imageWidth, image.imageHeight, image.imageWidth * 3, PixelFormat.Format24bppRgb, image.imageBuffer);
            UpdateTrackingMonitor(trackingmonitorbmp);
        }
        private void UpdateTrackingMonitor(Bitmap trackingMonitorBmp)
        {
            try
            {
                Console.WriteLine("Update!");
                if (pictureBoxReference.InvokeRequired)
                {
                    // create grayscale color table
                    pictureBoxReference.BeginInvoke((DisplayTrackingMonitor)delegate
                    {
                        pictureBoxReference.Image = trackingMonitorBmp;
                    });
                }
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
        }
    }
}
