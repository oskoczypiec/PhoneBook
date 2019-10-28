using System;
using System.Linq;
using NUnit;
using NUnit.Framework;
using PhoneBook;

namespace PhoneBookTests
{
    [TestFixture]
    public class AddUserTests
    {
        public static PhonebookEntities context = new PhonebookEntities();
        [Test]
        public void AddingUserToDatabase()
        {
            var firstName = "Vuko";
            var lastName = "Drakkainen";
            var phoneNumber = "1234567890";

            Add.AddToDatabase(firstName, lastName, phoneNumber);


            var temp = context.Person.Where(x => x.FirstName == firstName);
            //Assert.That(context.Person.Find(firstName,lastName,phoneNumber),Is.EqualTo(""));
        }
    }
}
