using System;
using System.IO;
using System.Numerics;

namespace PathPattern
{
    public class Program
    {
        public static int Main(string []args)
        {
            if (args.Length > 0 && args[0] == "single") {

                if (args.Length < 7) {
                    Console.WriteLine("Please enter valid numerical arguments for: imageSize, nodeRadiusMean, nodeRadiusStddev, nodeDensity, clusteringCoefficient, filepath.");
                    return 1;
                }

                float imageSize = float.Parse(args[1]);
                float nodeRadiusMean = float.Parse(args[2]);
                float nodeRadiusStddev = float.Parse(args[3]);
                float nodeDensity = float.Parse(args[4]);
                float clusteringCoefficient = float.Parse(args[5]);
                string filename = args[5];

                PatternGenerator generator = new PatternGenerator(new Vector2(imageSize, imageSize), nodeRadiusMean, nodeRadiusStddev, nodeDensity, clusteringCoefficient);
                KandinskyPattern pattern = generator.Generate();

                new DrawPattern().DrawPatternToFile(pattern, filename);

                return 0;
            }

            else if (args.Length > 0 && args[0] == "batch") {

                if (args.Length < 4) {
                    Console.WriteLine("Please enter valid numerical arguments for: imageSize, config.json, numberOfPatterns, image dir.");
                    return 1;
                }

                float imageSize = float.Parse(args[1]);
                string configFilepath = Path.Combine(Directory.GetCurrentDirectory(), args[2]);
                int numberOfPatterns = int.Parse(args[3]);
                string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), args[4]);

                PatternBatchData distributionData = new ConfigParser<PatternBatchData>().Parse(configFilepath);
                KandinskyPatternBatch batch = new PatternBatchGenerator(imageSize, distributionData, numberOfPatterns).Generate();

                new DrawPattern().DrawBatchToFile(batch, imageDirectory);
            }

            else {
                Console.WriteLine("Please enter a valid generation modes from: single, batch");
            }

            return 1;
        }
    }
}
