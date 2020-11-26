using System.Numerics;

namespace PathPattern
{
    internal class KandinskyNode
    {
        internal Vector2 center;
        internal float radius;

        public KandinskyNode(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }
    }
}