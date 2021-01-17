using System;
using OpenQA.Selenium;
using NUnit.Framework;
using YandexTraineeProject.Data;

namespace YandexTraineeProject
{
    public class TestBase
    {
        protected IWebDriver Driver { get; set; }

        public TestBase()
        {
            //var browser = TestContext.Parameters.Get("browser");
            var browser = "Chrome";

            if (!Enum.TryParse(browser, out BrowserType browserType))
            {
                throw new Exception("Browser parameter is not valid");
            }

            var driverFactory = new BrowserFactory();
            Driver = driverFactory.GetDriver(browserType);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
