using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace YandexTraineeProject
{
    public class YandexMusicPage
    {
        private IWebDriver _driver;
        WaitElement waitElement = new WaitElement();

        public YandexMusicPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickSearchLine()
        {
            waitElement.IsElementClickable(_driver, By.XPath("//div[@class='head__search']/*/*/*[1]")).Click();
        }

        public void GetInputToSearchLine(string singer)
        {
            waitElement.IsElementClickable(_driver, By.XPath("//div[@class='head__search']/*/*/*[1]")).SendKeys(singer);
        }

        public void ClosePopUpMenu()
        {
            waitElement.IsElementClickable(_driver, By.XPath("//span[@class='d-icon deco-icon d-icon_cross-big  local-icon-theme-black']"))
                .Click();
        }

        public void ChooseFirstLineDropDownLine()
        {
            Actions actions = new Actions(_driver);
            waitElement.IsElementExist(_driver, By.XPath("//div[@data-card='search_suggest'][1]"));
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
        }

        public string GetArtistName()
        {
            return waitElement.IsElementExist(_driver, By.XPath("//h1[@class]")).Text;
        }

        public bool GetListOfPopularAlbums()
        {
            var elems = _driver.FindElements(By.XPath("//div[@class='album album_selectable']")).ToList();
            var result = false;
            var count = 0;

            for (int i = 0; i < elems.Count; i++)
            {
                int x = i;
                var albumName = waitElement.IsElementVisible(_driver, By.XPath($"//div[@class='album album_selectable'][{++x}]//div[@title][2]"))
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
            var elem = waitElement.IsElementVisible(_driver, By.XPath("//span[text()='Слушать']"));
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
