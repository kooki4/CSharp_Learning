using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Playground
{
    public class Computer
    {
        public Computer() {
            this.isNotebook = false;
            this.operatingSystem = "Win XP";
        }
        public Computer(int year, double price, double hardDiskMemory, double freeMemory)
        {
            this.year = year;
            this.price = price;
            this.hardDiskMemory = hardDiskMemory;
            this.freeMemory = freeMemory;
        }
        public int year { get; set; }
        public double price { get; set; }
        public bool isNotebook { get; set; }
        public double hardDiskMemory { get; set; }
        public double freeMemory { get; set; }
        public string operatingSystem { get; set; }

        public void changeOperationSystem(string newOS)
        {
            this.operatingSystem = newOS;
        }

        public void useMemory(double memory)
        {
            if (memory > this.freeMemory)
            {
                Console.WriteLine("Not enough free memory!");
            } else
            {
                this.freeMemory -= memory;
            }
        }

        public int comparePrice(Computer c)
        {
            if (c.price < this.price)
            {
                Console.WriteLine($"Офертата е по-добра, защото е за {c.price}, а старата машина е била {this.price}");
                return 1;
            }
            else if ( c.price > this.price){
                Console.WriteLine($"Офертата е по-скъпа, защото е за {c.price}, а старата машина е била {this.price}");
                return -1;
            }
            else
            {
                Console.WriteLine("Цените са еднакви");
                return 0;
            }
        }
    }
}
