using System;
using System.Collections.Generic;
using System.Text;
using YandexTraineeProject.Data;
using NUnit.Framework;
using System.Threading;

namespace YandexTraineeProject
{
    class YandexMusicTest : TestBase
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
            Thread.Sleep(1000);
            _yandexMusicPage.ClickSearchLine();
            Thread.Sleep(1000);
            _yandexMusicPage.GetInputToSearchLine(_testData.MusicInputMetal);
            Thread.Sleep(1000);
            _yandexMusicPage.ChooseFirstLineDropDownLine();
            Thread.Sleep(2000);
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
            Thread.Sleep(1000);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            _mainPage.ClickNavigationBarButton(MainPage.MusicButton);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            _yandexMusicPage.ClosePopUpMenu();
            Thread.Sleep(1000);
            _yandexMusicPage.ClickSearchLine();
            Thread.Sleep(1000);
            _yandexMusicPage.GetInputToSearchLine(_testData.MusicInputBeyo);
            Thread.Sleep(1000);
            _yandexMusicPage.ChooseFirstLineDropDownLine();
            Thread.Sleep(2000);

            _yandexMusicPage.JSexecutor();            
           // _yandexMusicPage.MoveMouseToElement();
            Thread.Sleep(3000);

           // _yandexMusicPage.ClickToStartButtonFirstPopularSong();
           // Thread.Sleep(1000);
           // _yandexMusicPage.MakeScreenShot();
            // _yandexMusicPage.ClickToStartButtonFirstPopularSong();
           // _yandexMusicPage.JSexecutor();
          //  Thread.Sleep(1000);
          //  _yandexMusicPage.MakeScreenShot1();
        }



    }
}
