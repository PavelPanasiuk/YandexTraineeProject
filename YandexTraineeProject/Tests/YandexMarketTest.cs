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
    class YandexMarketTest : TestBase
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
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void ComparisonTwoProducts()//ToDo не жмет кнопку добавить для сравнения
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMarketPage.ClickSearchLine();
            _yandexMarketPage.InputSearchText(_testData.MarketSearchText);
            _yandexMarketPage.ClickSearchButton();
            _yandexMarketPage.AddProductsForComparison();
            _yandexMarketPage.ClickCompariButton();
            var result = _yandexMarketPage.GetListOfProductsForComparison();
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteComparisonProducts()//ToDo не жмет кнопку добавить для сравнения
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMarketPage.ClickSearchLine();
            _yandexMarketPage.InputSearchText(_testData.MarketSearchText);
            _yandexMarketPage.ClickSearchButton();
            _yandexMarketPage.AddProductsForComparison();
            _yandexMarketPage.ClickCompariButton();
            _yandexMarketPage.ClickDeleteAllProductsFromComparisonListButton();
            var result = _yandexMarketPage.GetListOfProductsForComparison();
            Assert.IsNotNull(result);
        }

        [Test]
        public void SortingTabletsByPrise()
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMarketPage.ClickElectronikCategory();
            _yandexMarketPage.ClickTabletButton();
            _yandexMarketPage.ClickSortingButtonByPrice();
            _yandexMarketPage.SortPriceListDescending();
            var typeOfsort = _yandexMarketPage.GetTypeOfPriceSorting();
            Assert.AreEqual("dprice", typeOfsort);
        }

        [Test]
        public void SortingFridgeByTag() //ToDo не жмет кнопку ввода ширины
        {
            _mainPage.ClickNavigationBarButton(MainPage.MarketButton);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMarketPage.ClickHouseholAppliancesCategory();
            _yandexMarketPage.ClickFridgeButton();
            _yandexMarketPage.ClickFridgeWidthLine();
            _yandexMarketPage.IputFridgeWidth(_testData.FridgeWidth);
            var tagMessage = _yandexMarketPage.GetTagMessage();
            Assert.IsTrue(tagMessage.Contains(_testData.FridgeWidth));
        }

    }
}
