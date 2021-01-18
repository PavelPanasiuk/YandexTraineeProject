using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace YandexTraineeProject
{
    public class EmailPage
    {
        private string _userName = "//span[@class='user-account__name'][1]";
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
            BrowserTabAction.SwitchToLastTab(_driver);
            waitElement.IsElementVisible(_driver, By.XPath(_userName));
            return _driver.FindElement(By.XPath(_userName)).Text;
        }

        public void ClickLogOut()
        {
            BrowserTabAction.SwitchToLastTab(_driver);           
            waitElement.IsElementClickable(_driver, By.XPath(_exitButton)).Click();
        }

        public void ClickAccountOptionsButton()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_accountOptionsButton)).Click();
        }

        public void GoToMainPage()
        {
            waitElement.IsElementVisible(_driver, By.XPath("//div[@class='yandex-header__logo']/*[1]"));
            waitElement.IsElementClickable(_driver, By.XPath("//div[@class='yandex-header__logo']/*[1]")).Click();
        }
    }
}
