namespace PathPattern
{
    internal class KandinskyBatch
    {
        public KandinskyPattern[] Patterns { get; }

        public KandinskyBatch(KandinskyPattern[] patterns)
        {
            Patterns = patterns;
        }

        public KandinskyPattern this[int index]
        {
            get => Patterns[index];
        }

        public int Length => Patterns.Length;
    }
}