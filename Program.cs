using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();
         
        }

        static void Initialize()
        {
                Console.Out.WriteLine("*** Phonebook ***");
                Console.Out.WriteLine("Type option:");
                Console.Out.WriteLine($"[add] Add user\n[search] Search user\n[exit] To exit");
                string option = Console.In.ReadLine();
                switch (option)
                {
                    case "add":
                    AddPerson();
                        return;
                    case "search":
                        return;
                    case "exit":
                        break;
                    default:
                        Console.Out.WriteLine("Could not recognize option\nSelect one of available ones!\n");
                    Initialize();
                    return; 
            }           
        }

        static void AddPerson()
        {
            Console.Out.WriteLine("*** Adding a new person ***\n");
            var firstName = provideFirstName();
            var lastName = provideLastName();
            var number = provideNumber();
     
            AddToDatabase(firstName, lastName, number);
        }

        private static void AddToDatabase(string firstName, string lastName, string number)
        {
            var context = new PhonebookEntities();
            var newPerson = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Number = number
            };

            try
            {
                context.Person.Add(newPerson);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oopsie, {e}");
            }
            Console.WriteLine($"Seems like {firstName} {lastName} with {number} number is addedd to database!\n");
            Initialize();
        }

        private static string provideFirstName()
        {
            Console.Out.WriteLine("Provide a first name: ");
            string firstName = Console.In.ReadLine();
            if (int.TryParse(firstName, out _))
            {
                Console.Out.WriteLine("Do not try to test me, provide a string!");
                provideFirstName();
            }
            else
            {
                Console.Out.WriteLine($"Ok, I've got {firstName}.");
            }
            return firstName;
        }
        private static string provideLastName()
        {
            Console.Out.WriteLine("Need more details, provide last name: ");
            string lastName = Console.In.ReadLine();
            if (int.TryParse(lastName, out _))
            {
                Console.Out.WriteLine("Do not try to test me, provide a string!");
                provideLastName();
            }
            else
            {
                Console.Out.WriteLine($"Ok, I've got last name {lastName}.");
            }
            return lastName;
        }
        private static string provideNumber()
        {
            Console.Out.WriteLine("Last step, provide a phone number: ");
            string number = Console.In.ReadLine();
            if (int.TryParse(number, out _) && number.Length < 15)
            {
                Console.Out.WriteLine($"Ok, I've got {number}.");
            }
            else
            {
                Console.Out.WriteLine("Sorry, maximum length of number is 15!");
                provideNumber();           
            }

            return number;
        }

    }
}
