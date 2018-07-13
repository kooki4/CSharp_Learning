using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace LocatorsHomework
{
    class Demo
    {
        static void Main(string[] args)
        {
            // var vremeto = new Wheather();
            // vremeto.getCurrentWheather();

            var VestiBgSearch = new SaerchValidateAndDoDirBG();
            VestiBgSearch.validateSearch();
        }
    }
}
