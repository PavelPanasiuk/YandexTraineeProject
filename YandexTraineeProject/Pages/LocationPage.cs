using OpenQA.Selenium;
using System.Threading;

namespace YandexTraineeProject
{
    class LocationPage
    {
        private string _locationInput = "//input[@id='city__front-input']";
        private string _firstDropDownLine = "//li[@class][1]";

        public void ChangeLocation(IWebDriver _driver, string locationName)
        {
            _driver.FindElement(By.XPath(_locationInput)).Click();
            _driver.FindElement(By.XPath(_locationInput)).Clear();
            _driver.FindElement(By.XPath(_locationInput)).SendKeys(locationName);
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(_firstDropDownLine)).Click();

            //ToDo: Не очень работает попробовать разобраться в чем херня и начиться нормально писать ожидания.

            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[@class][1]"))).Click();
        }
    }
}
