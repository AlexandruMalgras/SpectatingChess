using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectatingChess.Handlers
{
    public static class SpectateHandler
    {
        public static void Spectate(IWebDriver driver, string profileUrl, string username)
        {
            bool isInGame = false;

            while (!isInGame)
            {
                // Check every 10 seconds if the player is in game.
                Thread.Sleep(10000);

                isInGame = IsInProfile(driver);
            }

            Thread.Sleep(2000);

            SwitchBoard(driver, profileUrl, username);

            while (isInGame)
            {
                Thread.Sleep(5000);

                isInGame = IsInGame(driver, profileUrl, username);
            }

            Spectate(driver, profileUrl, username);
        }

        public static bool IsInGame(IWebDriver driver, string profileUrl, string username)
        {
            bool isInGame = true;

            IWebElement gameOverScreen = ElementSearchHandler.FindElementByClass(driver, "game-over-header-component");

            bool isScreenPresent = gameOverScreen != null ? true : false;

            if (isScreenPresent)
            {
                driver.Navigate().GoToUrl(profileUrl);
                isInGame = false;
            }

            return isInGame;
        }

        public static bool IsInProfile(IWebDriver driver)
        {
            bool isInGame = false;

            IWebElement spectateButton = ElementSearchHandler.FindElementByClass(driver, "ui_v5-button-danger");

            bool isButtonPresent = spectateButton != null ? true : false;

            if (isButtonPresent)
            {
                spectateButton.Click();
                isInGame = true;
            }
            else
            {
                RefreshPage(driver);
            }

            return isInGame;
        }

        public static void RefreshPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            Console.WriteLine("Page refreshed at " + DateTime.Now);
        }

        public static void SwitchBoard(IWebDriver driver, string profileUrl, string username)
        {
            IWebElement playerBottom = ElementSearchHandler.FindElementById(driver, "board-layout-player-bottom");

            if (playerBottom == null)
                return;

            IWebElement playerBottomTagline = ElementSearchHandler.FindElementByClass(playerBottom, "user-tagline-component");

            if (playerBottomTagline == null)
                return;

            IWebElement playerBottomName = ElementSearchHandler.FindElementByClass(playerBottomTagline, "user-username-white");

            if (playerBottomName == null)
                return;

            string user_name = playerBottomName.Text;

            if (user_name == username)
            {
                Console.WriteLine("Board did not switch");
                return;
            }

            IWebElement liveGameButtons = ElementSearchHandler.FindElementByClass(driver, "live-game-buttons-component");

            if (liveGameButtons == null)
                return;

            IWebElement switchButton = ElementSearchHandler.FindElementByCssSelector(liveGameButtons, "[data-cy='move-list-button-flip']");

            if (switchButton == null)
                return;

            switchButton.Click();

            Console.WriteLine("Board switch.");
        }
    }
}
