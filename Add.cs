using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Add
    {
        public static void AddPerson()
        {
            Console.Out.WriteLine("*** Adding a new person ***\n");
            var firstName = Helper.ProvideFirstName();
            var lastName = Helper.ProvideLastName();
            var number = Helper.ProvideNumber();

            AddToDatabase(firstName, lastName, number);
        }

        public static void AddToDatabase(string firstName, string lastName, string number)
        {

            var newPerson = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Number = number
            };

            try
            {
                Helper.context.Person.Add(newPerson);
                Helper.context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oopsie, {e}");
            }
            Console.WriteLine($"Seems like {firstName} {lastName} with {number} number is addedd to database!\n");
            //Helper.Initialize();
        }
    }
}
