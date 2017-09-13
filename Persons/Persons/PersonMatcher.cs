using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class PersonMatcher
    {
        public List<Person> personList = new List<Person>();
        public List<MatchPair> matchList = new List<MatchPair>();
        public ImporterExporter importExport;
        public string filename { get; set; }
        public string algorithmName { get; set; }
        public string outputFile { get; set; }
        public void Write()
        {
            importExport?.Write(matchList, outputFile);
        }

        public void Read()
        {
            importExport?.Read(personList, filename);
        }

    }
}
