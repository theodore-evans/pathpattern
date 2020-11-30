namespace PathPattern
{
    internal class KandinskyBatch
    {
        public PatternBatchData BatchData { get; }
        public KandinskyPattern[] Patterns { get; }
        public int Length => Patterns.Length;

        public KandinskyBatch(KandinskyPattern[] patterns, PatternBatchData batchData)
        {
            Patterns = patterns;
            BatchData = batchData;
        }

        public KandinskyPattern this[int index]
        {
            get => Patterns[index];
        }
    }
}