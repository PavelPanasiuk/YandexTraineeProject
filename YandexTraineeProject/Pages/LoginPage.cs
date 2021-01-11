using OpenQA.Selenium;
using System.Threading;

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
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector(_loginInputLine)).SendKeys(login);
            Thread.Sleep(1000);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(By.XPath(_submitLogin)).Click();
        }

        public void PasswordInput(string password)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector(_passwordInputLine)).SendKeys(password);
            Thread.Sleep(1000);
        }
    }
}
