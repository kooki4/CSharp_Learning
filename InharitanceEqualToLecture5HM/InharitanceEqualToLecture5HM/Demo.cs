using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InharitanceEqualToLecture5HM
{
    class Demo
    {
        public static void Main()
        {

            Person[] orata = new Person[10];

            Person chuek1 = new Person("Чуек 1", 34, true);
            Person chuek2 = new Person("Чуек 2", 23, false);
            Person chuek3 = new Person("Чуек 3", 17, true);
            Student uchenik1 = new Student("Учник 1", 21, true, 6);
            Student uchenik2 = new Student("Учник 2", 19, false, 3.9);
            Employee bachkator1 = new Employee("Бачкатор 1", 47, true, 40);
            Employee bachkator2 = new Employee("Бачкатор 2", 27, true, 25);

            //1 + 2. Fill the array with created objects
            orata[0] = chuek1;
            orata[1] = chuek2;
            orata[2] = chuek3;
            orata[3] = uchenik1;
            orata[4] = uchenik2;
            orata[5] = bachkator1;
            orata[6] = bachkator2;

            // 3. Iterate trought the array and check the Type. Depending on the Type call the representative ....info() mothod.
            foreach (var j in orata)
            {
                if (j != null)
                {
                    if (j is Student)
                    {
                        var a = (j as Student);
                        a.showStudentInfo();
                    }
                    else if (j is Employee)
                    {
                        var a = (j as Employee);
                        a.showEmployeeInfo();
                    }
                    else
                    {
                        j.showPerson();
                    }
                }
            }

            //4. Iterate trought the array, find the Employee objects, add 2 hours overtime to each of them.
            foreach (var j in orata)
            {
                if (j != null)
                {
                    if (j is Employee)
                    {
                        var a = (j as Employee);
                        Console.WriteLine(a.calculateOvertime(2));
                    }

                }

            }
        }
    }
}