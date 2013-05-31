using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.DB_Interface
{
    class EyeTrackerORM
    {
        public int GazeX { get; set; }
        public int GazeY { get; set; }
        public DateTime Time_Stamp { get; set; }
        public int GameId { get; set; }

        public EyeTrackerORM(int GazeX, int GazeY, DateTime Time_Stamp, int GameId)
        {
            this.GazeX = GazeX;
            this.GazeY = GazeY;
            this.Time_Stamp = Time_Stamp;
            this.GameId = GameId;
        }
    }
}
