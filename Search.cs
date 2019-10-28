using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Search : Helper
    {
        public static void SearchPerson()
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
                    SearchByLastName(value);
                    return;
                case "3":
                    SearchByNumber(value);
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
            }
            Helper.Initialize();
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
            }
            Helper.Initialize();
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
            }
            Helper.Initialize();
        }
    }
}
