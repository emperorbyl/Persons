using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class Person
    {
        int objectId { get; set; }
        string stateFileNumber { get; set; }
        string socialSecurityNumber { get; set; }
        string firstName { get; set; }
        string middleName { get; set; }
        string lastName { get; set; }
        int birthYear { get; set; }
        int birthMonth { get; set; }
        int birthDay { get; set; }
        string gender { get; set; }
        string newbornScreeningNumber { get; set; }
        string isPartOfMultipleBirth { get; set; }
        int birthOrder { get; set; }
        string birthCounty { get; set; }
        string motherFirstName { get; set; }
        string motherMiddleName { get; set; }
        string motherLastName { get; set; }
        string phone1 { get; set; }
        string phone2 { get; set; }
    }
}
