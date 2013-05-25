using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace ET_Project_GUI.Testing
{
    class RandomPointGenerator
    {
        Random random = new Random();
        public Point getPoint(int maxWidth, int maxHeight)
        {
            int xLoc = random.Next(0, maxWidth);
            int yLoc = random.Next(0, maxHeight);
            return new Point(xLoc, yLoc);
        }
    }
}
