using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Persons
{
    class JsonImporterExporter : ImporterExporter
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<Person>));
        public override void Read(List<Person> context, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamWriter writer = new StreamWriter(filename);
            JsonSerializer.WriteObject(writer.BaseStream, context);
            writer.Close();
        }
        public override void Write(List<MatchPair> context, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamReader reader = new StreamReader(filename);
            List<MatchPair> data = JsonSerializer.ReadObject(reader.BaseStream) as List<MatchPair>;
            if (data != null)
            {
                foreach (MatchPair thing in data)
                    context.Add(thing);
            }
        }
        
    }
}
