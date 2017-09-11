using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class PersonMatcher
    {
        public MatchPair match;
        public ImporterExporter importExport;
        public string filename { get; set; }
        public string algorithmName { get; set; }
        public string outputFile { get; set; }
        
    }
}
