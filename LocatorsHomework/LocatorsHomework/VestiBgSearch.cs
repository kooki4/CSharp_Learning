using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace LocatorsHomework
{
    public class VestiBgSearch
    {
        public void ClickSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.vesti.bg/";
            driver.Manage().Window.Maximize();

            IWebElement searchButton = null;
            IWebElement searchButton1 = null;
            IWebElement kristinaGaveBirth = null;
            IWebElement textField = null;

            //Accept the GDPR
            System.Threading.Thread.Sleep(3000);

            try
            {
                searchButton = driver.FindElement(By.ClassName("search-button"));
                Console.WriteLine(searchButton.Text);
                searchButton1 = driver.FindElement(By.CssSelector(".search-button"));
                Console.WriteLine(searchButton.Text);
                
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("da mu se neznae");

            }

            searchButton1.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(700);

            textField = driver.FindElement(By.Name("q"));
            textField.SendKeys("Ралица");
            searchButton1.SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(5000);
            kristinaGaveBirth = driver.FindElement(By.XPath("//div[@class='content-left']//a[@href='https://www.vesti.bg/lyubopitno/aktrisata-ralica-paskaleva-stana-majka-6084181']//h3"));

            Console.WriteLine(kristinaGaveBirth.Text); 

            Console.ReadLine();
            // searchBtn.Clear();


            driver.Quit();

        }
    }
}
