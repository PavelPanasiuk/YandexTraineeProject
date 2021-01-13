using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace YandexTraineeProject
{
    class EmailPage
    {
        private string _userName = "//span[text()='AutotestLogin']";
        private string _accountOptionsButton = "//span[@class='user-account__name'][1]";
        private string _exitButton = "//span[contains(text(),'Выйти из сервисов Яндекса')]";
        private IWebDriver _driver;
        WaitElement waitElement = new WaitElement();

        public EmailPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public string GetUserName()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);            
            waitElement.IsElementVisible(_driver, By.XPath(_userName));
            return _driver.FindElement(By.XPath(_userName)).Text;
        }

        public void LogOut()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);           
            waitElement.IsElementClickable(_driver, By.XPath(_accountOptionsButton)).Click();            
            waitElement.IsElementClickable(_driver, By.XPath(_exitButton)).Click();
        }
    }
}
