using OpenQA.Selenium;
using System.Threading;

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
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(_firstDropDownLine)).Click();

            //ToDo: Не очень работает попробовать разобраться в чем херня и начиться нормально писать ожидания.

            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@class][1]"))).Click();
        }
    }
}
