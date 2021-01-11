using OpenQA.Selenium;
using System.Threading;

namespace YandexTraineeProject
{
    class LoginPage
    {
        private string _loginInputLine = "#passp-field-login";//css        
        private string _passwordInputLine = "#passp-field-passwd";//css
        private string _submitLogin = "//button[@data-t='button:action']";

        public void LoginInput(IWebDriver _driver, string login)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector(_loginInputLine)).SendKeys(login);
            Thread.Sleep(1000);
        }

        public void ClickLoginButton(IWebDriver _driver)
        {
            _driver.FindElement(By.XPath(_submitLogin)).Click();
        }

        public void PasswordInput(IWebDriver _driver, string password)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector(_passwordInputLine)).SendKeys(password);
            Thread.Sleep(1000);
        }
    }
}
