using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_UI.Interfaces
{
    interface SetupInterface
    {
        void connect();
        void disconnect();
        void calibrate();
        void validate();
        void showAccuracy();
        //etc, this will contain all the setup functionality
    }
}
