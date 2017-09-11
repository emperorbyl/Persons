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
            StreamWriter writer = new StreamWriter(filename);
            XmlSerializer.Serialize(writer, context);
            writer.Close();
        }
        public override void Write(List<MatchPair> context, string filename)
        {
            filename = AppendExtension(filename, "xml");
            StreamReader reader = new StreamReader(filename);
            List<MatchPair> data = XmlSerializer.Deserialize(reader.BaseStream) as List<MatchPair>;
            if (data != null)
            {
                foreach (MatchPair thing in data)
                    context.Add(thing);
            }
        }
    }
}
