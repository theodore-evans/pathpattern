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
                string filepath = args[6];

                PatternGenerator generator = new PatternGenerator(new Vector2(imageSize, imageSize), nodeRadiusMean, nodeRadiusStddev, nodeDensity, clusteringCoefficient);
                KandinskyPattern pattern = generator.Generate();

                new DrawPattern().DrawPatternToFile(pattern, filepath);

                return 0;
            }

            else if (args.Length > 0 && args[0] == "batch") {

                if (args.Length < 4) {
                    Console.WriteLine("Please enter valid arguments for: configFilePath, numberOfPatterns, imageDirectory.");
                    return 1;
                }

                string configFilepath = Path.Combine(Directory.GetCurrentDirectory(), args[1]);
                int numberOfPatterns = int.Parse(args[2]);
                string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), args[3]);

                Directory.CreateDirectory(imageDirectory);

                PatternBatchData distributionData = new ConfigParser<PatternBatchData>().Parse(configFilepath);
                KandinskyBatch batch = new PatternBatchGenerator(distributionData, numberOfPatterns).Generate();

                new DrawPattern().DrawBatchToFile(batch, imageDirectory);
                new CreateLabels().SaveBatchLabelsToFile(batch, imageDirectory);
            }

            else {
                Console.WriteLine("Please enter a valid generation modes from: single, batch");
            }

            return 1;
        }
    }
}
