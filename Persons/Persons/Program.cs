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
            string outFile = "";
            if (args.Count() > 2)
                outFile = args[2];
            if (string.IsNullOrWhiteSpace(dataFilename) || algorithm == null)
                return;
            
            PersonMatcher data1 = new PersonMatcher() { importExport = importerExporter, filename = dataFilename, algorithmName = algorithm , outputFile = outFile};
            
            data1.importExport = importerExporter;
            data1.Read();
            bool method = false;
            foreach(var person in data1.personList)
            {
                foreach (var person1 in data1.personList)
                {
                    if (person1.ObjectId != person.ObjectId)
                    {
                        MatchPair match = new MatchPair(person1, person);
                        method = match.Match(algorithm, person1, person);
                        if (method && !data1.matchList.Contains(match))
                            data1.matchList.Add(match);
                    }
                }
            }
            if (data1.matchList.Count > 0 && !string.IsNullOrEmpty(outFile))
                data1.Write();
            else if(method && string.IsNullOrEmpty(outFile))
            {
                foreach (var match in data1.matchList)
                {
                    Console.Write("Match:\n");
                    Console.Write("ID=" + match.personA.ObjectId.ToString() + ", Name=" + match.personA.FirstName + " " + match.personA.MiddleName + " " + match.personA.LastName + ", BirthDate = " + match.personA.BirthMonth.ToString() + "/" + match.personA.BirthDay.ToString() + "/" + match.personA.BirthYear.ToString() + "\n");
                    Console.Write("ID=" + match.personB.ObjectId.ToString() + ", Name=" + match.personB.FirstName + " " + match.personB.MiddleName + " " + match.personB.LastName + ", BirthDate = " + match.personB.BirthMonth.ToString() + "/" + match.personB.BirthDay.ToString() + "/" + match.personB.BirthYear.ToString() + "\n");
                }
            }
            else
                Console.Write("There are no matches in this list.");
            
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
