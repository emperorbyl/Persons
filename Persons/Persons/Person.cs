using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class Person
    {
        public int objectId { get; set; }
        public string stateFileNumber { get; set; }
        public string socialSecurityNumber { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public int birthYear { get; set; }
        public int birthMonth { get; set; }
        public int birthDay { get; set; }
        public string gender { get; set; }
        public string newbornScreeningNumber { get; set; }
        public string isPartOfMultipleBirth { get; set; }
        public int birthOrder { get; set; }
        public string birthCounty { get; set; }
        public string motherFirstName { get; set; }
        public string motherMiddleName { get; set; }
        public string motherLastName { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
    }
}
