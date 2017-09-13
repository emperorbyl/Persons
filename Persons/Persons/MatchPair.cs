using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class MatchPair
    {
        public Person personA { get; set; }
        public Person personB { get; set; }
        public bool Match(string algorithmName, Person person1, Person person2)
        {
            bool match = false;
            if (!string.IsNullOrEmpty(algorithmName))
            {
                try
                {
                    if ((algorithmName == "One" || algorithmName == "1") && person1.FirstName.Equals(person2.FirstName) && person1.MiddleName.Equals(person2.MiddleName))// && person1.LastName.Equals(person2.LastName))
                        match = true;
                    else if ((algorithmName == "Two" || algorithmName == "2") && person1.MotherFirstName.Equals(person2.MotherFirstName) && person1.MotherMiddleName.Equals(person2.MotherMiddleName) && person1.MotherLastName.Equals(person2.MotherLastName) && person1.BirthDay == person2.BirthDay && person1.BirthMonth == person2.BirthMonth && person1.BirthYear == person2.BirthYear)
                        match = true;
                    else if ((algorithmName == "Three" || algorithmName == "3") && person1.SocialSecurityNumber == person2.SocialSecurityNumber)
                        match = true;
                }
                catch (Exception e)
                {
                    Console.Write("There is an invalid value. Please check the values for the method tried.\n");
                }

            }
            return match;
        }
        public MatchPair(Person person1, Person person2)
        {
            personA = person1;
            personB = person2;
        }
    }
}
