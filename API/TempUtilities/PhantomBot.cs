using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;

namespace API.TempUtilities
{
    public class PhantomBot
    {
        public static void SetValueInUI(IFindsByXPath driver, decimal value)
        {
            var element = driver.FindElementByXPath($"//div[@class='Keypad']//*[text()='{value}']");
            element.Click();
        }
        public static void SetOperatorInUI(IFindsByXPath driver, string value)
        {
            var element = driver.FindElementByXPath($"//div[@class='Keypad']//*[text()='{value}']");
            element.Click();
        }

        public static ChromeDriver SettingDriver()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://localhost/");
            return driver;
        }

        public static bool GetStateButtonInUI(IFindsByXPath driver, string value)
        {
            try
            {
                var element = driver.FindElementByXPath($"//div[@class='Keypad']//*[text()='{value}']").GetAttribute("disabled");
                ;
                return bool.Parse(element);
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
