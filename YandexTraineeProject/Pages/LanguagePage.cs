using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using YandexTraineeProject.Data;

namespace YandexTraineeProject
{
    class LanguagePage
    {
        private string _languageDropDownMenu = "//div/div/div/button";
        private string _saveLanguageButtonLocator = "//div[@class='form__controls']/button";
        private IWebDriver _driver;
        WaitElement waitElement = new WaitElement();

        public LanguagePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void ClickLanguageMenu()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_languageDropDownMenu)).Click();
        }

        public void SelectLanguage( LanguageType language)
        {
            var map = new Dictionary<LanguageType, string>
            {
                { LanguageType.Russian, "ru" },
                { LanguageType.Ukranian, "uk" },
                { LanguageType.English, "en" },
                { LanguageType.Belarussian, "be"}
            };

            var select = _driver.FindElement(By.XPath("//select[@name='intl']"));
            var languageOptions = select.FindElements(By.TagName("option"));

            var actions = new Actions(_driver);
            var indexOfRequiredLanguageValue = languageOptions.IndexOf(languageOptions.First(o => o.GetAttribute("value") == map[language]));

            for (int i = 0; i <= indexOfRequiredLanguageValue; i++)
            {
                actions.SendKeys(Keys.ArrowDown);
            }
            actions.SendKeys(Keys.Enter).Build().Perform();
        }


        public void ClickSaveLanguageButton()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_saveLanguageButtonLocator)).Click();
        }
    }
}
