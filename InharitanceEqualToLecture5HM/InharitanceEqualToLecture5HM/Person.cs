using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InharitanceEqualToLecture5HM
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public bool isMan { get { return true; } set { } }

        public Person(string name, int age, bool isMan)
        {
            this.age = age;
            this.name = name;
            this.isMan = isMan;
        }

        public void showPerson()
        {
            Console.WriteLine(this.name + " " + this.age + " " + this.isMan);
        }

    }

}

