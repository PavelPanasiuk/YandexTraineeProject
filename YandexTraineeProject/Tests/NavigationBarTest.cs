using NUnit.Framework;
using YandexTraineeProject.Data;
using NUnit.Allure.Core;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    class NavigationBarTest : TestBase
    {
        private MainPage _mainPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public NavigationBarTest()
        {
            _mainPage = new MainPage(Driver);
            _jsonFile = new InfoFromJsonFile();
            _testData = _jsonFile.GetTestData();
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = _jsonFile.GetTestData();
            Driver.Manage().Window.Maximize();
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
            _mainPage.ClickNavigationBarButton(link);
            var currentUrl = Driver.SwitchTo().Window(Driver.WindowHandles[1]).Url;
            Assert.IsTrue(currentUrl.Contains(expectedresult));
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}
