// BUILDER PATTERN is used to breakdown/simplify the creation of an object

using PersonClasses;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder("Abhilash", "Hazarika", 30);
            Person person = pb
                .Address.LivesAt("Guwahati")
                        .AtZipCode("781024")
                .Hobbies.Likes("Cooking")
                        .Likes("Playing guitar");

            Console.WriteLine(person);
            Console.Read();
        }
    }
}
