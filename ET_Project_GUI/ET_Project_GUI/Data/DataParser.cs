using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.Data
{
    class DataParser
    {
        public Dictionary<string, string> storageTable;

        public string parseDataString(string inMessage)
        {
            try
            {
                storageTable = new Dictionary<string, string>();
                string origin = "";
                int messageSize = 0;
                string message = "";
                string tempString = "";
                if (inMessage.Length > 9 && inMessage.Substring(0, 1) == "!")
                {
                    Console.WriteLine("Message recieved: "+inMessage);
                    origin = inMessage.Substring(0, 4);
                    messageSize = int.Parse(inMessage.Substring(4, 5)) - 9;
                    message = inMessage.Substring(9, int.Parse(inMessage.Substring(4, 5)));
                    tempString = message;
                    int i = 0;
                    int previ = 0;

                    storageTable.Add("Game Type", origin);
                    //first part of message
                    if (tempString.IndexOf("?") != -1)
                    {
                        i = tempString.IndexOf("?");
                        Console.WriteLine("Begin Test: " + tempString.Substring(0, i));
                    }
                    //middle data points
                    while ((i = tempString.IndexOf("&", i)) != -1)
                    {
                        string[] workingString = tempString.Substring(previ + 1, i - previ - 1).Split('=');
                        storageTable.Add(workingString[0], workingString[1]);
                        Console.WriteLine("Test: " + workingString[0]);//tempString.Substring(i));
                        previ = i;
                        i++;
                    }
                    //last data point
                    if (tempString.Substring(previ + 1, tempString.Length - previ - 1).Contains('='))
                    {
                        string[] workingString = tempString.Substring(previ + 1, tempString.Length - previ - 1).Split('=');
                        storageTable.Add(workingString[0], workingString[1]);
                        Console.WriteLine("Test End: " + tempString.Substring(previ + 1, tempString.Length - previ - 1));
                    }
                    return "Success";
                }
                else
                {
                    return "Invalid message";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message string in incorrect format"+ ex.Message);
                return "Exception";
            }
        }
    }
}
