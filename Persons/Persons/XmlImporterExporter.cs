using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Persons
{
    class XmlImporterExporter : ImporterExporter
    {
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<Person>));
        public override void Read(List<Person> context, string filename)
        {
            filename = AppendExtension(filename, "xml");
            StreamReader reader = new StreamReader(filename);
            List<Person> data = XmlSerializer.Deserialize(reader.BaseStream) as List<Person>;
            if (data != null)
            {
                foreach (Person thing in data)
                    context.Add(thing);
            }
            
        }
        public override void Write(List<MatchPair> context, string filename, string outputFile = null)
        {
            filename = AppendExtension(filename, "xml");
            StreamWriter writer = new StreamWriter(filename);
            XmlSerializer.Serialize(writer, context);
            writer.Close();
        }
    }
}
