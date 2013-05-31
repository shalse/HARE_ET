using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AviFile;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace ET_Project_GUI
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
        private string elapsedTime = "";

        //used for circle over lay
        private Brush fillBrush = new SolidBrush(ColorTranslator.FromHtml("#ff0000"));
        private Point currentPoint = new Point(0, 0);

        public void CaptureVideo()
        {
            b = new Bitmap(ScreenWidth, ScreenHeight);
            g = Graphics.FromImage(b);
            g.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);


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
                g.FillEllipse(fillBrush, currentPoint.X, currentPoint.Y, 10, 10);
                
                //g.DrawString(elapsedTime,new Font("Arial",12),new SolidBrush(Color.White),
                
                if (tempBmp != null)
                {
                    try
                    {
                        aviStream.AddFrame(tempBmp);
                    }
                    catch
                    {
                        Bitmap bmp2 = tempBmp;
                        tempBmp.Dispose();
                        tempBmp = new Bitmap((Image)bmp2);
                        aviStream.AddFrame(tempBmp);
                    }
                }
                tempBmp.Dispose();
                Thread.Sleep(100);
            }
            aviManager.Close();
        }
        public void startVideoTimer()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!pause)
            {
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value. 
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
            }
        }
        public void stopRecording()
        {
            pause = true;
        }
        public Point CurrentEyePosition
        {
            get { return currentPoint; }
            set { currentPoint = value; }
        }
    }
}
