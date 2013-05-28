using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ET_Project_GUI
{
    class ExampleDataUpdateClass : ETSampleManager
    {
        public ExampleDataUpdateClass(ETController ETDevice) : base(ETDevice)
        {
            base.startDataFeedback();
        }
        //ovverride the method like this to get a continuous strema of data
        public override void GetSampleCallbackFunction(ETController.SampleStruct data)
        {
            Console.WriteLine("New data recieved, do something: "+data.timestamp.ToString());
        }
    }

}
