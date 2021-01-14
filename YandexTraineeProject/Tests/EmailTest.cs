using NUnit.Framework;
using YandexTraineeProject.Data;
using NUnit.Allure.Core;
using System;

namespace YandexTraineeProject
{
    [AllureNUnit]
    [TestFixture]
    public class EmailTest : TestBase 
    {
        private MainPage _mainPage;
        private EmailPage _emailPage;
        private LoginPage _loginPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public EmailTest()
        {
            _mainPage = new MainPage(Driver);
            _emailPage = new EmailPage(Driver);
            _loginPage = new LoginPage(Driver);
            _jsonFile = new InfoFromJsonFile();
            _testData = _jsonFile.GetTestData();
        }

        [SetUp]
        public void Setup()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void OpenEmail_CheckUserName()
        {
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.ValidPassword);
            _loginPage.ClickLoginButton();
            var userName = _emailPage.GetUserName();
            Assert.AreEqual(_testData.ValidLogin, userName);
        }

        [Test]
        public void QuitFromEmailAccount()
        {
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.ValidPassword);
            _loginPage.ClickLoginButton();
            var emailPageUrl = Driver.Url;
            _emailPage.LogOut();
            var currentUrl = Driver.Url;
            Assert.AreNotEqual(emailPageUrl, currentUrl);
        }

        [Test]
        public void UseNotValidPassword()
        {
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.NotValidPassword);
            _loginPage.ClickLoginButton();
            var errorText = _loginPage.GetErrorMessage(_testData.NotValidLoginOrPasswordMessage);
            Assert.IsNotNull(errorText);
        }

        [Test]
        public void UseNotValidLogin()
        {
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.NotValidLogin);
            _loginPage.ClickLoginButton();
            var errorText = _loginPage.GetErrorMessage(_testData.NotValidLoginOrPasswordMessage);
            Assert.IsNotNull(errorText);
        }

        [TearDown]
        public void TearDown()
        {
            BrowserTabAction.CLoseLastTab(Driver);
            BrowserTabAction.OpenNewTab(Driver);
            BrowserTabAction.CLoseFirstTab(Driver);
        }
    }
}
