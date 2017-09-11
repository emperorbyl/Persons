using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class MatchPair
    {
        private Person personA;
        private Person personB;
        private List<MatchPair> matchList;
        bool Match(string algorithmName)
        {
            bool match = false;
            if (!string.IsNullOrEmpty(algorithmName))
            {
                if ((algorithmName == "One" || algorithmName == "1") && personA.firstName.Equals(personB.firstName) && personA.middleName.Equals(personB.middleName) && personA.lastName.Equals(personB.lastName))
                    match = true;
                if ((algorithmName == "Two" || algorithmName == "2") && personA.motherFirstName.Equals(personB.motherFirstName) && personA.motherMiddleName.Equals(personB.motherMiddleName) && personA.motherLastName.Equals(personB.motherLastName))
                {
                    match = true;
                }
            }
            return match;
        }
    }
}
