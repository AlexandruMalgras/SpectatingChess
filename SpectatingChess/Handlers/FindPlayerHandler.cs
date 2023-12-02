using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectatingChess.Handlers
{
    public static class FindPlayerHandler
    {
        public static string FindPlayer(IWebDriver driver)
        {
            Console.WriteLine("Type player name...");

            string input = Console.ReadLine();

            driver.Navigate().GoToUrl("https://www.chess.com/member/" + input.ToLower());

            Thread.Sleep(1000);

            IWebElement element = ElementSearchHandler.FindElementByClass(driver, "subtitle");

            if (element != null)
            {
                if (element.Text == "The page you are looking for doesn’t exist. (404)")
                {
                    Console.WriteLine("Player does not exist");
                    FindPlayer(driver);
                }
            }

            return input;
        }
    }
}
