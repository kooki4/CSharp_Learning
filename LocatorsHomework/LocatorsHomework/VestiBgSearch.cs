using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace LocatorsHomework
{
    public class VestiBgSearch
    {
        public void ClickSearch()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.vesti.bg/";
            //Accept the GDPR
            System.Threading.Thread.Sleep(3000);
            IWebElement acceptBtn = driver.FindElement(By.XPath("//div[@class='modal-wrapper cb-main-page'"));


            acceptBtn.SendKeys(Keys.Space);
            acceptBtn.SendKeys(Keys.Space);
            acceptBtn.SendKeys(Keys.Space);
            acceptBtn.SendKeys(Keys.Space);



            acceptBtn.Click();


            Console.ReadLine();
           // searchBtn.Clear();
        }
    }
}
