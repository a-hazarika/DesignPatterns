// In SINGLETON PATTERN a class is restricted to only a single instance
using System;
using System.Collections.Generic;

namespace SingletonPattern
{
    public interface IStudent
    {
        int GetAttendance();
        string GetStudentName();
    }

    class Student : IStudent
    {
        public string Name { get; set; }
        public int Attendance { get; set; }

        private Student()
        {
            Name = "Test";
            Attendance = 20;
        }

        public int GetAttendance()
        {
            return Attendance;
        }

        public string GetStudentName()
        {
            return Name;
        }

        private static Lazy<Student> _instance = new Lazy<Student>(() => new Student()); // When using Lazy, object is loaded only when someone tries to access Instance. It won't be preloaded
        public static Student Instance = _instance.Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var student1 = Student.Instance;
            var student2 = Student.Instance;
            Console.WriteLine($"{nameof(student1)} - {student1.GetStudentName()}");
            Console.WriteLine($"{nameof(student2)} - {student2.GetStudentName()}");

            student2.Name = "Test 2";
            Console.WriteLine("\n============================================\n");

            Console.WriteLine("After changing student 2 name to Test 2");
            Console.WriteLine($"{nameof(student1)} - {student1.GetStudentName()}");
            Console.WriteLine($"{nameof(student2)} - {student2.GetStudentName()}");

            Console.Read();
        }
    }
}
