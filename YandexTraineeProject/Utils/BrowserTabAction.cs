using OpenQA.Selenium;
using System.Linq;

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

        public static void SwitchToLastTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void SwitchToFirstTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }
    }
}
