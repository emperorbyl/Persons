using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class MatchPair
    {
        private Person personA;
        private Person personB;
        public bool Match(string algorithmName, List<Person> personList, List<MatchPair> matchList)
        {
            bool match = false;
            if (!string.IsNullOrEmpty(algorithmName))
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    for (int j = i; j < personList.Count; j++)
                    {
                        Person person1 = personList[i];
                        Person person2 = personList[j];
                        if ((algorithmName == "One" || algorithmName == "1") && person1.firstName.Equals(person2.firstName) && person1.middleName.Equals(person2.middleName) && person1.lastName.Equals(person2.lastName))
                            match = true;
                        if ((algorithmName == "Two" || algorithmName == "2") && person1.motherFirstName.Equals(person2.motherFirstName) && person1.motherMiddleName.Equals(person2.motherMiddleName) && person1.motherLastName.Equals(person2.motherLastName) && person1.birthDay == person2.birthDay && person1.birthMonth == person2.birthMonth && person1.birthYear == person2.birthYear)
                            match = true;
                        if ((algorithmName == "Three" || algorithmName == "3") && person1.socialSecurityNumber == person2.socialSecurityNumber)
                            match = true;
                        if (match)
                        {
                            MatchPair matchPair = new MatchPair(person1, personB);
                            matchList.Add(matchPair);
                        }
                    }
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
