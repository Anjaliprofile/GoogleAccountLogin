using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleLoginScreen.CommonDrive
{
    public static class WaitExtention
    {
        // Wait for element 
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeOutinSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(d => d.FindElement(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverException($"Wait for Element {by} failed");
            }
        }      
    }
}

    