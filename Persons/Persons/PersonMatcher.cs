using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class PersonMatcher
    {
        public List<Person> personList;
        public List<MatchPair> matchList;
        public ImporterExporter importExport;
        public string filename { get; set; }
        public string algorithmName { get; set; }
        public string outputFile { get; set; }
        public void Write()
        {
            importExport?.Write(matchList, filename);
        }

        public void Read()
        {
            importExport?.Read(personList, filename);
        }

    }
}
