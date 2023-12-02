using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
}
