using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ET_Project_GUI.DB_Interface;
using System.Data.SqlServerCe;
using System.IO;
using System.Text;

namespace ET_Project_GUI.DB_Wrapper
{
    class DBWrapper
    {
        // This is gonna change :(
        private readonly string connectionStr = @"Data Source=AlphaDB.sdf";
        private SqlCeConnection connection;

        public DBWrapper()
        {
            connection = new SqlCeConnection(connectionStr);
           
        }

        public void AddEyeTrackerData(EyeTrackerORM eyeTracker)
        {
            connection.Open();
            string commandText = @"INSERT INTO EyeTracker (Gaze_X, Gaze_Y, Time_Stamp, GameId)
                            VALUES (@GazeX, @GazeY, @Time_Stamp, @GameId)";
            SqlCeCommand command = new SqlCeCommand(commandText, connection);
                command.Parameters.AddWithValue("@GazeX", eyeTracker.GazeX);
            command.Parameters.AddWithValue("@GazeY", eyeTracker.GazeY);
            command.Parameters.AddWithValue("@Time_Stamp", eyeTracker.Time_Stamp);
            command.Parameters.AddWithValue("@GameId", eyeTracker.GameId);
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            connection.Close();    
        }

        // It might be easier to put them in a list as they come in and just send that
        public void AddEyeTrackerData(IList<EyeTrackerORM> data)
        {
            foreach (var et in data)
            {
                AddEyeTrackerData(et);
            }
        }

        public void AddMazeData(MazeORM maze)
        {
            connection.Open();
            string commandText = @"INSERT INTO Maze (Collisions, Difficulty, Start, Stop, GameId)
                                VALUES (@Collisions, @Difficulty, @Start, @Stop, @GameId)";
            SqlCeCommand command = new SqlCeCommand(commandText, connection);
            command.Parameters.AddWithValue("@Collisions", maze.Collisions);
            command.Parameters.AddWithValue("@Difficulty", maze.Difficulty);
            command.Parameters.AddWithValue("@Start", maze.Start);
            command.Parameters.AddWithValue("@Stop", maze.Stop);
            command.Parameters.AddWithValue("@GameId", maze.GameId);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddSimonData(SimonORM simon)
        {
            connection.Open();
            string commandText = @"INSERT INTO Simon (Increment_Level, Level_1_Fail, Level_1_Fail_Time, Level_2_Fail, Level_2_Fail_Time, Level_3_Fail, Level_3_Fail_Time, Color, Position, Start, Stop, GameId)
                                VALUES (@Increment_Level, @Level_1_Fail, @Level_1_Fail_Time, @Level_2_Fail, @Level_2_Fail_Time, @Level_3_Fail, @Level_3_Fail_Time, @Color, @Position, @Start, @Stop, @GameId)";
            SqlCeCommand command = new SqlCeCommand(commandText, connection);
            command.Parameters.AddWithValue("@Increment_Level", simon.IncrementLevel);
            command.Parameters.AddWithValue("@Level_1_Fail", simon.Level_1_Fail);
            command.Parameters.AddWithValue("@Level_1_Fail_Time", simon.Level_1_Fail_Time);
            command.Parameters.AddWithValue("@Level_2_Fail", simon.Level_2_Fail);
            command.Parameters.AddWithValue("@Level_2_Fail_Time", simon.Level_2_Fail_Time);
            command.Parameters.AddWithValue("@Level_3_Fail", simon.Level_3_Fail);
            command.Parameters.AddWithValue("@Level_3_Fail_Time", simon.Level_3_Fail_Time);
            command.Parameters.AddWithValue("@Color", simon.Color);
            command.Parameters.AddWithValue("@Position", simon.Position);
            command.Parameters.AddWithValue("@Start", simon.Start);
            command.Parameters.AddWithValue("@Stop", simon.Stop);
            command.Parameters.AddWithValue("@GameId", simon.GameId);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ExportDataToCSV()
        {
            //export all talbes data
            connection.Open();
            
            string [] tables = {"EyeTracker", "Simon", "Maze"};
            for (int count = 0; count < 3; count++)
            {
                Console.WriteLine(""+tables[count]);
                string commandText = @"SELECT * FROM " + tables[count];
                SqlCeCommand cmd = new SqlCeCommand(commandText, connection);
                SqlCeDataReader rdr = cmd.ExecuteReader();

                TextWriter stream = new StreamWriter(new FileStream(tables[count]+"_Data.csv", FileMode.Create), Encoding.Default);
                for(int k = 0; k < rdr.FieldCount; k++)
                {
                    stream.Write(rdr.GetName(k));
                    stream.Write(",");
                }
                stream.Write(System.Environment.NewLine);
                
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount - 2; i++)
                    {
                        if (rdr[i] != null)
                        {
                            stream.Write(rdr[i].ToString());
                            stream.Write(",");
                        }
                        else
                        {
                            stream.Write(",");
                        }
                    }
                    if (rdr[rdr.FieldCount - 1] != null)
                    {
                        stream.Write(rdr[0].ToString());
                    }
                    stream.Write(System.Environment.NewLine);
                }
                stream.Close();
                rdr.Close();
                cmd.Dispose();
            }
            connection.Close();

        }
    }
}