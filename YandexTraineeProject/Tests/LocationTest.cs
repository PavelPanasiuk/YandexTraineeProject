using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using YandexTraineeProject.Data;
using NUnit.Allure.Core;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    public class Location : TestsBase
    {       
        LocationPage _locationPage = new LocationPage();
        MainPage _mainPage = new MainPage();

        InfoFromJsonFile _jsonFile = new InfoFromJsonFile();
        TestData _testData;

        [SetUp]
        public void Setup()
        {
            _testData = _jsonFile.GetTestData();
           // _driver.Manage().Window.Maximize();
           // _driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void CompareElseButtonElements()
        {
            _mainPage.ClickLocationButton(Driver);
            _locationPage.ChangeLocation(Driver, _testData.LocationLondon);
            var elseButtonLondon = _mainPage.GetListOfElseMenuElements(Driver);
            Thread.Sleep(1000);

            _mainPage.ClickLocationButton(Driver);
            _locationPage.ChangeLocation(Driver, _testData.LocationParis);
            var elseButtonParis = _mainPage.GetListOfElseMenuElements(Driver);
            Thread.Sleep(1000);

            Assert.AreEqual(elseButtonLondon, elseButtonParis);
        }        
    }
}