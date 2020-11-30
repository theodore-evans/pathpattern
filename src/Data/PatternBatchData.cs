namespace PathPattern
{
    public class PatternBatchData
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

        public PatternBatchData(float imageSize,
                                float radiusMeanDistMean,
                                float radiusMeanDistStddev,
                                float radiusStddevDistMean,
                                float radiusStddevDistStddev,
                                float nodeDensityDistMean,
                                float nodeDensityDistStddev,
                                float clusteringDistMean,
                                float clusteringDistStddev)
        {
            ImageSize = imageSize;
            RadiusMeanDistMean = radiusMeanDistMean;
            RadiusMeanDistStddev = radiusMeanDistStddev;
            RadiusStddevDistMean = radiusStddevDistMean;
            RadiusStddevDistStddev = radiusStddevDistStddev;
            NodeDensityDistMean = nodeDensityDistMean;
            NodeDensityDistStddev = nodeDensityDistStddev;
            ClusteringDistMean = clusteringDistMean;
            ClusteringDistStddev = clusteringDistStddev;
        }  
    }
}