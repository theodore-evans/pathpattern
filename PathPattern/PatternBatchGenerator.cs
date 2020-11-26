namespace PathPattern
{
    internal class PatternBatchGenerator
    {
        private float imageSize;
        private PatternBatchData distributionData;
        private string imageDirectory;

        public PatternBatchGenerator(float imageSize, PatternBatchData distributionData, string imageDirectory)
        {
            this.imageSize = imageSize;
            this.distributionData = distributionData;
            this.imageDirectory = imageDirectory;
        }


    }
}