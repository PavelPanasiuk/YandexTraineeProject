using NUnit.Framework;
using YandexTraineeProject.Data;
using NUnit.Allure.Core;
using System.Threading;

namespace YandexTraineeProject
{
    [AllureNUnit]
    [TestFixture]
    public class ValidLoginPasswordEmailTest : TestBase
    {
        private MainPage _mainPage;
        private EmailPage _emailPage;
        private LoginPage _loginPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public ValidLoginPasswordEmailTest()
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
            Driver.Manage().Cookies.DeleteAllCookies();
            Assert.AreEqual(_testData.ValidLogin, userName);
        }

        [Test]       
        public void QuitFromEmailAccount()
        {
            BrowserTabAction.CLoseLastTab(Driver);
            Driver.Manage().Cookies.DeleteAllCookies();
            _mainPage.ClickEmailLoginButton();

            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.ValidPassword);
            _loginPage.ClickLoginButton();
            var emailPageUrl = Driver.Url;
            _emailPage.ClickAccountOptionsButton();
            var currentUrl = Driver.Url;
            _emailPage.ClickLogOut();
            Driver.Manage().Cookies.DeleteAllCookies();
            Assert.AreNotEqual(emailPageUrl, currentUrl);
        }

        [TearDown]
        public void TearDown()
        {
            BrowserTabAction.SwitchToFirstTab(Driver);
            BrowserTabAction.CLoseLastTab(Driver);
        }
    }

    [AllureNUnit]
    [TestFixture]
    public class NotValidLoginPasswordEmailTest : TestBase
    {
        private MainPage _mainPage;
        private LoginPage _loginPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public NotValidLoginPasswordEmailTest()
        {
            _mainPage = new MainPage(Driver);
            _loginPage = new LoginPage(Driver);
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
        public void UseNotValidLogin()
        {            
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.NotValidLogin);
            _loginPage.ClickLoginButton();
            var errorText = _loginPage.GetErrorMessage(_testData.NotValidLoginOrPasswordMessage);
            Assert.IsNotNull(errorText);
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

        [TearDown]
        public void TearDown()
        {
            BrowserTabAction.SwitchToFirstTab(Driver);
            BrowserTabAction.CLoseLastTab(Driver);
        }
    }
}
