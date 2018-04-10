using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQ_Example
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
    class Hometown
    {
        public string City { get; set; }
        public string State { get; set; }
    }

    class Program
    {

        static void OrderByStateThenCity()
        {
            List<Hometown> hometowns = new List<Hometown>()
            {
                new Hometown() { City = "Philadelphia", State = "PA" },
                new Hometown() { City = "Ewing", State = "NJ" },
                new Hometown() { City = "Havertown", State = "PA" },
                new Hometown() { City = "Fort Washington", State = "PA" },
                new Hometown() { City = "Trenton", State = "NJ" }
            };
            var orderedHometowns = from h in hometowns
                                   orderby h.State ascending, h.City ascending
                                   select h;

            foreach (var hometown in orderedHometowns)
            {
                Console.WriteLine(hometown.City + ", " + hometown.State);
            }
        }

        static void person()
        {
            List<Person> people = new List<Person>()
            {             
                new Person() { FirstName = "John",LastName = "Smith",Address1 = "First St",City = "Havertown",State = "PA",Zip = "19084"},
                new Person() {FirstName = "Jane",LastName = "Doe",Address1 = "Second St",City = "Ewing",State = "NJ",Zip = "08560"},
                new Person() {FirstName = "Jack",LastName = "Jones",Address1 = "Third St",City = "Ft Washington",State = "PA",Zip = "19034"}
            };
                var lastNames = from p in people
                                select p.LastName;
            
                    foreach (string lastName in lastNames)
                        {
                            Console.WriteLine(lastName);
                        }
        }

        static void Main(string[] args)
        {

          #if DEBUG 
            Console.WriteLine("This is debug");
           #elif VC7
            Console.WriteLine("This is VC 7"); 
           #else 
             Console.WriteLine("This is release"); 
#endif

            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //This is query expression syntax
            Console.WriteLine("query expression syntax");
            var evenNumbers = from i in myArray
                              where i % 2 == 0 //&& i > 5
                              orderby i ascending
                              select i;
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }

            //The equivalent method-based query follows:
            Console.WriteLine();
            Console.WriteLine("method-based query expression syntax");

            var evenNumbers1 = myArray.Where(i => i % 2 == 0);

            foreach (int i in evenNumbers1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine("Example of 2 order by");
            OrderByStateThenCity();
            Console.WriteLine();
            Console.WriteLine("Example of projection ");
            person();
            // decimal amount = decimal.Parse("$123,456.78", NumberStyles.AllowCurrencySymbol |NumberStyles.AllowThousands |NumberStyles.AllowDecimalPoint);
            // decimal amount = decimal.Parse("$123456.78", NumberStyles.AllowCurrencySymbol);
            // Console.WriteLine(amount.ToString());
            Console.ReadLine();
        }
    }
}
