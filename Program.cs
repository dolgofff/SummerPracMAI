using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask1
{
    internal class Program
    {
        public class Student : IEquatable<Student>
        {
            private string Name;
            private string SecondName;
            private string Surname;
            private string Group;
            private string ChosenCourse;

            public Student(string name, string secondName, string surname, string group, string chosenCourse)
            {
                if (String.IsNullOrWhiteSpace(name) ||
                   String.IsNullOrWhiteSpace(secondName) ||
                   String.IsNullOrWhiteSpace(surname) ||
                   String.IsNullOrWhiteSpace(group) ||
                   String.IsNullOrWhiteSpace(chosenCourse))
                {
                    throw new ArgumentException();
                }
                Name = name;
                SecondName = secondName;
                Surname = surname;
                Group = group;
                ChosenCourse = chosenCourse;
            }
            //Реализация свойств
            public string NameS
            {
                get { return Name; }
            }

            public string SecondNameS
            {
                get { return SecondName; }
            }

            public string SurnameS
            {
                get { return Surname; }
            }

            public string GroupS
            {
                get { return Group; }
            }

            public string ChosenCourseS
            {
                get { return ChosenCourse; }
            }

            //Номер курса по уч. группе
            public int GetCourseNumberS
            {
                get
                {
                    string[] GroupData = Group.Split('-');
                    return Convert.ToInt32(GroupData[1].Substring(0, 1));
                }
            }

            //Переопределение методов
            public override string ToString()
            {
                return $"Student: {NameS} {SecondNameS} {SurnameS} {Environment.NewLine}" +
                       $"Group: {GroupS} {Environment.NewLine}" +
                       $"Practice: {ChosenCourseS} {Environment.NewLine}" +
                       $"Number of course: {GetCourseNumberS} {Environment.NewLine}";
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(NameS, SecondNameS, SurnameS, GroupS, ChosenCourseS);
            }

            public override bool Equals(object obj)
            {
                if (obj == null) { return false; }
                if (obj is Student) { return Equals((Student)obj); }
                return false;
            }

            public bool Equals(Student other)
            {
                if (other == null) { return false; }
                return NameS.Equals(other.NameS) &&
                       SecondNameS.Equals(other.SecondNameS) &&
                       SurnameS.Equals(other.SurnameS) &&
                       GroupS.Equals(other.GroupS) &&
                       ChosenCourseS.Equals(other.ChosenCourseS);                               
            }
        }

        static void Main(string[] args)
        {
            try
            {


                Student student0 = new Student("Mikhail", "Yurievich", "Gorshenev", "M8O-213B-21", "Infrastructure");
                Student student1 = new Student("Mikhail", "Petrovich", "Zubenko", "M6O-228A-21", "Golang");
                Student student2 = new Student("Mikhail", "Yurievich", "Gorshenev", "M8O-213B-21", "Infrastructure");
                Console.WriteLine(student0.ToString());
                Console.WriteLine($"{Environment.NewLine}");
                Console.WriteLine(student2.Equals(student0));
                Console.WriteLine($"{Environment.NewLine}");
                Console.WriteLine(student0.Equals(student1));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Incorrect input,try again!");
            }
        }
    }
}
   
    

