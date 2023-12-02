using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace SpectatingChess.Handlers
{
    public static class AdBlockHandler
    {
        private const string extensionUrl = "https://chrome.google.com/webstore/detail/adguard-adblocker/bgnkhhnnamicmpeenaelnjfhikgbkllg";

        public static void InstallAdBlock(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(extensionUrl);

            Thread.Sleep(2000);

            if (driver.Url != extensionUrl)
            {
                InstallAdBlock(driver);
            }

            string currentWindowHandle = driver.CurrentWindowHandle;

            ClickAddExtension(driver, currentWindowHandle);

            Thread.Sleep(1000);

            AcceptDownload();
           
            // Wait for the adblock page to open.
            Thread.Sleep(20000);

            CloseTabs(driver, currentWindowHandle);
        }

        private static void ClickAddExtension(IWebDriver driver, string windowHandle)
        {
            IWebElement addExtensionButton = ElementSearchHandler.FindElementByCssSelector(driver, "div[role='button'][aria-label='Add to Chrome']");

            addExtensionButton.Click();
        }

        private static void AcceptDownload()
        {
            InputSimulator simulator = new InputSimulator();

            simulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);
            simulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
        }

        private static void CloseTabs(IWebDriver driver, string windowHandle)
        {
            foreach (string handle in driver.WindowHandles)
            {
                if (handle != windowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    driver.Close();
                }
            }

            driver.SwitchTo().Window(windowHandle);
        }
    }
}
