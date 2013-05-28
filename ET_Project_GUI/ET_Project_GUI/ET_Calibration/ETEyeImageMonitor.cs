using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ET_Project_GUI.ET_Calibration
{
    class ETEyeImageMonitor
    {
        private delegate void GetEyeImageCallback(ETController.ImageStruct imageData);
        public delegate void DisplayEyeImage();
        private GetEyeImageCallback EyeImageCallback;
        private PictureBox pictureBoxReference;
        
        public ETEyeImageMonitor(ETController ETDevice, PictureBox inPicBox)
        {
            Console.WriteLine("Test1");
            EyeImageCallback = new GetEyeImageCallback(GetEyeImageCallbackFunction);
            ETDevice.iV_SetEyeImageCallback(EyeImageCallback);
            pictureBoxReference = inPicBox;
        }
        private void GetEyeImageCallbackFunction(ETController.ImageStruct image)
        {

            Bitmap eyeImageBmp;
            eyeImageBmp = new Bitmap(image.imageWidth, image.imageHeight, image.imageWidth * 3, PixelFormat.Format24bppRgb, image.imageBuffer);
            UpdateTrackingMonitor(eyeImageBmp);
                        
        }
        private void UpdateTrackingMonitor(Bitmap EyeImageBmp)
        {
            try
            {
                if (pictureBoxReference.InvokeRequired)
                {
                    pictureBoxReference.BeginInvoke((DisplayEyeImage)delegate
                    { 
                        pictureBoxReference.Image = EyeImageBmp;
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
