using System;
using System.Numerics;
using Newtonsoft.Json;

namespace PathPattern
{
    public class PatternData
    {
        [JsonIgnore]
        public Vector2 RegionSize { get; }

        public float NodeRadiusMean { get; }
        public float NodeRadiusStddev { get; }
        public float NodeDensity { get; }
        public float ClusteringCoefficient { get; }

        readonly float minRadiusMean = 15f;
        readonly float maxRadiusMean = 35f;

        readonly float minNodeDensity = 0.5f;
        readonly float maxNodeDenstity = 0.95f;

        readonly float maxStddevFractionOfMean = 0.33f;

        public PatternData(Vector2 regionSize, float nodeRadiusMean, float nodeRadiusStddev, float nodeDensity, float clusteringCoefficient)
        {
            this.RegionSize = new Vector2(Math.Max(regionSize.X, 1), Math.Max(regionSize.Y, 1));
            this.NodeRadiusMean = Math.Clamp(nodeRadiusMean, minRadiusMean, maxRadiusMean);
            this.NodeRadiusStddev = Math.Clamp(nodeRadiusStddev, 0, this.NodeRadiusMean * maxStddevFractionOfMean);
            this.NodeDensity = Math.Clamp(nodeDensity, minNodeDensity, maxNodeDenstity);
            this.ClusteringCoefficient = Math.Clamp(clusteringCoefficient, 0f, 1f);
        }

        public override string ToString()
        {
            return $"{RegionSize.X}_{RegionSize.Y}_{NodeRadiusMean:F2}_{NodeRadiusStddev:F2}_{NodeDensity:F2}_{ClusteringCoefficient:F2}";
        }
    }
}
