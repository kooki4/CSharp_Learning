using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Playground
{
    class ComputerDemo
    {
        static void Main2()
        {
            Computer laptop = new Computer();
            laptop.year = 2017;
            laptop.price = 5000;
            laptop.hardDiskMemory = 500000;
            laptop.freeMemory = 8000;
            laptop.isNotebook = true;
            laptop.operatingSystem = "Windows 10";
            Computer desktop = new Computer();
            desktop.year = 2018;
            desktop.price = 3000;
            desktop.hardDiskMemory = 1000000;
            desktop.freeMemory = 12000;
            desktop.isNotebook = false;
            desktop.operatingSystem = "Linux - Mint";

            Console.WriteLine(laptop.freeMemory + "\n" + laptop.isNotebook + "\n" + laptop.hardDiskMemory + "\n" + laptop.operatingSystem + "\n" + laptop.price);
            laptop.useMemory(10000);

            desktop.changeOperationSystem("Windows 10 x64 Pro");
            Console.WriteLine(desktop.freeMemory + "\n" + desktop.isNotebook + "\n" + desktop.hardDiskMemory + "\n" + desktop.operatingSystem + "\n" + desktop.price);

            Computer oferta = new Computer(2018, 4999, 20000, 16000);
            Computer oferta2 = new Computer(2018, 5111, 200232, 123123);
                        
            oferta.comparePrice(oferta2);
            oferta2.comparePrice(oferta);

         }
    }
}
