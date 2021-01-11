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
    public class Location : TestBase
    {
       private LocationPage _locationPage;
      private  MainPage _mainPage;

        public Location(IWebDriver Driver)
        {
            _locationPage = new LocationPage(Driver);
            _mainPage = new MainPage(Driver);
        }

        InfoFromJsonFile _jsonFile = new InfoFromJsonFile();
        TestData _testData;

        [SetUp]
        public void Setup()
        {
            _testData = _jsonFile.GetTestData();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void CompareElseButtonElements()
        {
            _mainPage.ClickLocationButton();
            _locationPage.ChangeLocation(_testData.LocationLondon);
            var elseButtonLondon = _mainPage.GetListOfElseMenuElements();
            Thread.Sleep(1000);

            _mainPage.ClickLocationButton();
            _locationPage.ChangeLocation(_testData.LocationParis);
            var elseButtonParis = _mainPage.GetListOfElseMenuElements();
            Thread.Sleep(1000);

            Assert.AreEqual(elseButtonLondon, elseButtonParis);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}