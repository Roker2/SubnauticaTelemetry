using System.Collections.Generic;

namespace SubnauticaTelemetry.ForceFeedback
{
    public interface IForceFeedbackProcessor
    {
        void ProcessEvents(ForceFeedbackEvent[] ffevents);
        void ProcessEvents(List<ForceFeedbackEvent> ffevents);
        void ProcessEvent(ForceFeedbackEvent ffevent);
        void StopAllEvents();
    }
}
