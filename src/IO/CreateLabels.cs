using System;
using System.IO;
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

            using (StreamWriter sw = new StreamWriter(labelsFilepath))
            using (JsonWriter writer = new JsonTextWriter(sw)) {
                serializer.Serialize(writer, batch);
            }
        }
    }
}