using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PathPattern
{
    internal class CreateLabels
    {
        public CreateLabels()
        {
        }

        internal void SaveBatchLabelsToFile(KandinskyBatch batch, string imageDirectory)
        {
            JsonSerializer serializer = new JsonSerializer();
            string labelsFilepath = Path.Combine(imageDirectory, "labels.json");
            var refactoredBatch = new {
                BatchData = batch.BatchData,
                Patterns = batch.Patterns.ToDictionary(x => x.Filename, x => x)
            };
            using (StreamWriter sw = new StreamWriter(labelsFilepath))
            using (JsonWriter writer = new JsonTextWriter(sw)) {
                serializer.Serialize(writer, refactoredBatch);
            }
        }
    }
}