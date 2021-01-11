using System.Threading;
using NUnit.Framework;
using NUnit.Allure.Core;



namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    class LanguageTest : TestsBase
    {
        LanguagePage _languagePage = new LanguagePage();
        MainPage _mainPage = new MainPage();


        [SetUp]
        public void SetUp()
        {
            // _driver.Manage().Window.Maximize();
            // _driver.Navigate().GoToUrl("https://yandex.by/");
        }

        [Test]
        public void SwitchLanguage()
        {
            Thread.Sleep(1000);
            _mainPage.ClickLanguageButton(Driver);
            Thread.Sleep(1000);
            _mainPage.ClickLanguageOptionsButton(Driver);
            Thread.Sleep(1000);
            _languagePage.ClickLanguageMenu(Driver);
            _languagePage.SelectUkraineLanguage(Driver);
            Thread.Sleep(1000);
            _languagePage.ClickSaveLanguageButton(Driver);
            var actualLanguage = _mainPage.GetLanguageName(Driver);
            Assert.AreEqual("Ukr", actualLanguage);
        }
    }
}
