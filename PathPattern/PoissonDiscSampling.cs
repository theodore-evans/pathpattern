using System;
using System.Collections.Generic;
using System.Numerics;
using PathPattern_exec;

namespace PathPattern
{
	public class PoissonDiscSampling : IPatternGenerator
	{

		int _numSamplesBeforeRejection;
		readonly float SQRT2 = 1.41f;

		public PoissonDiscSampling(int numSamplesBeforeRejection = 20)
		{
			_numSamplesBeforeRejection = numSamplesBeforeRejection;
		}

		public List<(Vector2, float)> GeneratePoints(float meanRadius, Func<float> Radius, float density, Vector2 sampleRegionSize)
		{
			Random prng = new Random();

			float spacing = Mathg.Lerp(Math.Max(sampleRegionSize.X, sampleRegionSize.Y) / 4, meanRadius * 1.25f, density);
			float cellSize = spacing / SQRT2;

			int[,] grid = new int[(int)Math.Ceiling(sampleRegionSize.X / cellSize), (int)Math.Ceiling(sampleRegionSize.Y / cellSize)];

			List<(Vector2, float)> points = new List<(Vector2 position, float radius)>();
			List<(Vector2, float)> spawnPoints = new List<(Vector2 position, float radius)> {
				(sampleRegionSize / 2, Radius())
			};

			while (spawnPoints.Count > 0) {
				int spawnIndex = prng.Next(0, spawnPoints.Count);
				Vector2 spawnCentre = spawnPoints[spawnIndex].Item1;
				float spawnRadius = Radius();

				bool candidateAccepted = false;

				for (int i = 0; i < _numSamplesBeforeRejection; i++) {
					float angle = (float)prng.NextDouble() * (float)Math.PI * 2f;
					Vector2 dir = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));
					Vector2 candidatePosition = spawnCentre + dir * spacing * ( 1 + (float)prng.NextDouble() );
					if (IsValid(candidatePosition, sampleRegionSize, cellSize, spawnRadius, spacing, points, grid)) {
						points.Add((candidatePosition, spawnRadius));
						spawnPoints.Add((candidatePosition, spawnRadius));
						grid[(int)(candidatePosition.X / cellSize), (int)(candidatePosition.Y / cellSize)] = points.Count;
						candidateAccepted = true;
						break;
					}
				}
				if (!candidateAccepted) {
					spawnPoints.RemoveAt(spawnIndex);
				}
			}
			return points;
		}

		private bool IsValid(Vector2 candidatePosition, Vector2 sampleRegionSize, float cellSize, float radius, float spacing, List<(Vector2, float)> points, int[,] grid)
		{
			if (candidatePosition.X >= radius && candidatePosition.X < sampleRegionSize.X - radius && candidatePosition.Y >= radius && candidatePosition.Y < sampleRegionSize.Y - radius) {
				int cellX = (int)(candidatePosition.X / cellSize);
				int cellY = (int)(candidatePosition.Y / cellSize);
				int searchStartX = Math.Max(0, cellX - 2);
				int searchEndX = Math.Min(cellX + 2, grid.GetLength(0) - 1);
				int searchStartY = Math.Max(0, cellY - 2);
				int searchEndY = Math.Min(cellY + 2, grid.GetLength(1) - 1);

				for (int x = searchStartX; x <= searchEndX; x++) {
					for (int y = searchStartY; y <= searchEndY; y++) {
						int pointIndex = grid[x, y] - 1;
						if (pointIndex != -1) {
							float sqrDst = (candidatePosition - points[pointIndex].Item1).LengthSquared();
							float pairwiseSpacing = Math.Max(spacing, radius + points[pointIndex].Item2);
							if (sqrDst < pairwiseSpacing * pairwiseSpacing) {
								return false;
							}
						}
					}
				}
				return true;
			}
			return false;
		}
	}
}