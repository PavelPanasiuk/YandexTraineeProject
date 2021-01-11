using System.Threading;
using NUnit.Framework;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    class LanguageTest : TestBase
    {
        private LanguagePage _languagePage;
        private MainPage _mainPage;

        public LanguageTest(IWebDriver driver)
        {
            _languagePage = new LanguagePage(Driver);
            _mainPage = new MainPage(Driver);
        }

        [Test]
        public void SwitchLanguage()
        {
            Thread.Sleep(1000);
            _mainPage.ClickLanguageButton();
            Thread.Sleep(1000);
            _mainPage.ClickLanguageOptionsButton();
            Thread.Sleep(1000);
            _languagePage.ClickLanguageMenu();
            _languagePage.SelectUkraineLanguage();
            Thread.Sleep(1000);
            _languagePage.ClickSaveLanguageButton();
            var actualLanguage = _mainPage.GetLanguageName();
            Assert.AreEqual("Ukr", actualLanguage);
        }
    }
}
