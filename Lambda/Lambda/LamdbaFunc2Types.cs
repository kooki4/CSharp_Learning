using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class LamdbaFunc2Types
    {
 
        public LamdbaFunc2Types()
        {
            Work();
        }
        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public void Work()
        {
            int a = 10;
            int b = 20;

            Func<int, int, int> multiplyDigits;
            multiplyDigits = Multiply;
            int product = multiplyDigits(a, b);
            Console.WriteLine($"Product = {product}");

            Func<int, int, int> mutiplyDigits2 =
                (x, y) => (x * y); //First 2 ints from Func<> are passed to x and y then multiplied and returned as int.
            int product2 = mutiplyDigits2(a, b);
            Console.WriteLine($"Product2 =  {product2}");

        }


    }

}
