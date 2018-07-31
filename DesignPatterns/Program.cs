using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }

        public List<string> HobbiesList;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HobbiesList = new List<string>();
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"Name: {FirstName} {LastName}")
                .AppendLine($"Age: {Age}")
            .AppendLine($"Address: {StreetName} - {ZipCode}")
            .Append("Hobbies: ");

            foreach(var hobby in HobbiesList)
            {
                output.Append($"{hobby}, ");
            }

            string formattedString = output.ToString();

            return formattedString.Substring(0, (formattedString.Length - 2));
        }
    }

    class PersonBuilder
    {
        protected Person person;
        public PersonBuilder(string firstName, string lastName, int age)
        {
            person = new Person(firstName, lastName, age);
        }

        protected PersonBuilder()
        {

        }

        public AddressBuilder Address => new AddressBuilder(person);
        public HobbiesBuilder Hobbies => new HobbiesBuilder(person);

        public static implicit operator Person(PersonBuilder personBuilder)
        {
            return personBuilder.person;
        }
    }

    class AddressBuilder : PersonBuilder
    {
        public AddressBuilder(Person person)
        {
            this.person = person;
        }

        public AddressBuilder LivesAt(string streetName)
        {
            person.StreetName = streetName;

            return this;
        }

        public AddressBuilder AtZipCode(string zipCode)
        {
            person.ZipCode = zipCode;

            return this;
        }
    }

    class HobbiesBuilder : PersonBuilder
    {
        public HobbiesBuilder(Person person)
        {
            this.person = person;
        }

        public HobbiesBuilder Likes(string hobby)
        {
            person.HobbiesList.Add(hobby);

            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder("Abhilash", "Hazarika", 30);
            Person person = pb.Address.LivesAt("Guwahati")
                     .AtZipCode("781024")
             .Hobbies.Likes("Cooking")
                      .Likes("Playing guitar");

            Console.WriteLine(person);
            Console.Read();
        }
    }
}
