using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndCollections_List_Dictionary
{
    class Array
    {
        static void Main(string[] args)
        {
            int[] najMalkotoKratnoNaTri = new int[5];
            najMalkotoKratnoNaTri[0] = 10;
            najMalkotoKratnoNaTri[1] = 66;
            najMalkotoKratnoNaTri[2] = 12;
            najMalkotoKratnoNaTri[3] = -41;
            najMalkotoKratnoNaTri[4] = 5;
            int lowest = 0;

            for ( int i = 0; i < najMalkotoKratnoNaTri.Length; i++)
            {
                if (najMalkotoKratnoNaTri[i] % 3 == 0)
                {
                    if (lowest > najMalkotoKratnoNaTri[i])
                    {
                        lowest = najMalkotoKratnoNaTri[i];
                    }
                }
            }
            Console.WriteLine("Най-малкото число кратно на 3 е {0}", lowest);


        }
    }
}
