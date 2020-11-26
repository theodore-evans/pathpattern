using System;
using System.Numerics;

namespace PathPattern
{
    public class PatternData
    {
        public Vector2 regionSize;

        public float nodeRadiusMean;
        public float nodeRadiusStddev;
        public float nodeDensity;
        public float clusteringCoefficient;

        float minRadiusMean = 15f;
        float maxRadiusMean = 25f;

        float minNodeDensity = 0.5f;
        float maxNodeDenstity = 0.95f;

        float maxStddevFractionOfMean = 0.33f;

        public PatternData(Vector2 regionSize, float nodeRadiusMean, float nodeRadiusStddev, float nodeDensity, float clusteringCoefficient)
        {
            this.regionSize = regionSize;
            this.nodeRadiusMean = nodeRadiusMean;
            this.nodeRadiusStddev = nodeRadiusStddev;
            this.nodeDensity = nodeDensity;
            this.clusteringCoefficient = clusteringCoefficient;

            if (this.nodeRadiusMean < minRadiusMean) this.nodeRadiusMean = minRadiusMean;
            if (this.nodeRadiusMean > maxRadiusMean) this.nodeRadiusMean = maxRadiusMean;
            float maxNodeRadiusStddev = this.nodeRadiusMean * maxStddevFractionOfMean;

            if (this.nodeDensity < minNodeDensity) this.nodeDensity = minNodeDensity;
            if (this.nodeDensity > maxNodeDenstity) this.nodeDensity = maxNodeDenstity;

            if (this.nodeRadiusStddev < 0) this.nodeRadiusStddev = 0;
            if (this.nodeRadiusStddev > maxNodeRadiusStddev) this.nodeRadiusStddev = maxNodeRadiusStddev;

            if (this.regionSize.X < 1) this.regionSize.X = 1;
            if (this.regionSize.Y < 1) this.regionSize.Y = 1;

            if (this.clusteringCoefficient < 0) this.clusteringCoefficient = 0;
        }
    }
}
