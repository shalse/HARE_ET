using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.Network
{
    class DataParser
    {
        public void parseDataString(string inMessage)
        {
            string origin = ""; 
            int messageSize = 0;
            string message = "";
            string tempString = "";
            if (inMessage.Length > 9 && inMessage.Substring(0,1) == "!")
            {
                origin = inMessage.Substring(0, 4);
                messageSize = int.Parse(inMessage.Substring(4,5))-9;
                message = inMessage.Substring(9, int.Parse(inMessage.Substring(4, 5)) - 9);
                tempString = message;
                int i = 0;
                int previ = 0;
                
                //first part of message
                if (tempString.IndexOf("?") != -1)
                {
                    i = tempString.IndexOf("?");
                    Console.WriteLine("Begin Test: "+tempString.Substring(0, i));
                }
                //middle data points
                while ((i = tempString.IndexOf("&", i)) != -1)
                {
                    Console.WriteLine("Test: "+tempString.Substring(previ,i-previ));//tempString.Substring(i));
                    previ = i;
                    i++;
                }
                //last data point
                Console.WriteLine("Test End: "+tempString.Substring(previ,tempString.Length-previ));
                
            }      
        }
    }
}
