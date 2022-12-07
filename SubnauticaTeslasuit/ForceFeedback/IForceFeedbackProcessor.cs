namespace SubnauticaTeslasuit.ForceFeedback
{
    interface IForceFeedbackProcessor
    {
        void ProcessEvents(ForceFeedbackEvent[] ffevents);
        void ProcessEvent(ForceFeedbackEvent ffevent);
    }
}
