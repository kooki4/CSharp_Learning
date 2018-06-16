using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Playground
{
    class StudentGroup
    {
        public string groupSubject { get; set; }
        Student [] students;
        public int freePlaces { get; set; }

        public StudentGroup()
        {
            this.students = new Student[5];
            this.freePlaces = 5;
        }
        public StudentGroup(string subject) : this()
        {
            this.groupSubject = subject;
        }
        public void addStudent(Student s)
        {
            if (s.subject.Equals(groupSubject))
            {
                if(freePlaces <= 0)
                {
                    Console.WriteLine($"There are NO more places in the group: {s.subject}");
                }
                else
                {
                    students[freePlaces - 1] = s;
                    Console.WriteLine(students[freePlaces - 1].name);
                    this.freePlaces--;
                }
            }
        }

        public void emptyGroup()
        {
            this.students = new Student[5];
            this.freePlaces = 5;
        }

        public void theBestStudent()
        {
            Student bestStudent = students[freePlaces];
            Console.WriteLine("And the best student would be:");
            for (int j = 0; j <= students.Count(s => s != null); j++)
            {
               /// Student [] sorted= students.Reverse();
                
                if(students[j] != null)
                {
                    if(bestStudent.grade <= students[j].grade)
                    {
                        bestStudent = students[j];
                    }
                }
            }
            Console.WriteLine(bestStudent.name);
        }

        public void printStudentsInGroup()
        {
            Console.WriteLine("Here's the list of the students in group {0}", groupSubject);
            Console.WriteLine(students.Count(s => s != null));
            foreach (Student j in students.Reverse())
            {
                if (j != null)
                {
                    Console.WriteLine($"{j.name}, {j.age}, {j.grade}, {j.subject}, {j.isDegree}, {j.yearInCollague}");
                }
            }
        }

    }
}
