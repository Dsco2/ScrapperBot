using System;
using System.Globalization;
using API.TempUtilities;
using OpenQA.Selenium.Chrome;

namespace API.TempService
{
    public class Service
    {
        public static double Operation(long digit1, long digit2, string operation)
        {
            var driver = new ChromeDriver(); 
            try
            {
                driver = PhantomBot.SettingDriver();

                SetNumber(digit1, driver);
                
                PhantomBot.SetOperatorInUI(driver, operation);

                SetNumber(digit2, driver);

                var isEnableButton = VerifyButton(driver, "=");
                if (isEnableButton) return 0;
                PhantomBot.SetOperatorInUI(driver, $"=");
                var result = driver.FindElementByXPath("//input[@class='DisplayText']").GetAttribute("value");

                driver.Close();

                return double.Parse(result);
            }
            catch (Exception)
            {
                driver.Close();
                return 0;
            }


        }

        private static void SetNumber(long digit1, ChromeDriver driver)
        {
            if (digit1 < 0)
            {
                PhantomBot.SetOperatorInUI(driver, "-");
            }

            foreach (var t in digit1.ToString(CultureInfo.InvariantCulture))
            {
                PhantomBot.SetValueInUI(driver, Absolute(int.Parse(t.ToString())));
            }
        }

        private static long Absolute(long number)
        {
            if (number < 0)
            {
                return -number;
            }

            return number;
        }

        public static double InputNumber(ulong digit1)
        {
            var driver = PhantomBot.SettingDriver();

            foreach (var t in digit1.ToString(CultureInfo.InvariantCulture))
            {
                PhantomBot.SetValueInUI(driver, int.Parse(t.ToString()));
            }
            
            var result = driver.FindElementByXPath("//input[@class='DisplayText']").GetAttribute("value");

            driver.Close();

            return double.Parse(result);
        }

        public static bool VerifyEqual(long digit1)
        {
            var driver = PhantomBot.SettingDriver();

            SetNumber(digit1, driver);

            var result = VerifyButton(driver, "=");

            driver.Close();

            return result;
        }

        public static bool SendOperatorOnly(string operation)
        {
            var driver = PhantomBot.SettingDriver();

            PhantomBot.SetOperatorInUI(driver, operation);
            var result = VerifyButton(driver, "=");

            driver.Close();

            return result;
        }

        public static bool VerifyButton(ChromeDriver driver, string value)
        {
            return PhantomBot.GetStateButtonInUI(driver, value);
        }

        public static bool SendSecuentialOperation(long digit1, long digit2, long digit3, string operation1, string operation2)
        {
            var driver = new ChromeDriver();
            try
            {
                driver = PhantomBot.SettingDriver();

                SetNumber(digit1, driver);

                PhantomBot.SetOperatorInUI(driver, operation1);

                SetNumber(digit2, driver);

                PhantomBot.SetOperatorInUI(driver, operation2);

                SetNumber(digit3, driver);
                var result = VerifyButton(driver, "=");
                driver.Close();
                return result;
            }
            catch (Exception)
            {
                driver.Close();
                return false;
            }
        }
    }
}
