using System;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

namespace PathPattern
{
    public class KandinskyPattern
    {
        public PatternData PatternData { get; }

        public string Filename { get; private set; }
        public float Width { get; }
        public float Height { get; }

        private KandinskyNode[] _nodes;
        internal KandinskyNode[] Nodes { get => _nodes; }
        
        public KandinskyPattern(PatternData patternData, IPatternGenerator patternGenerator, IRadiusGenerator radiusGenerator, IPatternBehaviour[] patternBehaviours)
        {
            Width = patternData.RegionSize.X;
            Height = patternData.RegionSize.Y;

            this.PatternData = patternData;

            List<(Vector2, float)> nodes = patternGenerator.GeneratePoints(patternData.NodeRadiusMean, radiusGenerator.Radius, patternData.NodeDensity, patternData.RegionSize);
            _nodes = new KandinskyNode[nodes.Count];

            for (int i = 0; i < _nodes.Length; i++) {
                if (i < nodes.Count) {
                    _nodes[i] = new KandinskyNode(nodes[i].Item1, nodes[i].Item2);
                }
            }

            foreach (IPatternBehaviour patternBehaviour in patternBehaviours) {
                patternBehaviour.Mutate(this);
            }
        }

        public Tuple<float, float>[] Positions()
        {
            Tuple<float, float>[] positions = new Tuple<float, float>[_nodes.Length];
            for (int i = 0; i < _nodes.Length; i++) {
                positions[i] = new Tuple<float, float>(_nodes[i].center.X, _nodes[i].center.Y);
            }
            return positions;
        }

        public float[] Radii()
        {
            float[] radii = new float[_nodes.Length];
            for (int i = 0; i < _nodes.Length; i++) {
                radii[i] = _nodes[i].radius;
            }
            return radii;
        }

        internal void LinkToFile(string filename)
        {
            Filename = filename;
        }
    }
}