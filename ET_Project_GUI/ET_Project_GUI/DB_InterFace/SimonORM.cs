using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.DB_Interface
{
    class SimonORM
    {
        public int IncrementLevel { get; set; }
        public int Level_1_Fail { get; set; }
        public DateTime Level_1_Fail_Time { get; set; }
        public int Level_2_Fail { get; set; }
        public DateTime Level_2_Fail_Time { get; set; }
        public int Level_3_Fail { get; set; }
        public DateTime Level_3_Fail_Time { get; set; }
        public bool Color { get; set; }
        public bool Position { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public readonly int GameId = 2;

        public SimonORM(IDictionary<string, string> data)
        {
            IncrementLevel = Convert.ToInt32(data["incr"]);
            Level_1_Fail = Convert.ToInt32(data["faillevel1"]);
            Level_1_Fail_Time = Convert.ToDateTime(data["failTime1"]);
            Level_2_Fail = Convert.ToInt32(data["faillevel2"]);
            Level_2_Fail_Time = Convert.ToDateTime(data["failTime2"]);
            Level_3_Fail = Convert.ToInt32(data["faillevel3"]);
            Level_3_Fail_Time = Convert.ToDateTime(data["failTime3"]);
            Color = Convert.ToBoolean(data["color"]);
            Position = Convert.ToBoolean(data["position"]);
            Start = Convert.ToDateTime(data["begin"]);
            Stop = Convert.ToDateTime(data["end"]);
        }
    }
}
