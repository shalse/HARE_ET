﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AviFile;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace ET_Project_UI
{
    class CustomScreenCapture
    {
        private AviManager aviManager = new AviManager("output.avi", false);
        private int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        private Bitmap b = null;
        private Graphics g;
        private VideoStream aviStream = null;
        public bool pause = false;
        private int count = 0;
        //used for circle over lay
        private Brush fillBrush = new SolidBrush(ColorTranslator.FromHtml("#ff0000"));


        //testing
        private Random random = new Random();
        private Point previousPoint = new Point(0, 0);
        private Point currentPoint = new Point(0, 0);

        public void CaptureVideo()
        {
            b = new Bitmap(ScreenWidth, ScreenHeight);
            g = Graphics.FromImage(b);
            g.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);

            b.Save("pics/test.png", ImageFormat.Png);

            //auto set options for video recording 
            //(description for each option availible at http://msdn.microsoft.com/en-us/library/windows/desktop/dd756832(v=vs.85).aspx)
            Avi.AVICOMPRESSOPTIONS aviOptions = new Avi.AVICOMPRESSOPTIONS();
            aviOptions.fccType = (uint)Avi.streamtypeVIDEO;
            //codec to use MSVC = Microsoft Video 1
            aviOptions.fccHandler = (uint)Avi.mmioStringToFOURCC("MSVC", 0);
            //quality option go from 0-10000
            aviOptions.dwQuality = 5000;

            //change aviOptions to "true" to enable the popup window asking for codec options eg. aviStream = aviManager.AddVideoStream(true, 4, b);
            aviStream = aviManager.AddVideoStream(aviOptions, 4, b);

            Bitmap tempBmp;
            
            while (!pause)
            {
                tempBmp = new Bitmap(ScreenWidth, ScreenHeight);
                g = Graphics.FromImage(tempBmp);
                g.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);
   
                currentPoint.X = random.Next(0, ScreenWidth);
                currentPoint.Y = random.Next(0, ScreenHeight);
                g.FillEllipse(fillBrush, currentPoint.X, currentPoint.Y, 10, 10);



                if (tempBmp != null)
                {
                    aviStream.AddFrame(tempBmp);
                }
              //  tempBmp.Save("pics/test"+count+".png", ImageFormat.Png);
                tempBmp.Dispose();
                Thread.Sleep(1);
                Console.WriteLine(count + "Thread sleeping");
             
                count++;
            }
            aviManager.Close();
           // Console.WriteLine("Closed AVIStream");
          //  aviManager.Close();   
            
        }
        public void stopRecording()
        {
            pause = true;

       
           // aviStream.Close();
        }
    }
}
