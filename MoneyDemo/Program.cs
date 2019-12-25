using System;
using System.Collections;
using System.Collections.Generic;

namespace MoneyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var y = Test();
            var z = Test2();
            var h = (Name: "Peter", Age: 21);
            IEnumerable<(string name, int age)> lTuples = new (string name, int age)[5];

            Test3(("Peter", 25));

            var (MyName, MyAge) = Test();
            //var (name, age) = Test();

            var person = new Person("Peter", 25);

            var (Name, age) = person;

            var student = new Student("Peter", 25, 3.55);

            var (fName, hh, gpa) = student;
        }

        public static (string name, int age) Test() => ("Peter", 25);

        public static Tuple<string, int> Test2() => Tuple.Create("Peter", 25);

        public static void Test3((string Name, int Age) t1)
        {

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }
    }

    public class Student : Person
    {
        public double GPA { get; }

        public Student(string name, int age, double gpa):base(name, age)
        {
            GPA = gpa;
        }
    }

    public static class StudentExtensions
    {
        public static void Deconstruct(this Student s, out string name, out int age, out double gpa)
        {
            name = s.Name;
            age = s.Age;
            gpa = s.GPA;
        }
    }
}
