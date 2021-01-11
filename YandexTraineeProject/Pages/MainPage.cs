using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Threading;

namespace YandexTraineeProject
{
    class MainPage 
    {
        private string _elseButtonLocator = "//div[text()='ещё']";        
        private string _location = "//span[@class ='geolink__reg']";   
        private string _loginEmailButtonLocator = "//span[text()='Войти в почту']/..";
        private string _languageButtonLocator = "//a[@title='Выбрать язык']";
        private string _languageOptionsButtonLocator = "//span[text()='ещё']";
        public const string VideoButton = "//a[@data-id='video']";
        public const string ImageButton = "//a[@data-id='images']";
        public const string NewsButton = "//a[@data-id='news']";
        public const string MapButton = "//a[@data-id='maps']";
        public const string MarketButton = "//a[@data-id='market']";
        public const string TranslateButton = "//a[@data-id='translate']";
        public const string MusicButton = "//a[@data-id='music']";
        private IWebDriver _driver;

        public MainPage(IWebDriver webDriver)
        {
            this._driver = webDriver;
        }


        public void ClickLocationButton() 
        {
            _driver.FindElement(By.XPath(_location)).Click();
        }

        public List<string> GetListOfElseMenuElements()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            List<IWebElement> elems = _driver.FindElements(By.XPath("//a[@data-id]")).ToList();

            List<string> listElseMenuValues = new List<string>();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(_elseButtonLocator)).Click();
            for (int i = 1; i <= elems.Count; i++)
            {
                listElseMenuValues.Add(_driver.FindElement(By.XPath($"//div[@class='services-new__more-popup-services']/*[{i}]"))
                     .GetAttribute("data-id"));
            }
            return listElseMenuValues;
        }

        public void ClickEmailLoginButton()
        {
            _driver.FindElement(By.XPath(_loginEmailButtonLocator)).Click();
        }

        public string ClickNavigationBarButton( string nameOfButton)
        {
            _driver.FindElement(By.XPath(nameOfButton)).Click();
            return _driver.SwitchTo().Window(_driver.WindowHandles[1]).Url;
        }

        public void ClickLanguageButton()
        {
            _driver.FindElement(By.XPath(_languageButtonLocator)).Click();
        }

        public void ClickLanguageOptionsButton()
        {
            _driver.FindElement(By.XPath(_languageOptionsButtonLocator)).Click();
        }

        public string GetLanguageName()
        {
            Thread.Sleep(1000);
            return _driver.FindElement(By.XPath("//div[@class='col headline__bar-item b-langs']/div/a[@title]")).Text;
        }
    }
}
