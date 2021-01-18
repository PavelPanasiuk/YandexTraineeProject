using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace YandexTraineeProject
{
    public class LocationPage
    {
        private string _locationInput = "//input[@id='city__front-input']";
        private IWebDriver _driver;
        WaitElement waitElement = new WaitElement();
        
        public LocationPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void ClickSearchLine()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_locationInput)).Click();
        }

        public void ClearSearchLine()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_locationInput)).Clear();
        }

        public void InputLocationName(string locationName)
        {
            waitElement.IsElementClickable(_driver, By.XPath(_locationInput)).SendKeys(locationName);
        }

        public void SelectLocation()
        {
            waitElement.IsElementVisible(_driver, By.XPath("//ul"));
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
        }       
    }
}
