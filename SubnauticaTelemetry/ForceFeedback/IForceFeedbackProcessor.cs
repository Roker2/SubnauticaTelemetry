using System.Collections.Generic;

namespace SubnauticaTelemetry.ForceFeedback
{
    public interface IForceFeedbackProcessor
    {
        /// <summary>
        /// FF events processing implementation for your device
        /// </summary>
        /// <param name="ffevents"></param>
        void ProcessEvents(ForceFeedbackEvent[] ffevents);
        /// <summary>
        /// FF events processing implementation for your device
        /// </summary>
        /// <param name="ffevents"></param>
        void ProcessEvents(List<ForceFeedbackEvent> ffevents);
        /// <summary>
        /// FF event processing implementation for your device
        /// </summary>
        /// <param name="ffevent"></param>
        void ProcessEvent(ForceFeedbackEvent ffevent);
        void StopAllEvents();
    }
}
