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
    class Wheather
    {
        public IWebDriver driver { get; set; }
        public void getCurrentWheather()
        {
            /* 
            Goes go dir.bg, click on small wheather button, gets the current temperture and location and prints inside the console.
            */
            this.driver = new FirefoxDriver();
            driver.Url = "https://dir.bg/";

            //Accept GDPR
            IWebElement agreeBtn = driver.FindElement(By.ClassName("button_text"));
            agreeBtn.Click();

            Actions actions = new Actions(driver);
            var wheather = driver.FindElement(By.XPath("//a[@class='weather']"));
            actions.Click(wheather).Perform();

            System.Threading.Thread.Sleep(1000);
            IWebElement gradusi = driver.FindElement(By.XPath("//span[@class='weather-temp']"));

            System.Threading.Thread.Sleep(1000);
            IWebElement currentTime = driver.FindElement(By.XPath("//strong[@class='weather-time']"));

            IWebElement currentLocation = driver.FindElement(By.XPath("//div[@class='weather-location']//h2"));

            Console.WriteLine($"{currentTime.Text} температурата е { gradusi.Text } в { currentLocation.Text }.");

            Console.ReadLine();

            driver.Quit();
        }


    }
}
