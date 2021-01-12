using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;

namespace YandexTraineeProject
{
    class LocationPage
    {
        private string _locationInput = "//input[@id='city__front-input']";
        private string _firstDropDownLine = "//li[@class][1]";
        private IWebDriver _driver;

        public LocationPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void ChangeLocation(string locationName)
        {
            _driver.FindElement(By.XPath(_locationInput)).Click();
            _driver.FindElement(By.XPath(_locationInput)).Clear();
            _driver.FindElement(By.XPath(_locationInput)).SendKeys(locationName);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.XPath(_firstDropDownLine)));            
        }

        public void SelectLocation()
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
        }
    }
}
