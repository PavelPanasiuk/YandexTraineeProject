using System;
using OpenQA.Selenium;
using NUnit.Framework;
using YandexTraineeProject.Data;

namespace YandexTraineeProject
{
    public class TestsBase
    {
        public IWebDriver Driver { get; }

        InfoFromJsonFile _jsonFile = new InfoFromJsonFile();
        TestData _testData;

        protected TestsBase()
        {
            var browser = "Chrome";
            
            if (!Enum.TryParse(browser, out BrowserType browserType))
            {                
                throw new Exception("Browser parameter is not valid");
            }
            var driverFactory = new BrowserFactory();
            Driver = driverFactory.GetDriver(browserType);
        }

        [SetUp]
        public void Setup()
        {
            _testData = _jsonFile.GetTestData();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
