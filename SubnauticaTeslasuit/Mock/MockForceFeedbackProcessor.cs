using SubnauticaTeslasuit.ForceFeedback;
using System.Collections.Generic;
using System.IO;

namespace SubnauticaTeslasuit.Mock
{
    class MockForceFeedbackProcessor : IForceFeedbackProcessor
    {
        private string LogFileName = "log.txt";

        public MockForceFeedbackProcessor()
        {
            FileInfo fileInfo = new FileInfo(LogFileName);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }

        public void ProcessEvent(ForceFeedbackEvent ffevent)
        {
            using (StreamWriter writetext = new StreamWriter(LogFileName, true))
            {
                writetext.WriteLine(ffevent.ToString());
            }
        }

        public void ProcessEvents(ForceFeedbackEvent[] ffevents)
        {
            foreach (var ffevent in ffevents)
            {
                ProcessEvent(ffevent);
            }
        }

        public void ProcessEvents(List<ForceFeedbackEvent> ffevents)
        {
            foreach (var ffevent in ffevents)
            {
                ProcessEvent(ffevent);
            }
        }

        public void StopAllEvents()
        {
            using (StreamWriter writetext = new StreamWriter(LogFileName, true))
            {
                writetext.WriteLine("Stop all events");
            }
        }
    }
}
