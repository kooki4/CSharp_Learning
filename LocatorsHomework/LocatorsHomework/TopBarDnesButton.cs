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
    class TopBarDnesButton
    {
        private void run()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://dir.bg/";
            // Locate Днес at top menu options
            var topMenuBarElement = driver.FindElement(By.XPath("//nav[@class='main-nav']"));
            List<IWebElement> elements = topMenuBarElement.FindElements(By.XPath(".//li ")).ToList();
            List<IWebElement> onlyDnes = new List<IWebElement>();

            foreach (IWebElement el in elements)
            {
                if (el.Text.Equals("Днес"))
                {
                    onlyDnes.Add(el);
                }
            }

            System.Threading.Thread.Sleep(6000);
            Actions hoover = new Actions(driver);

            hoover.ContextClick(onlyDnes[0]).Build().Perform();

            Console.ReadLine();

            driver.Quit();
        }
    }
}
