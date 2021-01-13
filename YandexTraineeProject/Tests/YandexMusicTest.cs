using System;
using System.Collections.Generic;
using System.Text;
using YandexTraineeProject.Data;
using NUnit.Framework;
using System.Threading;

namespace YandexTraineeProject
{
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

        [SetUp]
        public void SetUp()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_testData.YandexUrl);
        }

        [Test]
        public void CheckArtistName()
        {
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.ValidPassword);
            _loginPage.ClickLoginButton();
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            _mainPage.ClickNavigationBarButton(MainPage.MusicButton);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMusicPage.ClosePopUpMenu();
            _yandexMusicPage.ClickSearchLine();
            _yandexMusicPage.GetInputToSearchLine(_testData.MusicInputMetal);
            _yandexMusicPage.ChooseFirstLineDropDownLine();
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
            _mainPage.ClickEmailLoginButton();
            _loginPage.LoginInput(_testData.ValidLogin);
            _loginPage.ClickLoginButton();
            _loginPage.PasswordInput(_testData.ValidPassword);
            _loginPage.ClickLoginButton();
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            _mainPage.ClickNavigationBarButton(MainPage.MusicButton);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMusicPage.ClosePopUpMenu();
            _yandexMusicPage.ClickSearchLine();
            _yandexMusicPage.GetInputToSearchLine(_testData.MusicInputBeyo);
            _yandexMusicPage.ChooseFirstLineDropDownLine();
            _yandexMusicPage.ClickStopAndPlayFirstPopularSong();
            _yandexMusicPage.MakeScreenShot();
            _yandexMusicPage.ClickStopAndPlayFirstPopularSong();
            _yandexMusicPage.MakeScreenShot();
        }

        [TearDown]
        public void TearDown()
        {
            BrowserTabAction.CLoseLastTab(Driver);
            BrowserTabAction.OpenNewTab(Driver);
            BrowserTabAction.CLoseFirstTabTab(Driver);
        }
    }
}
