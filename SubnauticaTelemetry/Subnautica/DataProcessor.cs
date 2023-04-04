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
            if (depth == 0f)
                return;
            float depthPrecent = CalculateDepthPrecent(depth);
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.WaterPressure, depthPrecent));
        }

        public void ProcessOxygenLevel(float availableOxygenLevel)
        {
            if (!Running)
                return;
            if (!SubnauticaTelemetryPlugin.Config.enableNoOxygenEffect)
                return;
            if (availableOxygenLevel == 0f)
                SendEvent(new ForceFeedbackEvent(ForceFeedbackType.NoOxygen, 1f));
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
            SendEvent(new ForceFeedbackEvent(ForceFeedbackType.Damage, damageInfo.damage / Consts.MaxPlayerHealthLevel, damageInfo.position));
        }

        /// <summary>
        /// Add FF processor for receiving FF events 
        /// </summary>
        /// <param name="processor"></param>
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
            {
                float multiplier = 0f;
                if (level < lowThreshold && prevLevel > lowThreshold)
                    multiplier = 1f - lowThreshold / 100f;
                else if (level < criticalThreshold && prevLevel > criticalThreshold)
                    multiplier = 1f - criticalThreshold / 100f;
                else if (level == 0f)
                    multiplier = 1f;

                if (multiplier != 0f)
                    SendEvent(new ForceFeedbackEvent(forceFeedbackType, multiplier));
            }
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
