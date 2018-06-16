using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Playground
{
    class Student
    {
        public string name { get; set; }
        public string subject { get; set; }
        public double grade { get; set; }
        public int yearInCollague { get; set; }
        public int age { get; set; }
        public bool isDegree { get; set; }
        public double money { get; set; }

        public Student()
        {
            this.yearInCollague = 1;
            this.isDegree = false;
            this.money = 0;

        }
        public Student(string name, string subject, int age, double grade) : this()
        {
            this.name = name;
            this.subject = subject;
            this.age = age;
            this.grade = grade;
        }

        public void upYear()
        {
            this.yearInCollague += 1;
            if (this.yearInCollague >= 4)
            {
                this.isDegree = true;
            }

        }
        public double receiveScholarship(double min, double amountOfScholarship)
        {
            if(this.grade >= min && this.age < 30)
            {
                this.money += amountOfScholarship;
            }
            return money;
        }
    }

}
