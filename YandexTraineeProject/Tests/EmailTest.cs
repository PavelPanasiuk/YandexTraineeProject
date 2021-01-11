using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using YandexTraineeProject.Data;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace YandexTraineeProject
{
    [AllureNUnit]
    public class EmailTest : TestBase
    {
        private MainPage _mainPage;
        private EmailPage _emailPage;
        private LoginPage _loginPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        // InfoFromJsonFile _jsonFile = new InfoFromJsonFile();
        //TestData _testData;
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
            Assert.AreEqual("AutotestUser", userName);
        }

        [Test]
        public void QuitFromEmailAccount()
        {
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.ValidPassword);
            _loginPage.ClickLoginButton();
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
            var errorText = Driver.FindElement(By.XPath(_testData.NotValidLoginOrPasswordMessage)).Text;
            Assert.IsNotNull(errorText);
        }

        [Test]
        public void UseNotValidLogin()
        {
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.NotValidLogin);
            _loginPage.ClickLoginButton();
            Thread.Sleep(2000);
            var errorText = Driver.FindElement(By.XPath(_testData.NotValidLoginOrPasswordMessage)).Text;
            Assert.IsNotNull(errorText);
        }
    }
}
