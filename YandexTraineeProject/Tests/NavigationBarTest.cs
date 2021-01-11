using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YandexTraineeProject.Data;
using NUnit.Allure.Core;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    class NavigationBarTest : TestBase
    {
       private MainPage _mainPage;

        public NavigationBarTest()
        {
            _mainPage = new MainPage(Driver);
        }

        InfoFromJsonFile _jsonFile = new InfoFromJsonFile();
        TestData _testData;        

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = _jsonFile.GetTestData();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [TestCase(MainPage.ImageButton, "images")]
        [TestCase(MainPage.MapButton, "maps")]
        [TestCase(MainPage.MarketButton, "market")]
        [TestCase(MainPage.MusicButton, "music")]
        [TestCase(MainPage.NewsButton, "news")]
        [TestCase(MainPage.TranslateButton, "translate")]
        [TestCase(MainPage.VideoButton, "video")]
        public void NavigationBarLink(string link, string expectedresult)
        {
            var result = _mainPage.ClickNavigationBarButton(link);
            Assert.IsTrue(result.Contains(expectedresult));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}
