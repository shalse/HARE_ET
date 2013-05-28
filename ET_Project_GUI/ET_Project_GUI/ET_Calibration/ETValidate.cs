using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ET_Project_GUI.ET_Calibration
{
    class ETValidate
    {
        private delegate void DisplayAccuracyImage();

        ETController.ImageStruct m_AccuracyImageData;
        private PictureBox pictureBoxReference;

        public int validate(ETController ETDevice, PictureBox inPicBox)
        {
            int ret = 0;
            pictureBoxReference = inPicBox;
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
                ShowAccuracyImage(m_AccuracyImageData);
            }
            else
            {
                Console.WriteLine("Error with Getting Accuracy Image");
            }
            return ret;
        }
        private void ShowAccuracyImage(ETController.ImageStruct image)
        {
            Bitmap AccuracyImagebmp;
            Console.WriteLine("Showing picture: Width: " + m_AccuracyImageData.imageWidth + "Height: " + image.imageHeight);
            AccuracyImagebmp = new Bitmap(image.imageWidth, image.imageHeight, image.imageWidth * 3, PixelFormat.Format24bppRgb, image.imageBuffer);
            UpdateAccuracyImage(AccuracyImagebmp);
        }
        public void UpdateAccuracyImage(Bitmap AccuracyImageBmp)
        {
            try
            {
                if (pictureBoxReference.InvokeRequired)
                {
                    // create grayscale color table
                    pictureBoxReference.BeginInvoke((DisplayAccuracyImage)delegate
                    {
                        pictureBoxReference.Image = AccuracyImageBmp;
                    });
                }
                //AccuracyImage.Image = AccuracyImageBmp;
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Accuracy Image Exception: " + exc.Message);
            }
        }
    }
}
