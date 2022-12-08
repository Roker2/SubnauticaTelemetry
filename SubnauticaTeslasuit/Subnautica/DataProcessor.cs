using SubnauticaTeslasuit.ForceFeedback;
using System.Collections.Generic;

namespace SubnauticaTeslasuit.Subnautica
{
    class DataProcessor
    {
        List<IForceFeedbackProcessor> Processors = new List<IForceFeedbackProcessor>();
        public void ProcessPlayerDepth(float depth)
        {
            if (!Main.Config.enableWaterPressureEffect)
                return;
            depth = Normalize(depth, Consts.MinOceanDepth, Consts.MaxOceanDepth);
            float depthPrecent = CalculateDepthPrecent(depth);
            ForceFeedbackEvent forceFeedbackEvent = new ForceFeedbackEvent(ForceFeedbackType.WaterPressure, depthPrecent, true);
            foreach (var processor in Processors)
            {
                processor.ProcessEvent(forceFeedbackEvent);
            }
        }

        public void AddForceFeedbackProcessor(IForceFeedbackProcessor processor)
        {
            Processors.Add(processor);
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
