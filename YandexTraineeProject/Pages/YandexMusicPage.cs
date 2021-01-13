using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace YandexTraineeProject
{
    class YandexMusicPage
    {
        private IWebDriver _driver;

        public YandexMusicPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickSearchLine()
        {
            _driver.FindElement(By.XPath("//div[@class='head__search']/*/*/*[1]")).Click();
        }

        public void GetInputToSearchLine(string singer)
        {
            _driver.FindElement(By.XPath("//div[@class='head__search']/*/*/*[1]")).SendKeys(singer);
        }

        public void ClosePopUpMenu()
        {
            _driver.FindElement(By.XPath("//span[@class='d-icon deco-icon d-icon_cross-big  local-icon-theme-black']")).Click();
        }

        public void ChooseFirstLineDropDownLine()
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
        }

        public string GetArtistName()
        {
            return _driver.FindElement(By.XPath("//h1")).Text;
        }

        public bool GetListOfPopularAlbums()
        {
            var elems = _driver.FindElements(By.XPath("//div[@class='album album_selectable']")).ToList();
            var result = false;
            var count = 0;

            for (int i = 0; i < elems.Count; i++)
            {
                int x = i;
                var albumName = _driver.FindElement(By.XPath($"//div[@class='album album_selectable'][{++x}]//div[@title][2]")).GetAttribute("title");
                if (albumName != "Metallica")
                {
                    result = false;
                    break;
                }
                result = true;
                count++;
            }
            return result;
        }

        public void ClickFirstPopularSong()
        {
            _driver.FindElement(By.XPath("//div[@data-card='top_tracks']/*[1]")).Click();
        }

        public void MoveMouseToElement()
        {
            IWebElement elem = _driver.FindElement(By.XPath("//button[@data-idx='27995']/*[1]"));
            Actions action = new Actions(_driver);
            action.MoveToElement(elem).Click().Build().Perform();
        }

        public void JSexecutor()
        {
            var elem = _driver.FindElement(By.XPath("//button[@class='button-play button2 button2_rounded button2_w-icon local-icon-theme-white page-artist__play button-play__type_artist']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteAsyncScript("arguments[0].click();",elem);
            MakeScreenShot();
            Thread.Sleep(1000);
            js.ExecuteAsyncScript("arguments[0].click();", elem);
            MakeScreenShot1();

            // string title = (string)js.ExecuteScript("return document.title");
        }

        public void ClickToStartButtonFirstPopularSong()
        {
            _driver.FindElement(By.XPath("//button[@data-idx='27995']/*[1]")).Click();
        }

        public void MakeScreenShot()
        {
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(@"E:\windowCondition1.jpeg");
        }

        public void MakeScreenShot1()
        {
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(@"E:\windowCondition2.jpeg");
        }



    }
}
