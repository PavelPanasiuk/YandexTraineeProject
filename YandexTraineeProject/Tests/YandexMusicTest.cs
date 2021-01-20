﻿using YandexTraineeProject.Data;
using NUnit.Framework; 
using NUnit.Allure.Core;


namespace YandexTraineeProject
{
    [TestFixture]
    [AllureNUnit]
    [Parallelizable]
    public class YandexMusicTest : TestBase
    {
        private MainPage _mainPage;
        private LoginPage _loginPage;
        private EmailPage _emailPage;
        private YandexMusicPage _yandexMusicPage;
        private InfoFromJsonFile _jsonFile;
        private TestData _testData;

        public YandexMusicTest()
        {
            _mainPage = new MainPage(Driver);
            _loginPage = new LoginPage(Driver);
            _emailPage = new EmailPage(Driver);
            _yandexMusicPage = new YandexMusicPage(Driver);
            _jsonFile = new InfoFromJsonFile();
            _testData = _jsonFile.GetTestData();
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.ValidPassword);
            _loginPage.ClickLoginButton();
            _emailPage.GoToMainPage();
        }

        [Test]
        public void CheckArtistName()
        {
            BrowserTabAction.CLoseFirstTab(Driver);
            _mainPage.ClickNavigationBarButton(MainPage.MusicButton);
            BrowserTabAction.SwitchToLastTab(Driver);
            _yandexMusicPage.ClosePopUpMenu();
            _yandexMusicPage.ClickSearchLine();
            _yandexMusicPage.GetInputToSearchLine(_testData.MusicInputMetal);
            _yandexMusicPage.ChooseFirstLineInDropDown();
            var artistName = _yandexMusicPage.GetArtistName();
            var popularAlbum = _yandexMusicPage.GetListOfPopularAlbums();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Metallica", artistName);
                Assert.IsTrue(popularAlbum);
            });
        }

        [Test]
        public void StartPlayingMusic()
        {
            _mainPage.ClickNavigationBarButton(MainPage.MusicButton);
            BrowserTabAction.SwitchToLastTab(Driver);
            _yandexMusicPage.ClosePopUpMenu();
            _yandexMusicPage.ClickSearchLine();
            _yandexMusicPage.GetInputToSearchLine(_testData.MusicInputBeyo);
            _yandexMusicPage.ChooseFirstLineInDropDown();
            _yandexMusicPage.ClickStopAndPlayFirstPopularSong();
            _yandexMusicPage.MakeScreenShot();
            _yandexMusicPage.ClickStopAndPlayFirstPopularSong();
            _yandexMusicPage.MakeScreenShot();
        }

        [TearDown]
        public void TearDown()
        {
            BrowserTabAction.CLoseFirstTab(Driver);
        }
    }
}
