using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InharitanceEqualToLecture5HM
{
    class Student : Person
    {
       public double score
        {
            get
            { /// Here I have a stackoverflow issue !
                return score;
            }
            set
            {
                if (score < 2 || score > 6)
                    throw new IndexOutOfRangeException($"score is out of range, must be betwee 2 and 6. score value is {this.score}");
                else this.score = score;
            }
        }
        public Student(string name, int age, bool isMan, double score) : base(name, age, isMan)
        {
            this.score = score;
        }

    }
}
