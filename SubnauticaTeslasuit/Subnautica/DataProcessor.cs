namespace SubnauticaTeslasuit.Subnautica
{
    class DataProcessor
    {
        private float MinPressureFrequenceMultiplier = 0.5f;
        private float MaxPressureFrequenceMultiplier = 1;
        public void ProcessPlayerDepth(float depth)
        {
            depth = Normalize(depth, Consts.MinOceanDepth, Consts.MaxOceanDepth);
            float pressureFrequenceMultiplier = CalculateFrequenceMultiplier(CalculateDepthPrecent(depth));
        }

        private float CalculateDepthPrecent(float depth)
        {
            return (depth - Consts.MinOceanDepth) / (Consts.MaxOceanDepth - Consts.MinOceanDepth);
        }

        private float CalculateFrequenceMultiplier(float depthPrecent)
        {
            return MinPressureFrequenceMultiplier + (MaxPressureFrequenceMultiplier - MinPressureFrequenceMultiplier) * depthPrecent;
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
