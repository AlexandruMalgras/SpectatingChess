using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SpectatingChess.Handlers
{
    public static class LoginHandler
    {
        private static string username = "";
        private static string password = "";

        private const string loginPageUrl = "https://www.chess.com/login_and_go?returnUrl=https://www.chess.com/";

        public static void NavigateToLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.chess.com");

            // Wait for the navigation to complete.
            Thread.Sleep(2000);

            IWebElement loginButton = ElementSearchHandler.FindElementByCssSelector(driver, "a.button.auth.login.ui_v5-button-component.ui_v5-button-primary");

            // Check if the login button exists, otherwise retry the process.
            if (loginButton == null)
            {
                NavigateToLoginPage(driver);
            }

            loginButton.Click();
        }

        public static void Login(IWebDriver driver)
        {
            // Check if the browser is at the right url to start the login process
            if (driver.Url != loginPageUrl)
            {
                driver.Navigate().GoToUrl(loginPageUrl);

                // Wait for the navigation to complete
                Thread.Sleep(2000);
            }

            IWebElement usernameInput = ElementSearchHandler.FindElementById(driver, "username");

            if (usernameInput == null) Login(driver);

            IWebElement passwordInput = ElementSearchHandler.FindElementById(driver, "password");

            if (passwordInput == null) Login(driver);

            SetCredentials("Login username...", out username);
            SetCredentials("Login password", out password);

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);

            IWebElement authenticateButton = ElementSearchHandler.FindElementById(driver, "login");

            if (authenticateButton == null) Login(driver);

            authenticateButton.Click();

            // Wait for the navigation to complete.
            Thread.Sleep(2000);

            // If the login failed repeat the process.
            if (driver.Url == loginPageUrl)
            {
                Login(driver);
            }
        }

        private static void SetCredentials(string displayText, out string credential)
        {
            Console.WriteLine(displayText);
            credential = Console.ReadLine();
        }
    }
}
