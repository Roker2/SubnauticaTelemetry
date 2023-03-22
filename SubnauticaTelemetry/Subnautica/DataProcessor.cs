using SubnauticaTelemetry.ForceFeedback;
using System.Collections.Generic;

namespace SubnauticaTelemetry.Subnautica
{
    class DataProcessor
    {
        public bool Running { get; set; } = true;
        List<IForceFeedbackProcessor> Processors = new List<IForceFeedbackProcessor>();

        public void ProcessPlayerDepth(float depth)
        {
            if (!Running)
                return;
            if (!Main.Config.enableWaterPressureEffect)
                return;
            depth = Normalize(depth, Consts.MinOceanDepth, Consts.MaxOceanDepth);
            float depthPrecent = CalculateDepthPrecent(depth);
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.WaterPressure, depthPrecent, true));
        }

        public void ProcessOxygenLevel(float available)
        {
            if (!Running)
                return;
            if (!Main.Config.enableNoOxygen)
                return;
            if (available > 0.0f)
                return;
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.NoOxygen, 1.0f, true));
        }

        public void ProcessDamage(DamageInfo damageInfo)
        {
            if (!Running)
                return;
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.Damage, damageInfo.damage / 100f, false, damageInfo.position));
        }

        public void AddForceFeedbackProcessor(IForceFeedbackProcessor processor)
        {
            Processors.Add(processor);
        }

        public void StopAllEvents()
        {
            foreach (var processor in Processors)
            {
                processor.StopAllEvents();
            }
        }

        private void SendEvent(ForceFeedbackEvent forceFeedbackEvent)
        {
            foreach (var processor in Processors)
            {
                processor.ProcessEvent(forceFeedbackEvent);
            }
        }

        private float CalculateDepthPrecent(float depth)
        {
            return (depth - Consts.MinOceanDepth) / (Consts.MaxOceanDepth - Consts.MinOceanDepth);
        }

        private float Normalize(float value, float min, float max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
    }
}
