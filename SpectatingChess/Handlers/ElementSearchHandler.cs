using OpenQA.Selenium;

namespace SpectatingChess.Handlers
{
    public static class ElementSearchHandler
    {
        public static IWebElement FindElementByClass(IWebDriver driver, string elementClassName)
        {
            IWebElement temporary = null;

            try
            {
                temporary = driver.FindElement(By.ClassName(elementClassName));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element " + elementClassName + " does not exist.");
            }

            return temporary;
        }

        public static IWebElement FindElementByClass(IWebElement element, string elementClassName)
        {
            IWebElement temporary = null;

            try
            {
                temporary = element.FindElement(By.ClassName(elementClassName));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element " + elementClassName + " does not exist.");
            }

            return temporary;
        }

        public static IWebElement FindElementByCssSelector(IWebDriver driver, string elementCssSelector)
        {
            IWebElement temporary = null;

            try
            {
                temporary = driver.FindElement(By.CssSelector(elementCssSelector));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element " + elementCssSelector + " does not exist.");
            }

            return temporary;
        }

        public static IWebElement FindElementByCssSelector(IWebElement element, string elementCssSelector)
        {
            IWebElement temporary = null;

            try
            {
                temporary = element.FindElement(By.CssSelector(elementCssSelector));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element " + elementCssSelector + " does not exist.");
            }

            return temporary;
        }

        public static IWebElement FindElementById(IWebDriver driver, string elementId)
        {
            IWebElement temporary = null;

            try
            {
                temporary = driver.FindElement(By.Id(elementId));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element " + elementId + " does not exist.");
            }

            return temporary;
        }

        public static IWebElement FindElementById(IWebElement element, string elementId)
        {
            IWebElement temporary = null;

            try
            {
                temporary = element.FindElement(By.Id(elementId));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element " + elementId + " does not exist.");
            }

            return temporary;
        }
    }
}
