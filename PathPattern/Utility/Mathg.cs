using System;
namespace PathPattern
{
    public static class Mathg
    {
        public static float Lerp(float a, float b, float t)
        {
            return a * (1-t) + b * t;
        }
    }
}
