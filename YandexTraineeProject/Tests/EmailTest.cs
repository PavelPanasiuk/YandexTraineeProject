using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using YandexTraineeProject.Data;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    public class EmailTest : TestsBase
    {
        MainPage _mainPage = new MainPage();
        EmailPage _emailPage = new EmailPage();
        LoginPage _loginPage = new LoginPage();

        InfoFromJsonFile _jsonFile = new InfoFromJsonFile();
        TestData _testData;

        [OneTimeSetUp]
        public void Setup()
        {
           // _testData = _jsonFile.GetTestData();
            //Driver.Manage().Window.Maximize();
            //Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void OpenEmail_CheckUserName()
        {
            _mainPage.ClickEmailLoginButton(Driver);
            _loginPage.LoginInput(Driver, _testData.ValidLogin);
            _loginPage.ClickLoginButton(Driver);
            _loginPage.PasswordInput(Driver, _testData.ValidPassword);
            _loginPage.ClickLoginButton(Driver);
            var userName = _emailPage.GetUserName(Driver);
            Assert.AreEqual("AutotestUser", userName);
        }

        [Test]
        public void QuitFromEmailAccount()
        {
            _mainPage.ClickEmailLoginButton(Driver);
            _loginPage.LoginInput(Driver, _testData.ValidLogin);
            _loginPage.ClickLoginButton(Driver);
            _loginPage.PasswordInput(Driver, _testData.ValidPassword);
            _loginPage.ClickLoginButton(Driver);
            Thread.Sleep(2000);
            var emailPageUrl = Driver.Url;
            _emailPage.LogOut(Driver);
            var currentUrl = Driver.Url;
            Assert.AreNotEqual(emailPageUrl, currentUrl);
        }

        [Test]
        public void UseNotValidPassword()
        {
            _mainPage.ClickEmailLoginButton(Driver);
            _loginPage.LoginInput(Driver, _testData.ValidLogin);
            _loginPage.ClickLoginButton(Driver);
            _loginPage.PasswordInput(Driver, _testData.NotValidPassword);
            _loginPage.ClickLoginButton(Driver);
            Thread.Sleep(2000);
            var errorText = Driver.FindElement(By.XPath(_testData.NotValidLoginOrPasswordMessage)).Text;
            Assert.IsNotNull(errorText);
        }

        [Test]
        public void UsseNoValidLogin()
        {
            _mainPage.ClickEmailLoginButton(Driver);
            _loginPage.LoginInput(Driver, _testData.NotValidLogin);
            _loginPage.ClickLoginButton(Driver);
            Thread.Sleep(2000);
            var errorText = Driver.FindElement(By.XPath(_testData.NotValidLoginOrPasswordMessage)).Text;
            Assert.IsNotNull(errorText);
        }
    }
}
