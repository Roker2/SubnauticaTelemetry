using SubnauticaTelemetry.ForceFeedback;
using System.Collections.Generic;

namespace SubnauticaTelemetry.Subnautica
{
    class DataProcessor
    {
        public bool Running { get; set; } = true;
        private float prevFoodLevel = 0f;
        private float prevWaterLevel = 0f;
        List<IForceFeedbackProcessor> Processors = new List<IForceFeedbackProcessor>();

        public void ProcessPlayerDepth(float depth)
        {
            if (!Running)
                return;
            if (!SubnauticaTelemetryPlugin.Config.enableWaterPressureEffect)
                return;
            depth = Normalize(depth, Consts.MinOceanDepth, Consts.MaxOceanDepth);
            float depthPrecent = CalculateDepthPrecent(depth);
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.WaterPressure, depthPrecent, true));
        }

        public void ProcessOxygenLevel(float available)
        {
            if (!Running)
                return;
            if (!SubnauticaTelemetryPlugin.Config.enableNoOxygenEffect)
                return;
            if (available > 0.0f)
            {
                SendEvent(new ForceFeedbackEvent(ForceFeedbackType.NoOxygen, 0.0f, false));
                return;
            }
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.NoOxygen, 1.0f, true));
        }

        public void ProcessFoodLevel(float foodLevel)
        {
            if (!Running)
                return;
            ProcessHungerLevel(ForceFeedbackType.NoFood, SubnauticaTelemetryPlugin.Config.enableNoFoodEffect, Consts.LowFoodThreshold, Consts.CriticalFoodThreshold, foodLevel, ref prevFoodLevel);
        }

        public void ProcessWaterLevel(float waterLevel)
        {
            if (!Running)
                return;
            ProcessHungerLevel(ForceFeedbackType.NoWater, SubnauticaTelemetryPlugin.Config.enableNoWaterEffect, Consts.LowWaterThreshold, Consts.CriticalWaterThreshold, waterLevel, ref prevWaterLevel);
        }

        public void ProcessDamage(DamageInfo damageInfo)
        {
            if (!Running)
                return;
            if (!SubnauticaTelemetryPlugin.Config.enableDamageEffect)
                return;
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.Damage, damageInfo.damage / Consts.MaxPlayerHealthLevel, false, damageInfo.position));
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

        private void ProcessHungerLevel(ForceFeedbackType forceFeedbackType, bool enabled, float lowThreshold, float criticalThreshold, float level, ref float prevLevel)
        {
            if (enabled)
                return;
            if (prevLevel == 0f && level > 0f)
                SendEvent(new ForceFeedbackEvent(forceFeedbackType, 0f, false));
            else if (level < lowThreshold && prevFoodLevel > lowThreshold)
                SendEvent(new ForceFeedbackEvent(forceFeedbackType, 1f - lowThreshold / 100f, false));
            else if (level < criticalThreshold && prevFoodLevel > criticalThreshold)
                SendEvent(new ForceFeedbackEvent(forceFeedbackType, 1f - criticalThreshold / 100f, false));
            else if (level == 0f)
                SendEvent(new ForceFeedbackEvent(forceFeedbackType, 1f, true));
            prevLevel = level;
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
