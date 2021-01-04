using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace YandexTraineeProject
{
    [TestFixture]
    public class Tests
    {

        LocationPage mainYandexPage = new LocationPage();
        ElseButtonMenuLondon _london = new ElseButtonMenuLondon();
        ElseButtonMenuParis _paris = new ElseButtonMenuParis();
        BrowserInitialization Driver = new BrowserInitialization(BrowserType.Chrome);


        [SetUp]
        public void Setup()
        {
            Driver.Driver.Manage().Window.Maximize();
            Driver.Driver.Navigate().GoToUrl(BaseData._serchUrl);
        }

        [Test]
        public void Test1()
        {
            mainYandexPage.ChangeLocation(Driver.Driver, BaseData._london);
            //Thread.Sleep(2000);
            var elseLondon = _london.GetListOfLondonElseMenuElements(Driver.Driver);
            //Thread.Sleep(1000);

            mainYandexPage.ChangeLocation(Driver.Driver, BaseData._paris);
           // Thread.Sleep(2000);
            var elseParis = _paris.GetListOfParisElseMenuElements(Driver.Driver);

            Assert.AreEqual(elseLondon, elseParis);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Driver.Quit();
        }
    }
}