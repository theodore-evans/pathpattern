using System;
using System.Numerics;

namespace PathPattern
{
    public class PatternGenerator
    {
        PatternData patternData;

        public PatternGenerator(Vector2 regionSize, float nodeRadiusMean, float nodeRadiusStddev, float nodeDensity, float clusteringCoefficient)
        {
            patternData = new PatternData(regionSize, nodeRadiusMean, nodeRadiusStddev, nodeDensity, clusteringCoefficient);
        }

        public PatternGenerator(PatternData patternData)
        {
            this.patternData = patternData;
        }

        public KandinskyPattern Generate()
        {
            IPatternGenerator positionGenerator = new PoissonDiscSampling();
            IRadiusGenerator radiusGenerator = new NormallyDistributedRadii(patternData);
            IPatternBehaviour[] patternBehaviours = new IPatternBehaviour[]{
                new Clustering(patternData)
            };

            return new KandinskyPattern(patternData, positionGenerator, radiusGenerator, patternBehaviours);
        }
    }
}