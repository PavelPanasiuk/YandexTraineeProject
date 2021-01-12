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
        static IWebDriver Driver = new ChromeDriver();

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
        public void SameTwoProducts()
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

    }
}
