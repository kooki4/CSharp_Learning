using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InharitanceEqualToLecture5HM
{
    public class Student : Person
    {
        private double score;
        private double Score
        {
            get
            {
                return score;
            }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new IndexOutOfRangeException($"score is out of range, must be betwee 2 and 6. score value is {score}");
                }
                this.score = value;
            }
        }
        public Student(string name, int age, bool isMan, double score) : base(name, age, isMan)
        {
            this.Score = score;
        }
        public void showStudentInfo()
        {
            Console.WriteLine("Student info: " + this.name + " " + this.age + " " + this.isMan + " " + this.Score);
        }

    }
}
