using System;
using System.Collections.Generic;
using System.Numerics;

namespace PathPattern
{
    public interface IPatternGenerator
    {
        List<(Vector2, float)> GeneratePoints(float meanRadius, Func<float> radius, float spacing, Vector2 sampleRegionSize);
    }
}