using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ET_Project_GUI
{
    class ETSampleManager
    {
        //global vars      
        public ETController.SampleStruct etPositionData;
        private ETController ETDevice;
        
        //callback items
        private delegate void GetSampleCallback(ETController.SampleStruct sampleData);
        private GetSampleCallback m_SampleCallback;

        public ETSampleManager(ETController inETDevice)
        {
            ETDevice = inETDevice;
        }
        public void startDataFeedback()
        {  
            m_SampleCallback = new GetSampleCallback(GetSampleCallbackFunction);
            ETDevice.iV_SetSampleCallback(m_SampleCallback);
        }
        //This function is called everytime new data is sent
        public virtual void GetSampleCallbackFunction(ETController.SampleStruct sampleData)
        {
            etPositionData = sampleData;
            
            //do something here (this method should be overridden in your code see ExampleDataUpdate.cs)   
        }
    }
}
