// PROTOTYPE PATTERN is used to copy/clone an object
// This can be using an Interface, Copy Constructor or Serializing/Deserializing the object
// Serializing/Deserializing is the most widely used method to copy an object

using PersonClasses;
using System;
using System.IO;
using System.Xml.Serialization;

namespace PrototypePattern
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(memoryStream, self);
                memoryStream.Position = 0;
                return (T)serializer.Deserialize(memoryStream);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Abhilash", "Hazarika", 30);
            person.StreetName = "AB Street";
            person.ZipCode = "78110";
            person.HobbiesList.Add("Cooking");
            person.HobbiesList.Add("Watching movies");

            var person2 = person.DeepCopy();
            person2.FirstName = "Changed";
            person2.LastName = "Name";
            person2.Age = 20;

            Console.WriteLine($"Person 1\n{person}");
            Console.WriteLine("\n===========================================================\n");
            Console.WriteLine($"Person 2\n{person2}");
            Console.Read();
        }
    }
}
