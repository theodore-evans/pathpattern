using System;
using System.Collections.Generic;
using System.Numerics;

namespace PathPattern
{
    public class Clustering : IPatternBehaviour
    {
        readonly float SQRT2 = 1.41f;
        float _clusteringRange;
        float _clusteringStrength;
        int _clusteringIterations = 15;
        float _clusteringCellsize;

        public Clustering(PatternData patternData)
        {
            _clusteringRange = (patternData.RegionSize.X + patternData.RegionSize.Y) / (20f * patternData.NodeDensity);
            _clusteringStrength = patternData.ClusteringCoefficient * (50f / _clusteringIterations) * _clusteringRange;
            _clusteringCellsize = _clusteringRange / SQRT2;
        }

        public void Mutate(KandinskyPattern pattern)
        {
            if (_clusteringStrength > 0) {
                for (int i = 0; i < _clusteringIterations; i++) {
                    foreach (KandinskyNode node in pattern.Nodes) {
                        foreach (KandinskyNode neighbour in pattern.Nodes) {
                            if (neighbour != node && IsWithinCell(node, neighbour)) {
                                Vector2 displacement = neighbour.center - node.center;
                                float sqrDistance = displacement.LengthSquared();
                                float sqrSeparation = SqrSeparation(node, neighbour);
                                float sqrRelativeSeparation = sqrSeparation / sqrDistance;
                                Vector2 equilibriumPosition = EquilibriumPosition(node, displacement, sqrRelativeSeparation);

                                if (sqrDistance < _clusteringRange * _clusteringRange) {
                                    node.center = Vector2.Lerp(node.center, equilibriumPosition, Math.Clamp(_clusteringStrength / sqrDistance, 0, 1));
                                }

                                if (sqrDistance < sqrSeparation) {
                                    node.center = equilibriumPosition;
                                }
                            }
                        }
                    }
                }

                foreach (KandinskyNode node in pattern.Nodes) {
                    foreach (KandinskyNode neighbour in pattern.Nodes) {
                        if (neighbour != node && IsWithinCell(node, neighbour)) {
                            Vector2 displacement = neighbour.center - node.center;
                            float sqrDistance = displacement.LengthSquared();
                            float sqrSeparation = SqrSeparation(node, neighbour);
                            if (sqrDistance < sqrSeparation) {
                                neighbour.center = Vector2.One * -999f;
                            }
                        }
                    }
                }
            }
        }

        float SqrSeparation(KandinskyNode node1, KandinskyNode node2)
        {
            float separation = node1.radius + node2.radius;
            return separation * separation;
        }


        private Vector2 EquilibriumPosition(KandinskyNode node, Vector2 displacement, float sqrRelativeSeparation)
        {
            return node.center + Math.Clamp(1 - sqrRelativeSeparation, 0, 1) * displacement;
        }

        bool IsWithinCell(KandinskyNode node, KandinskyNode candidate)
        {
            if (Math.Abs(candidate.center.X - node.center.X) < _clusteringCellsize || Math.Abs(candidate.center.Y - node.center.Y) < _clusteringCellsize) {
                return true;
            }
            else return false;
        }
    }
}