using OpenQA.Selenium;
using System.Threading;

namespace YandexTraineeProject
{
    class EmailPage
    {
        private string _userName = "//span[text()='AutotestUser']";
        private string _accountOptionsButton = "//span[@class='user-account__name'][1]";
        private string _exitButton = "//span[contains(text(),'Выйти из сервисов Яндекса')]";        

        public string GetUserName(IWebDriver _driver)//ToDo: Thread sleep убрать
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Thread.Sleep(3000);
            return _driver.FindElement(By.XPath(_userName)).Text;
        }

        public void LogOut(IWebDriver _driver)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(_accountOptionsButton)).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(_exitButton)).Click();
        }
    }
}
