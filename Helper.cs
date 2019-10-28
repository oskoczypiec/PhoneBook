using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Helper
    {
        public static PhonebookEntities context = new PhonebookEntities();

        public static void Initialize()
        {
            Console.Out.WriteLine("*** Phonebook ***");
            Console.Out.WriteLine("Type option:");
            Console.Out.WriteLine($"[add] Add user\n[search] Search user\n[exit] To exit");
            string option = Console.In.ReadLine();
            switch (option)
            {
                case "add":
                    Add.AddPerson();
                    return;
                case "search":
                    Search.SearchPerson();
                    return;
                case "exit":
                    break;
                default:
                    Console.Out.WriteLine("Could not recognize option\nSelect one of available ones!\n");
                    Initialize();
                    return;
            }
        }

        public static string ProvideFirstName()
        {
            Console.Out.WriteLine("Provide a first name: ");
            string firstName = Console.In.ReadLine();
            return Validate(firstName);
        }

        public static string Validate(string value)
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

        public static string ProvideLastName()
        {
            Console.Out.WriteLine("Need more details, provide last name: ");
            string lastName = Console.In.ReadLine();
            return Validate(lastName);
        }

        public static string ProvideNumber()
        {
            Console.Out.WriteLine("Last step, provide a phone number: ");
            string number = Console.In.ReadLine();
            return ValidateNumber(number);
        }

        public static string ValidateNumber(string number)
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
