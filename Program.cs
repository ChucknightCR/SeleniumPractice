using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumOnlyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                driver.Manage().Window.Maximize();

                driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
                driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
                driver.FindElement(By.Id("login-button")).Click();

                Thread.Sleep(2000); 

                if (driver.Url.Contains("inventory"))
                {
                    Console.WriteLine("✅ Login successful! Inventory page loaded.");

                    driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
                    driver.FindElement(By.ClassName("shopping_cart_link")).Click();
                    driver.FindElement(By.Id("checkout")).Click();
                    Thread.Sleep(1000);


                    //Checkout info
                    driver.FindElement(By.Id("first-name")).SendKeys("Juan");
                    driver.FindElement(By.Id("last-name")).SendKeys("Rodriguez");
                    driver.FindElement(By.Id("postal-code")).SendKeys("20245");
                    Thread.Sleep(1000);
                    driver.FindElement(By.Id("continue")).Click();

                    Thread.Sleep(1000);

                    //Finish the purchase
                    driver.FindElement(By.Id("finish")).Click();
                    Thread.Sleep(1000);

                    driver.FindElement(By.Id("back-to-products")).Click();
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("❌ Login failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Error during execution: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
