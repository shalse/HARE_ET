using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.DB_Interface
{
    class MazeORM
    {
        public int Collisions { get; set; }
        public int Difficulty { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop  { get; set; }
        public readonly int GameId = 1;

        public MazeORM(IDictionary<string, string> data)
        {
            Collisions = Convert.ToInt32(data["wallBumps"]);
            Difficulty = Convert.ToInt32(data["difficulty"]);
            Start = Convert.ToDateTime(data["begin"]);
            Stop = Convert.ToDateTime(data["end"]);
        }

    }
}
