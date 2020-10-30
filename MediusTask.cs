using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace AutomationTools 
{
    class Program
    {
     
        public static IWebElement SendKeys { get; private set; }
        public static IWebElement Click { get; private set; }


        static void Main(string[] args)
        { //Hi! I marked the steps of the excerise and added some time breaks in between for more clearness. Enjoy:

            //1.Open browser and go to webside

            IWebDriver ChromeDriver = new ChromeDriver();

            ChromeDriver.Navigate().GoToUrl("http://demo.opencart.com/");
            ChromeDriver.Manage().Window.Maximize();

            Thread.Sleep(3000);

            //2.Change currency to GBP


            ChromeDriver.FindElement(By.XPath("//html/body/nav/div/div[1]/form/div/button")).Click();

            Thread.Sleep(3000);

            ChromeDriver.FindElement(By.Name("GBP")).Click();

            Thread.Sleep(2000);

                   
            //3.Search for “iPod” using text search

            ChromeDriver.FindElement(By.Name("search")).SendKeys("iPod" + Keys.Enter);
            Thread.Sleep(2000);


            //4.Add all iPods returned in search results to product comparison

            ChromeDriver.FindElement(By.XPath("//html/body/div[2]/div/div/div[3]/div[1]/div/div[2]/div[2]/button[3]")).Click();
            Thread.Sleep(2000);

            ChromeDriver.FindElement(By.XPath("//html/body/div[2]/div/div/div[3]/div[2]/div/div[2]/div[2]/button[3]")).Click();
            Thread.Sleep(2000);

            ChromeDriver.FindElement(By.XPath("//html/body/div[2]/div/div/div[3]/div[3]/div/div[2]/div[2]/button[3]")).Click();
            Thread.Sleep(2000);

            ChromeDriver.FindElement(By.XPath("//html/body/div[2]/div/div/div[3]/div[4]/div/div[2]/div[2]/button[3]")).Click();
            Thread.Sleep(2000);

            //5.View product comparison page

            ChromeDriver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=product/compare");


            //6.Remove iPod Shuffle from comparison

            ChromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/table/tbody[2]/tr/td[4]/a")).Click();

            Thread.Sleep(2000);


            //7.Add a random one to the shopping cart

            ChromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/table/tbody[2]/tr/td[4]/input")).Click();

            Thread.Sleep(2000);



            //8. Go to the shopping cart 


            ChromeDriver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=checkout/cart");

            Thread.Sleep(6000);


            //COMMENT: My price comparison was manual (visual wouuld be more like it). I wasn't able to figure out yet how to extract the actual values from the webside and compare them.
            // But I did write a pretty 'if' statement below, that probably would be useful in other circumstances ;-) 
            {

                var price = "£92.03";

                var total = "£92.03";




                if (total.ToString() == price)

                {
                    Console.WriteLine("...:::Total pice matches the one from comparison:::...");
                }
                else
                {
                    Console.WriteLine("...:::Total pice does not match the one from comparison:::...");
                }

                //Closing the browser

                ChromeDriver.Quit();
            }




        }
    }
}