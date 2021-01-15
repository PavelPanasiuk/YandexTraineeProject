using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System;
using System.Threading;

namespace YandexTraineeProject
{
    public class YandexMusicPage
    {
        private string _searchLineLocator = "//div[@class='head__search']/*/*/*[1]";
        private string _popUpMenuCLocator = "//span[@class='d-icon deco-icon d-icon_cross-big  local-icon-theme-black']";
        private string _firstelemInDropDown = "//div[@data-card='search_suggest'][1]";
        private string _artistNameLocator = "//h1[@class]";
        private string _playStopButtonLocator = "//span[text()='Слушать']";
        private IWebDriver _driver;
        WaitElement waitElement = new WaitElement();

        public YandexMusicPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickSearchLine()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_searchLineLocator)).Click();
        }

        public void GetInputToSearchLine(string singer)
        {
            waitElement.IsElementClickable(_driver, By.XPath(_searchLineLocator)).SendKeys(singer);
        }

        public void ClosePopUpMenu()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_popUpMenuCLocator))
                .Click();
        }

        public void ChooseFirstLineInDropDown()
        {
            Actions actions = new Actions(_driver);
            waitElement.IsElementExist(_driver, By.XPath(_firstelemInDropDown));
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
        }

        public string GetArtistName()
        {
            Thread.Sleep(500);
            return waitElement.IsElementExist(_driver, By.XPath(_artistNameLocator)).Text;
        }

        public bool GetListOfPopularAlbums()
        {
            var elems = _driver.FindElements(By.XPath("//div[@class='album album_selectable']")).ToList();
            var result = false;
            var count = 0;

            for (int i = 0; i < elems.Count; i++)
            {
                int x = i;
                var albumName = waitElement.IsElementExist(_driver, By.XPath($"//div[@class='album album_selectable'][{++x}]//div[@title][2]"))
                    .GetAttribute("title");
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

        public void ClickStopAndPlayFirstPopularSong()
        {
            var elem = waitElement.IsElementVisible(_driver, By.XPath(_playStopButtonLocator));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", elem);
        }

        public void MakeScreenShot()
        {
            Random random = new Random();
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile($"E:\\windowCondition{random.Next()}.jpeg");
        }
    }
}
