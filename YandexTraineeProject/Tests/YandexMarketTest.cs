using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Allure.Core;
using YandexTraineeProject.Data;
using System.Threading;


namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    class YandexMarketTest 
    {
        static IWebDriver Driver = new ChromeDriver();

        MainPage _mainPage = new MainPage(Driver);
        YandexMarketPage _yandexMarketPage = new YandexMarketPage(Driver);
        InfoFromJsonFile _jsonFile = new InfoFromJsonFile();
        TestData _testData;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = _jsonFile.GetTestData();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }


        [Test]
        public void SameTwoProducts()
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            Thread.Sleep(1000);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMarketPage.ClickSearchLine();
            Thread.Sleep(1000);
            _yandexMarketPage.InputSearchText(_testData.MarketSearchText);
            Thread.Sleep(1000);
            _yandexMarketPage.ClickSearchButton();
            Thread.Sleep(1000);
            _yandexMarketPage.AddProductsForComparison();

            
        }

    }
}
