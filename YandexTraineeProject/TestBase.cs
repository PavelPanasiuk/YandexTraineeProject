using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using YandexTraineeProject.Data;

namespace YandexTraineeProject
{
    public class TestBase 
    {
        protected IWebDriver Driver { get; }

        public TestBase()
        {
            var browser = "Chrome";

            if (!Enum.TryParse(browser, out BrowserType browserType))
            {
                throw new Exception("Browser parameter is not valid");
            }

            var driverFactory = new BrowserFactory();
            Driver = driverFactory.GetDriver(browserType);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

    }
}
