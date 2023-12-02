using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SpectatingChess.Handlers;
using System.Threading;
using WindowsInput;


class Program
{
    static void Main(string[] args)
    {
        using (var driver = new ChromeDriver())
        {
            driver.Manage().Window.Maximize();

            AdBlockHandler.InstallAdBlock(driver);

            LoginHandler.NavigateToLoginPage(driver);

            // Give time for the navigation to complete
            Thread.Sleep(1000);

            LoginHandler.Login(driver);

            // Give time for the login to complete
            Thread.Sleep(2000);

            string username = FindPlayerHandler.FindPlayer(driver);
            string url = "https://www.chess.com/member/" + username.ToLower();

            SpectateHandler.Spectate(driver, url, username);
        }
    }
}
