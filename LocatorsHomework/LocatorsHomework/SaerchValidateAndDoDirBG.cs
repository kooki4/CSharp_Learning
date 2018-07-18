using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace LocatorsHomework
{
    public class SaerchValidateAndDoDirBG
    {
        public void validateSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://dir.bg/";
            // Locate Днес at top menu options
            IWebElement topMenuSearch = driver.FindElement(By.XPath("//a[@class='search']"));
            topMenuSearch.Click();
            IWebElement searchTextField = driver.FindElement(By.Name("q"));

            searchTextField.SendKeys("Hasan sys salam !");
            Console.Read();

        }
    }
}
