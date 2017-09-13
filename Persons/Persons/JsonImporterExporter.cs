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
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<Person>),new[] { typeof(Person)});
        public override void Read(List<Person> context, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamReader reader = new StreamReader(filename);
            List<Person> data = JsonSerializer.ReadObject(reader.BaseStream) as List<Person>;
            if (data != null)
            {
                foreach (Person thing in data)
                    context.Add(thing);
            }

        }
        public override void Write(List<MatchPair> context, string filename)
        {
            
            StreamWriter writer = new StreamWriter(filename);
            foreach (var match in context)
                writer.WriteLine(match.personA.ObjectId + "," + match.personB.ObjectId + "\n");
            writer.Close();
        }
        
    }
}
