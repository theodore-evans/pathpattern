using System;
using System.Numerics;

namespace PathPattern
{
    public class Program
    {
        public static int Main(string []args)
        {
            if (args.Length < 6) {
                Console.WriteLine("Please enter valid numerical arguments for regionSize, nodeRadiusMean, nodeRadiusStddev, nodeDensity, clusteringCoefficient, filepath.");
                return 1;
            }

            float imageSize = float.Parse(args[0]);
            float nodeRadiusMean = float.Parse(args[1]);
            float nodeRadiusStddev = float.Parse(args[2]);
            float nodeDensity = float.Parse(args[3]);
            float clusteringCoefficient = float.Parse(args[4]);
            string filename = args[5];

            PatternGenerator generator = new PatternGenerator(new Vector2(imageSize, imageSize), nodeRadiusMean, nodeRadiusStddev, nodeDensity, clusteringCoefficient);

            KandinskyPattern pattern = generator.Generate();

            (new DrawPattern()).DrawToFile(pattern, filename);

            return 0;
        }
    }
}
