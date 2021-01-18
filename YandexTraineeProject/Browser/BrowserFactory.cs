using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace YandexTraineeProject
{
    public class BrowserFactory
    {
        public IWebDriver GetDriver(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                default:
                    throw new Exception("This browser is not supported.");
            }
        }
    }
}
