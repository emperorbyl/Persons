using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Program
    {
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

            string dataFilename = GetFilenameFromUser();
            if (string.IsNullOrWhiteSpace(dataFilename))
                return;

            // Create from sample gadgets and print them out
            ThingABobCollection data1 = new ThingABobCollection() { MyImporterExporter = importerExporter, MyDataFile = dataFilename };
            data1.PrintCollection("original object");
            data1.MyImporterExporter = importerExporter;
            data1.Write();

            // Read the data file back in and print out the objects
            ThingABobCollection data2 = new ThingABobCollection() { MyImporterExporter = importerExporter, MyDataFile = dataFilename };
            data2.Read();
            data2.PrintCollection("objects in the json collection");

            Console.WriteLine("Type ENTER to exit");
            Console.WriteLine("");
            Console.ReadLine();
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

        private static string GetFilenameFromUser()
        {
            string result = null;
            Console.Write($"Enter data file name or EXIT (default={DefaultDataFilename})? ");
            string response = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(response))
                response = DefaultDataFilename;

            if (response != "EXIT")
                result = response;

            return result;
        }
    }
}
