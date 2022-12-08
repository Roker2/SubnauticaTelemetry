using System.Collections.Generic;

namespace SubnauticaTeslasuit.ForceFeedback
{
    interface IForceFeedbackProcessor
    {
        void ProcessEvents(ForceFeedbackEvent[] ffevents);
        void ProcessEvents(List<ForceFeedbackEvent> ffevents);
        void ProcessEvent(ForceFeedbackEvent ffevent);
        void StopAllEvents();
    }
}
