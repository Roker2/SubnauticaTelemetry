namespace SubnauticaTeslasuit.ForceFeedback
{
    interface IForceFeedbackProcessor
    {
        void ProcessEvents(ForceFeedbackEvent[] events);
    }
}
