using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Class
{
    interface IBase
    {
        string Name { get; set; }
        string Surname { get; set; }
    }

    public class Student : IBase
    {
        string name;
        string surname;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public Student(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public void PrintName()
        {
            Console.WriteLine("Name:    " + this.Name + "\nSurname:   " + this.Surname);
        }
    }

    public class Teacher : Student
    {
        public int Age;
        public Teacher(string name, string surname, int age)
            : base(name, surname)
        {
            this.Age = age;
        }
        public void PrintAge()
        {
            Console.WriteLine("Age:    " + this.Age);
        }
    }

    public class Persona : Teacher
    {
        public string University;
        public Persona(string name, string surename, int age, string university)
            : base(name, surename, age)
        {
            this.University = university;
        }
        public void PrintUniversity()
        {
            Console.WriteLine("University:    " + this.University);
        }
    }

    public class HeadofDepartment : Persona
    {
        public string strana;
        public HeadofDepartment(string name, string surename, int age, string univesity, string strana)
            : base(name, surename, age, univesity)
        {
            this.strana = strana;
        }
        public void PrintStrana()
        {
            Console.WriteLine("Сountry:    " + this.strana);
        }
    }

    class Program
    {
        delegate void Output();
        static void Main(string[] args)
        {
            Student student = new Student("Bill", "Holond");
            Teacher teacher = new Teacher("Vally", "Kuper", 35);
            Persona persona = new Persona("Laf", "Molli", 20, "ONPU");
            HeadofDepartment headofDepartment = new HeadofDepartment("Vinger", "Pepe", 45, "ONPU", "Ukrain");
            Output output;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Info about STUDENT\n2.Info about TEACHER\n3.Info about PERSONA\n4.Info about HEADOFDEPARTMENT");
                int selection = 0;
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Unknown command");
                    Console.ReadKey();
                    continue;
                }
                switch (selection)
                {
                    case 1:
                        output = student.PrintName;
                        output();
                        Console.ReadKey();
                        break;
                    case 2:
                        output = teacher.PrintName;
                        output += teacher.PrintAge;
                        output();
                        Console.ReadKey();
                        break;
                    case 3:
                        output = persona.PrintName;
                        output += persona.PrintAge;
                        output += persona.PrintUniversity;
                        output();
                        Console.ReadKey();
                        break;
                    case 4:
                        output = headofDepartment.PrintName;
                        output += headofDepartment.PrintAge;
                        output += headofDepartment.PrintUniversity;
                        output += headofDepartment.PrintStrana;
                        output();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}