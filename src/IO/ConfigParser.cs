using System;
using System.IO;
using Newtonsoft.Json;

namespace PathPattern
{
    internal class ConfigParser<T>
    {
        public ConfigParser()
        {
        }

        internal T Parse(string configFilepath)
        {
            using StreamReader file = File.OpenText(configFilepath);
            JsonSerializer serializer = new JsonSerializer();
            T data = (T)serializer.Deserialize(file, typeof(T));

            return data;
        }
    }
}