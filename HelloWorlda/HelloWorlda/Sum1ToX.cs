using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorlda
{
    class Sum1ToX
    {
        static void Main(string[] args)
        {
            int x;
            string result =string.Empty;
            int.TryParse(Console.ReadLine(), out x);
            for (int i = 3; i <= x; i++)
            {
                if (i % 3 == 0){
                    result+=i+",";
                }
            }
            Console.WriteLine(result.TrimEnd(','));
        }
    }
}