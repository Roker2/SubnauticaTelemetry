using SubnauticaTeslasuit.ForceFeedback;
using System.Collections.Generic;
using Logger = QModManager.Utility.Logger;

namespace SubnauticaTeslasuit.Mock
{
    class MockForceFeedbackProcessor : IForceFeedbackProcessor
    {
        public void ProcessEvent(ForceFeedbackEvent ffevent)
        {
            Logger.Log(Logger.Level.Info, ffevent.ToString());
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
            Logger.Log(Logger.Level.Info, "Stop all events");
        }
    }
}
