using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persons;

namespace PersonsTest
{
    [TestClass]
    public class MatchPairTester
    {
        [TestMethod]
        public void TestMatchPairConstructor()
        {
            Person personA = new Person();
            Person personB = new Person();
            MatchPair match = new MatchPair(personA, personB);
            Assert.IsNotNull(match);
        }

        public void TestMatchPairMethod()
        {
            Person personA = new Person();
            Person personB = new Person();
            personA.FirstName = "Bob";
            personA.MiddleName = "John";
            personA.LastName = "Hiddleston";
            personB.FirstName = "Bob";
            personB.MiddleName = "John";
            personB.LastName = "Hiddleston";
            MatchPair match = new MatchPair(personA, personB);
            bool isMatch = match.Match("1", personA, personB);
            Assert.IsTrue(isMatch);
            Person personC = new Person();
            Person personD = new Person();
            personC.SocialSecurityNumber = "Bob";
            personD.SocialSecurityNumber = "Bob";
            MatchPair match1 = new MatchPair(personC, personD);
            bool isMatch1 = match.Match("3", personC, personD);
            Assert.IsTrue(isMatch1);
            personA.MotherFirstName = "Roberta";
            personA.MotherMiddleName = "Jenny";
            personA.MotherLastName = "Clayson";
            personA.BirthDay = 26;
            personA.BirthMonth = 03;
            personA.BirthMonth = 1956;
            personB.MotherFirstName = "Roberta";
            personB.MotherMiddleName = "Jenny";
            personB.MotherLastName = "Clayson";
            personB.BirthDay = 26;
            personB.BirthMonth = 03;
            personB.BirthMonth = 1956;
            isMatch = match.Match("2", personA, personB);
            Assert.IsTrue(isMatch);
        }
    }
}
