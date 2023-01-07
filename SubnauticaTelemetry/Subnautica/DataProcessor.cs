using HarmonyLib;
using SubnauticaTelemetry.ForceFeedback;
using SubnauticaTelemetry.Subnautica;
using System.Collections.Generic;

namespace SubnauticaTelemetry.Subnautica
{
    class DataProcessor
    {
        public bool Running { get; set; } = true;
        List<IForceFeedbackProcessor> Processors = new List<IForceFeedbackProcessor>();
        const int maxFoodWaterWarningLevel = 3;

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

        public void ProcessOxygenLevel(float level)
        {
            if (!Running)
                return;
            if (!Main.Config.enableNoOxygen)
                return;
            if (level > 0.0f)
                return;
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.NoOxygen, 1.0f, true));
        }

        public void ProcessFoodLevel(float foodLevel, float prevFoodLevel)
        {
            if (!Running)
                return;
            int warningLevel = calculateFoodAndWaterWarningLevel(foodLevel, prevFoodLevel, Consts.LowFoodThreshold, Consts.CriticalFoodThreshold);
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.NoFood, warningLevel / maxFoodWaterWarningLevel, false));
        }

        public void ProcessWaterLevel(float waterLevel, float prevWaterLevel)
        {
            if (!Running)
                return;
            int warningLevel = calculateFoodAndWaterWarningLevel(waterLevel, prevWaterLevel, Consts.LowWaterThreshold, Consts.CriticalWaterThreshold);
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.NoWater, warningLevel / maxFoodWaterWarningLevel, false));
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

        private int calculateFoodAndWaterWarningLevel(float statVal, float prevStatVal,
            float lowThreshold, float criticalThreshold)
        {
            int warningLevel = 0;
            if (statVal <= 0f && prevStatVal > 0f)
            {
                warningLevel = 3;
            }
            else if (statVal < criticalThreshold && prevStatVal >= criticalThreshold)
            {
                warningLevel = 2;
            }
            else if (statVal < lowThreshold && prevStatVal >= lowThreshold)
            {
                warningLevel = 1;
            }
            return warningLevel;
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
