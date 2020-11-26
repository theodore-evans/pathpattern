using System;

namespace PathPattern
{

    public class NormallyDistributedRadii : IRadiusGenerator
    {
        float radiusMean;
        float radiusStddev;
        System.Random prng;

        public NormallyDistributedRadii(PatternData patternData)
        {
            prng = new System.Random();
            radiusMean = patternData.nodeRadiusMean;
            radiusStddev = patternData.nodeRadiusStddev;
        }

        public float Radius()
        {
            float radius;
            do {
                radius = SampleGaussian.Next(prng, radiusMean, radiusStddev);
            } while (radius <= 0);

            return radius;
        }
    }
}