using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Hometown { get; set; }

            public override string ToString()
            {
                string result = "";

                result += "Name: " + Name;
                result += "\nAge: " + Age;
                result += "\nHometown: " + Hometown;

                return result;
            }

            public override bool Equals(object obj)
            {
                Student comp = obj as Student;

                if (comp != null)
                {
                    if (comp.Name == Name && comp.Age == Age && comp.Hometown == Hometown)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        static void Main(string[] args)
        {
            Student x = new Student();
            Student y = new Student();

            x.Name = "Anthony";
            x.Age = 27;
            x.Hometown = "Miami";

            y.Name = "Jonathan";
            y.Age = 27;
            y.Hometown = "Miami";

            bool Valid = x.Equals(y);
            Console.WriteLine(Valid);
        }
    }
}
