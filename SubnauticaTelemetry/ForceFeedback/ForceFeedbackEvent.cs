using UnityEngine;

namespace SubnauticaTelemetry.ForceFeedback
{
    public struct ForceFeedbackEvent
    {
        public ForceFeedbackType Type;
        public float Multiplier;
        public Vector3 Position;

        public ForceFeedbackEvent(ForceFeedbackType type, float multiplier, Vector3 position = new Vector3())
        {
            Type = type;
            Multiplier = multiplier;
            Position = position;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Multiplier: {Multiplier}, Direction: {Position}";
        }
    }
}
