using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace YandexTraineeProject
{
    class LoginPage
    {
        private string _loginInputLine = "#passp-field-login";//css        
        private string _passwordInputLine = "#passp-field-passwd";//css
        private string _submitLogin = "//button[@data-t='button:action']";
        private IWebDriver _driver;

        public LoginPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void LoginInput(string login)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(_loginInputLine))).SendKeys(login);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(By.XPath(_submitLogin)).Click();
        }

        public void PasswordInput(string password)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                 .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(_passwordInputLine))).SendKeys(password);
        }

        public string GetErrorMessage(string locator)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                 .Until(ExpectedConditions.ElementExists(By.XPath(locator))).Text;
        }
    }
}
