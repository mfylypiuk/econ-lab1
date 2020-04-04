using econ_lab1.Interfaces;
using IOData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace econ_lab1.Services
{
    class IOFileService : IFileService
    {
        public InputData Open(string filename)
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<InputData>(json);
        }

        public void Save(string filename, OutputData instance)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(instance, Formatting.Indented));
        }
    }
}
