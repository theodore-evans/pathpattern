using System;
using System.Numerics;

namespace PathPattern
{
    public class PatternData
    {
        public Vector2 RegionSize { get; }

        public float NodeRadiusMean { get; }
        public float NodeRadiusStddev { get; }
        public float NodeDensity { get; }
        public float ClusteringCoefficient { get; }

        float minRadiusMean = 15f;
        float maxRadiusMean = 35f;

        float minNodeDensity = 0.5f;
        float maxNodeDenstity = 0.95f;

        float maxStddevFractionOfMean = 0.33f;

        public PatternData(Vector2 regionSize, float nodeRadiusMean, float nodeRadiusStddev, float nodeDensity, float clusteringCoefficient)
        {
            this.RegionSize = new Vector2(Math.Max(regionSize.X, 1), Math.Max(regionSize.Y, 1));
            this.NodeRadiusMean = Math.Clamp(nodeRadiusMean, minRadiusMean, maxRadiusMean);
            this.NodeRadiusStddev = Math.Clamp(nodeRadiusStddev, 0, this.NodeRadiusMean * maxStddevFractionOfMean);
            this.NodeDensity = Math.Clamp(nodeDensity, minNodeDensity, maxNodeDenstity);
            this.ClusteringCoefficient = Math.Clamp(clusteringCoefficient, 0f, 1f);
        }

        internal string InfoToString()
        {
            return $"{RegionSize.X}_{RegionSize.Y}_{NodeRadiusMean:D2}_{NodeRadiusStddev:D2}_{NodeDensity:D2}_{ClusteringCoefficient:D2}";
        }
    }
}
