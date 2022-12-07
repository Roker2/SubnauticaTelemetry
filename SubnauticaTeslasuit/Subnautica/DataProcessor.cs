namespace SubnauticaTeslasuit.Subnautica
{
    class DataProcessor
    {
        public void ProcessPlayerDepth(float depth)
        {
            depth = Normalize(depth, Consts.MinOceanDepth, Consts.MaxOceanDepth);
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
