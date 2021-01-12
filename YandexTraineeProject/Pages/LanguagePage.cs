using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace YandexTraineeProject
{
    class LanguagePage
    {
        private string _languageDropDownMenu = "//div/div/div/button";       
        private string _saveLanguageButtonLocator = "//div[@class='form__controls']/button";
        private IWebDriver _driver;        

        public LanguagePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void ClickLanguageMenu()
        {
            _driver.FindElement(By.XPath(_languageDropDownMenu)).Click();

        }

        public void SelectUkraineLanguage()
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();            
        }       

        public void ClickSaveLanguageButton()
        {
            _driver.FindElement(By.XPath(_saveLanguageButtonLocator)).Click();
        }
    }    
}
