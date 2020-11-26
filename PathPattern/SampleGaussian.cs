using System;
namespace PathPattern
{
    public static class SampleGaussian
    {
        public static float Next(Random random, float mean, float stddev)
        {
            // The method requires sampling from a uniform random of (0,1]
            // but Random.NextDouble() returns a sample of [0,1).
            double x1 = 1 - random.NextDouble();
            double x2 = 1 - random.NextDouble();

            double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
            return (float)y1 * stddev + mean;
        }
    }
}