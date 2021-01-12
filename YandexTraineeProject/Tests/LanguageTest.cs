using NUnit.Framework;
using NUnit.Allure.Core;
using YandexTraineeProject.Data;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    class LanguageTest : TestBase
    {
        private LanguagePage _languagePage;
        private MainPage _mainPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public LanguageTest()
        {
            _languagePage = new LanguagePage(Driver);
            _mainPage = new MainPage(Driver);
            _jsonFile = new InfoFromJsonFile();
            _testData = _jsonFile.GetTestData();
        }

        [SetUp]
        public void Setup()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void SwitchLanguage()
        {
            _mainPage.ClickLanguageButton();
            _mainPage.ClickLanguageOptionsButton();
            _languagePage.ClickLanguageMenu();
            _languagePage.SelectUkraineLanguage();
            _languagePage.ClickSaveLanguageButton();
            var actualLanguage = _mainPage.GetLanguageName();
            Assert.AreEqual("Ukr", actualLanguage);
        }
    }
}
