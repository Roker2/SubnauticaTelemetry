using UnityEngine;

namespace SubnauticaTelemetry.ForceFeedback
{
    public struct ForceFeedbackEvent
    {
        /// <summary>
        /// Type of event
        /// </summary>
        public ForceFeedbackType Type;
        /// <summary>
        /// Power of event
        /// </summary>
        public float Multiplier;
        /// <summary>
        /// Position of event trigger, it can be (0, 0, 0) for some events
        /// </summary>
        public Vector3 Position;

        public ForceFeedbackEvent(ForceFeedbackType type, float multiplier = 1f, Vector3 position = new Vector3())
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
