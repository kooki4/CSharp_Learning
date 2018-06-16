using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Playground
{
    class StudentDemo
    {
        static void Main(string[] args)
        {
            Student alex = new Student("Alex", "Math", 23, 4.0);
            Student nina = new Student("Nina", "Math", 21, 4.1);
            Student nora = new Student("Nora", "Math", 21, 3.0);
            Student nino = new Student("Nino", "Math", 21, 5.75);
            Student kala = new Student("Kala", "Math", 21, 5.77);
            Student fazi = new Student("Fazi", "Math", 21, 5.70);


            StudentGroup bla = new StudentGroup("Math");
            bla.addStudent(alex);
            bla.addStudent(nina);
            bla.emptyGroup();
            bla.addStudent(nora);
            bla.addStudent(nino);
            bla.addStudent(kala);
            bla.addStudent(fazi);
            bla.printStudentsInGroup();
            bla.theBestStudent();
            nino.receiveScholarship(3,3560);
            Console.WriteLine(nino.money);
        }
    }
}
