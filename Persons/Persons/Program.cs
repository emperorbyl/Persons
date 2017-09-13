using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Program
    {
        private const string DefaultDataFilename = "../../SampleData";
        private static readonly ImporterExporter[] ImporterExporters = new ImporterExporter[]
                        {
                            new JsonImporterExporter() { name = "JSON", description  = "JavaScript Object Notation"},
                            new XmlImporterExporter() { name = "XML", description = "Extensible Markup Language"}
                        };
        public static void Main(string[] args)
        {
            ImporterExporter importerExporter = GetFileFormatFromUser();
            if (importerExporter == null)
                return;
            
            string dataFilename = args[1];
            string algorithm = args[0];
            if (string.IsNullOrWhiteSpace(dataFilename))
                return;

            // Create from sample gadgets and print them out
            PersonMatcher data1 = new PersonMatcher() { importExport = importerExporter, filename = dataFilename, algorithmName = algorithm };
            
            data1.importExport = importerExporter;
            data1.Read();
            bool method = false;
            foreach(var person in data1.personList)
            {
                foreach (var person1 in data1.personList)
                {
                    MatchPair match = new MatchPair(person1, person);
                    method = match.Match(algorithm, data1.personList, data1.matchList);
                }
            }
            if(method)
                data1.Write();

            
        }


        private static ImporterExporter GetFileFormatFromUser()
        {
            ImporterExporter result = null;
            while (result == null)
            {
                Console.WriteLine("File Format Types:");
                foreach (ImporterExporter importerExporter in ImporterExporters)
                    Console.WriteLine($"\t{importerExporter.name.PadRight(10)}{importerExporter.description}");
                Console.Write("Specific which format type you want to work or EXIT? ");
                string response = Console.ReadLine()?.Trim().ToUpper();
                if (response == "EXIT")
                    return null;

                foreach (ImporterExporter importerExporter in ImporterExporters)
                {
                    if (response == importerExporter.name)
                    {
                        result = importerExporter;
                        break;
                    }
                }
            }

            return result;       
        }

    }
}
