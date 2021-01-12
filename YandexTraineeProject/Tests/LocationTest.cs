using NUnit.Framework;
using YandexTraineeProject.Data;
using NUnit.Allure.Core;

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
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void CompareElseButtonElements()
        {
            _mainPage.ClickLocationButton();
            _locationPage.ChangeLocation(_testData.LocationLondon);
            _locationPage.SelectLocation();
            var elseButtonLondon = _mainPage.GetListOfElseMenuElements();          

            _mainPage.ClickLocationButton();
            _locationPage.ChangeLocation(_testData.LocationParis);
            _locationPage.SelectLocation();
            var elseButtonParis = _mainPage.GetListOfElseMenuElements();         

            Assert.AreEqual(elseButtonLondon, elseButtonParis);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}