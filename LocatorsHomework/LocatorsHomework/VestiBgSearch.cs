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
        public void doSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.vesti.bg/";
            driver.Manage().Window.Maximize();
            //Accept the GDPR
            System.Threading.Thread.Sleep(3000);
            //Fucking GDPR, must find a way how to locate it and work with it - dialog page.
            IWebElement gdprPopUp = driver.FindElement(By.Id("scrolable"));
            gdprPopUp.SendKeys(Keys.Space);
            gdprPopUp.SendKeys(Keys.Space);
            gdprPopUp.SendKeys(Keys.Space);


            IWebElement searchBtn = driver.FindElement(By.CssSelector(".search-button"));
            searchBtn.Click();
            IWebElement textSearchFiled = driver.FindElement(By.XPath("//input[@class='input-field search-page-field blur']"));
            Console.WriteLine(textSearchFiled.GetAttribute("maxlenght"));




            Console.ReadLine();
            // searchBtn.Clear();
        }
    }
}
