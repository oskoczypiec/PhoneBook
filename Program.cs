using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static PhonebookEntities context = new PhonebookEntities();
        static void Main(string[] args)
        {
            Initialize();
            Console.ReadKey();
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
                    SearchPerson();
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
            var firstName = ProvideFirstName();
            var lastName = ProvideLastName();
            var number = ProvideNumber();

            AddToDatabase(firstName, lastName, number);
        }

        static void SearchPerson()
        {
            Console.Out.WriteLine("*** Search for a person ***\n");
            Console.WriteLine("Search based on: \n[1] First name\n[2] Second name\n[3] Phone number");
            string choice = Console.In.ReadLine();
            Console.WriteLine($"So we are searching based on {choice}. Please provide searching value: ");
            string value = Console.In.ReadLine();
            switch (choice)
            {
                case "1":
                    SearchByFirstName(value);
                    return;
                case "2":
                    return;
                case "3":
                    return;
                default:
                    Console.Out.WriteLine("Could not recognize option\nSelect one of available ones!\n");
                    SearchPerson();
                    return;
            }
        }

        private static void SearchByFirstName(string firstNameSearch)
        {
            var data = context.Person.Where(x => x.FirstName == firstNameSearch);
            if (data.Count() > 1)
            {
                Console.WriteLine("Found:\n");
                foreach (var person in data)
                {
                    Console.WriteLine("");
                    if (person.FirstName == firstNameSearch)
                    {
                        Console.WriteLine($"{person.FirstName} {person.LastName}, number: {person.Number}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not find based on that criteria. Try again");
                SearchPerson();
            }
        }

        private static void SearchByLastName(string lastNameSearch)
        {
            var data = context.Person.Where(x => x.LastName == lastNameSearch);
            if (data.Count() > 1)
            {
                Console.WriteLine("Found:\n");
                foreach (var person in data)
                {
                    Console.WriteLine("");
                    if (person.LastName == lastNameSearch)
                    {
                        Console.WriteLine($"{person.FirstName} {person.LastName}, number: {person.Number}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not find based on that criteria. Try again");
                SearchPerson();
            }
        }

        private static void SearchByNumber(string numberSearch)
        {
            var data = context.Person.Where(x => x.Number == numberSearch);
            if (data.Count() > 1)
            {
                Console.WriteLine("Found:\n");
                foreach (var person in data)
                {
                    Console.WriteLine("");
                    if (person.Number == numberSearch)
                    {
                        Console.WriteLine($"{person.FirstName} {person.LastName}, number: {person.Number}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not find based on that criteria. Try again");
                SearchPerson();
            }
        }

        private static void AddToDatabase(string firstName, string lastName, string number)
        {
          
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

        private static string ProvideFirstName()
        {
            Console.Out.WriteLine("Provide a first name: ");
            string firstName = Console.In.ReadLine();      
            return Validate(firstName);
        }

        private static string Validate(string value)
        {

            if (int.TryParse(value, out _) || value.Length <= 0)
            {
                Console.Out.WriteLine("Do not try to test me.Try again.\nProvide a string:");
                value = Console.In.ReadLine();
                Validate(value);
            }
            else
            {
                Console.Out.WriteLine($"Ok, I've got {value}.");
            }

            return value;

        }

        private static string ProvideLastName()
        {
            Console.Out.WriteLine("Need more details, provide last name: ");
            string lastName = Console.In.ReadLine();
            return Validate(lastName);
        }
        private static string ProvideNumber()
        {
            Console.Out.WriteLine("Last step, provide a phone number: ");
            string number = Console.In.ReadLine();
            return ValidateNumber(number); 
        }

        private static string ValidateNumber(string number)
        {
            if (int.TryParse(number, out _) && number.Length < 15 || number.Length > 1)
            {
                Console.Out.WriteLine($"Ok, I've got {number}.");
            }
            else
            {
                Console.Out.WriteLine("Sorry, length of number must be between 1 and 15.\nTry again:");
                number = Console.In.ReadLine();
                ValidateNumber(number);
            }

            return number;
        }
    }
}
