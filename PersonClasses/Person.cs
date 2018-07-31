using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClasses
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }

        public List<string> HobbiesList;

        public Person()
        {

        }

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

            foreach (var hobby in HobbiesList)
            {
                output.Append($"{hobby}, ");
            }

            string formattedString = output.ToString();

            return formattedString.Substring(0, (formattedString.Length - 2));
        }
    }
}
