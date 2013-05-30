using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_GUI.Network
{
    class MessageFormater
    {
        public byte[] encodeMessage(string destination, string message)
        {
            //example of message structure "Origin (4 bytes)" + "size (4 bytes)" + "msg data (?? bytes)"
            //example !MAZ0027this is the example message"
            byte[] finalMessage = null;
            string msg = destination + message.Length.ToString("0000") + message;
            finalMessage = Encoding.ASCII.GetBytes(msg);
            return finalMessage;
        }
        public string decodeMessage(byte[] recievedBytes)
        {
            try
            {
                string fullMessage = Encoding.ASCII.GetString(recievedBytes);
                fullMessage = fullMessage.Trim('\0');
                string origin = fullMessage.Substring(0, 4);
                if (origin.Substring(0, 1) == "!" && fullMessage.Length > 8)
                {
                    //remove trailing byte code
                    int messageSize = int.Parse(fullMessage.Substring(4, 4));
                    string message = fullMessage.Substring(8, messageSize);

                    if (origin == "!KIL")
                    {
                        return "KILL";
                    }
                    else
                    {
                        return origin + message;
                    }

                }
                else if (origin.Length > 0)
                {
                    return fullMessage;
                }
                else
                {
                    //check we have a ! in front of message
                    return "";
                }
            }
            catch (Exception ex)
            {
                //report error
                return "";
            }
        }
    }

}
