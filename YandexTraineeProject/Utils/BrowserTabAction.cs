using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace YandexTraineeProject
{
    public class BrowserTabAction
    {
        public static void CLoseLastTab(IWebDriver driver)
        {
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                driver.SwitchTo().Window(tabs[1]);
                driver.Close();
                driver.SwitchTo().Window(tabs[0]);
            }
        }

        public static void CLoseFirstTab(IWebDriver driver)
        {
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                driver.SwitchTo().Window(tabs[1]);
                driver.Close();
                driver.SwitchTo().Window(tabs[0]);
            }
        }

        public static void SwitchToLastTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void SwitchToFirstTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        public static void OpenNewTab(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open()");
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[0]);
        }
    }
}
