using System;
using System.Numerics;

namespace PathPattern
{
    internal class PatternBatchGenerator
    {
        private Vector2 regionSize;
        private PatternBatchData batchData;
        private int numberOfPatterns;

        public PatternBatchGenerator(PatternBatchData batchData, int numberOfPatterns)
        {
            regionSize = new Vector2(batchData.ImageSize, batchData.ImageSize);

            this.batchData = batchData;
            this.numberOfPatterns = numberOfPatterns;
        }

        internal KandinskyBatch Generate()
        {
            KandinskyPattern[] patterns = new KandinskyPattern[numberOfPatterns];

            Random prng = new Random();

            for (int i = 0; i < numberOfPatterns; i++) {
                float radiusMean = SampleGaussian.Next(prng, batchData.RadiusMeanDistMean, batchData.RadiusMeanDistStddev);
                float radiusStddev = SampleGaussian.Next(prng, batchData.RadiusStddevDistMean, batchData.RadiusStddevDistStddev);
                float nodeDensity = SampleGaussian.Next(prng, batchData.NodeDensityDistMean, batchData.NodeDensityDistStddev);
                float clustering = SampleGaussian.Next(prng, batchData.ClusteringDistMean, batchData.ClusteringDistStddev);

                PatternData patternData = new PatternData(regionSize, radiusMean, radiusStddev, nodeDensity, clustering);
                patterns[i] = new PatternGenerator(patternData).Generate();
            }

            return new KandinskyBatch(patterns);
        }
    }
}