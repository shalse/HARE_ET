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
        public ETController.ImageStruct m_AccuracyImageData;
        private PictureBox pictureBoxReference;
        private ETController ETDevice;

        public ETValidate(ETController inETDevice, PictureBox inPicBox)
        {
           
            ETDevice = inETDevice;
            pictureBoxReference = inPicBox;  
        }
        public int validate()
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
                pictureBoxReference.Image = AccuracyImageBmp;
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Accuracy Image Exception: " + exc.Message);
            }
        }
    }
}
