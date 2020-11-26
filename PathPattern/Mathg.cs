using System;
namespace PathPattern_exec
{
    public static class Mathg
    {
        public static float Lerp(float a, float b, float t)
        {
            return a * t + b * (1 - t);
        }
    }
}
