﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ET_Project_UI
{
    class Logger
    {
        private StreamWriter writer; // Create a stream writer
        private StreamReader reader; // Create a stream reader
        private string fileName;
        public Logger(String inFileName)
        {
            fileName = inFileName;
        }  
        public void Write(String inString)
        {
            //open the log file
            openFile(); 
            
            // Writting into the file
            writer.WriteLine(DateTime.Now+"\t"+inString);
            writer.WriteLine();

            //close the log file
            writer.Close(); // Close the stream
        }
        private void openFile()
        {
            // check if the file exist
            if (!File.Exists(fileName)) 
            { 
                writer = new StreamWriter(fileName); //creat the file 
            }
            else
            {
                writer = File.AppendText(fileName); // append the text into the file
            }
        }
    }
}