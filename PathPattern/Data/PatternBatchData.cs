namespace PathPattern
{
    internal class PatternBatchData
    {
        public float ImageSize { get; }

        public float RadiusMeanDistMean { get; }
        public float RadiusMeanDistStddev { get; }

        public float RadiusStddevDistMean { get; }
        public float RadiusStddevDistStddev { get; }

        public float NodeDensityDistMean { get; }
        public float NodeDensityDistStddev { get; }

        public float ClusteringDistMean { get; }
        public float ClusteringDistStddev { get; }
    }
}