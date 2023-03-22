using UnityEngine;

namespace SubnauticaTelemetry.ForceFeedback
{
    public struct ForceFeedbackEvent
    {
        public ForceFeedbackType Type;
        public float Multiplier;
        public bool Replay;
        public Vector3 Position;

        public ForceFeedbackEvent(ForceFeedbackType type, float multiplier, bool replay, Vector3 position = new Vector3())
        {
            Type = type;
            Multiplier = multiplier;
            Replay = replay;
            Position = position;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Multiplier: {Multiplier}, Replay: {Replay}, Direction: {Position}";
        }
    }
}
