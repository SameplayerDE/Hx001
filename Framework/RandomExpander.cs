using System;

namespace Hx001.Framework
{
    public static class RandomExpander
    {

        public static double NextDouble(this Random random, double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        public static float NextSingle(this Random random, float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }

    }
}