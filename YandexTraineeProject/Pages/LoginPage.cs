using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace YandexTraineeProject
{
    public class LoginPage
    {
        private string _loginInputLine = "#passp-field-login";//css        
        private string _passwordInputLine = "#passp-field-passwd";//css
        private string _submitLogin = "//button[@data-t='button:action']";
        private IWebDriver _driver;
        WaitElement waitElement = new WaitElement();

        public LoginPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void LoginInput(string login)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            waitElement.IsElementClickable(_driver, By.CssSelector(_loginInputLine)).SendKeys(login);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(By.XPath(_submitLogin)).Click();
        }

        public void PasswordInput(string password)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            waitElement.IsElementClickable(_driver, By.CssSelector(_passwordInputLine)).SendKeys(password);
        }

        public string GetErrorMessage(string locator)
        {
            return waitElement.IsElementVisible(_driver, By.XPath(locator)).Text;
        }
    }
}
