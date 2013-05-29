using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.Network
{
    class MessageFormater
    {
        public byte[] encodeMessage(string origin, string message)
        {
            //example of message structure "Origin (4 bytes)" + "size (4 bytes)" + "msg data (?? bytes)"
            //example !MAZ0027this is the example message"
            byte[] finalMessage = null;
            string msg = origin + message.Length.ToString("0000") + message;
            finalMessage = Encoding.ASCII.GetBytes(msg);
            return finalMessage;
        }
        public void decodeMessage(byte[] recievedBytes)
        {
            string fullMessage = Encoding.ASCII.GetString(recievedBytes);

            string origin = fullMessage.Substring(0, 4);
            if (origin.Substring(0, 1) == "!")
            {
                int messageSize = int.Parse(fullMessage.Substring(4, 4));
                string message = fullMessage.Substring(8, messageSize);


                Console.WriteLine("Origin = " + origin);
                Console.WriteLine("messageSize = " + messageSize);
                Console.WriteLine("message = " + message);

                
            }
            else
            {
                Console.WriteLine("The Data has been corrupted");
            }
        }
    }

}
