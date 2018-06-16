using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            string result = string.Empty;

            int.TryParse(Console.ReadLine(), out a);
            int.TryParse(Console.ReadLine(), out b);

            for(int i = a; i <= b; i++)
            {
                int j = i * i;
                if(j < b)
                {
                   if(j % 3 == 0)
                    {
                        result += "skip " + i + ",";
                        continue;
                    }else
                    {
                        result += j + ",";
                    }
                }
                else
                {
                    Console.WriteLine(result.TrimEnd(','));
                    break;
                }
            }
        }
    }
}
