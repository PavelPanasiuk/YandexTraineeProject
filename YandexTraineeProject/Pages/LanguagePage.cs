using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace YandexTraineeProject
{
    class LanguagePage
    {
        private string _languageDropDownMenu = "//div/div/div/button";       
        private string _saveLanguageButtonLocator = "//div[@class='form__controls']/button";

        public void ClickLanguageMenu(IWebDriver driver)
        {
            driver.FindElement(By.XPath(_languageDropDownMenu)).Click();
        }

        public void SelectUkraineLanguage(IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();            
        }       

        public void ClickSaveLanguageButton(IWebDriver driver)
        {
            driver.FindElement(By.XPath(_saveLanguageButtonLocator)).Click();
        }
    }    
}
