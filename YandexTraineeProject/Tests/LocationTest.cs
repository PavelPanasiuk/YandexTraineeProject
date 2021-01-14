using NUnit.Framework;
using YandexTraineeProject.Data;
using NUnit.Allure.Core;
using System;

namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    public class Location : TestBase
    {
        private LocationPage _locationPage;
        private MainPage _mainPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public Location()
        {
            _locationPage = new LocationPage(Driver);
            _mainPage = new MainPage(Driver);
            _jsonFile = new InfoFromJsonFile();
            _testData = _jsonFile.GetTestData();
        }

        [SetUp]
        public void Setup()
        {
            _testData = _jsonFile.GetTestData();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void CompareElseButtonElements()
        {
            _mainPage.ClickLocationButton();
            _locationPage.ClickSearchLine();
            _locationPage.ClearSearchLine();
            _locationPage.InputLocationName(_testData.LocationLondon);
            _locationPage.ClickSearchLine();
            _locationPage.SelectLocation();
            var elseButtonLondon = _mainPage.GetListOfElseMenuElements();

            _mainPage.ClickLocationButton();
            _locationPage.ClickSearchLine();
            _locationPage.ClearSearchLine();
            _locationPage.InputLocationName(_testData.LocationParis);
            _locationPage.ClickSearchLine();
            _locationPage.SelectLocation();
            var elseButtonParis = _mainPage.GetListOfElseMenuElements();

            Assert.AreEqual(elseButtonLondon, elseButtonParis);
        }
    }
}