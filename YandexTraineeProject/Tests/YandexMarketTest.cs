﻿using NUnit.Framework;
using NUnit.Allure.Core;
using YandexTraineeProject.Data;
using System;
using System.Threading;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    public class YandexMarketTest : TestBase
    {
        private MainPage _mainPage;
        private YandexMarketPage _yandexMarketPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public YandexMarketTest()
        {
            _mainPage = new MainPage(Driver);
            _yandexMarketPage = new YandexMarketPage(Driver);
            _jsonFile = new InfoFromJsonFile();
            _testData = _jsonFile.GetTestData();
        }

        [SetUp]
        public void SetUp()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void ComparisonTwoProducts()
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            BrowserTabAction.SwitchToLastTab(Driver);
            _yandexMarketPage.ClickSearchLine();
            _yandexMarketPage.InputSearchLine(_testData.MarketSearchText);
            _yandexMarketPage.ClickSearchButton();
            _yandexMarketPage.AddProductsForComparison();
            _yandexMarketPage.ClickCompariButton();
            var result = _yandexMarketPage.GetListOfProductsForComparison();
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteComparisonProducts()
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            BrowserTabAction.SwitchToLastTab(Driver);
            _yandexMarketPage.ClickSearchLine();
            _yandexMarketPage.InputSearchLine(_testData.MarketSearchText);
            _yandexMarketPage.ClickSearchButton();
            _yandexMarketPage.AddProductsForComparison();
            _yandexMarketPage.ClickCompariButton();
            _yandexMarketPage.DeleteProductsFromComparisonList();
            var result = _yandexMarketPage.GetListOfProductsForComparison();
            Assert.IsNotNull(result);
        }

        [Test]
        public void SortingTabletsByPrise()
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            BrowserTabAction.SwitchToLastTab(Driver);
            _yandexMarketPage.ClickElectronikCategory();
            _yandexMarketPage.ClickTabletButton();
            _yandexMarketPage.ClickSortingButtonByPrice();
            _yandexMarketPage.SortPriceListDescending();
            var typeOfsort = _yandexMarketPage.GetTypeOfPriceSorting();
            Assert.AreEqual("dprice", typeOfsort);
        }

        [Test]
        public void SortingFridgeByTag()
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            BrowserTabAction.SwitchToLastTab(Driver);
            _yandexMarketPage.ClickHouseholAppliancesCategory();
            _yandexMarketPage.ClosePopUpMenu();
            _yandexMarketPage.ClickFridgeButton();
            _yandexMarketPage.ClickFridgeWidthLine();
            _yandexMarketPage.IputFridgeWidth(_testData.FridgeWidth);
            var tagMessage = _yandexMarketPage.GetTagMessage();
            Assert.IsTrue(tagMessage.Contains(_testData.FridgeWidth));
        }

        [TearDown]
        public new void TearDown()
        {
            Thread.Sleep(2000);
            BrowserTabAction.CLoseLastTab(Driver);
            BrowserTabAction.OpenNewTab(Driver);
            BrowserTabAction.CLoseFirstTab(Driver);
        }

    }
}
