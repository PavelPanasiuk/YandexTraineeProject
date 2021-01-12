using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace YandexTraineeProject
{
    class YandexMarketPage
    {
        private string _searchLineLocator = "//input[@type='text']";
        private string _serchButtonLocator = "//button[@type='submit']";
        private string _compariButtonLocator = "//div[@class='_3oDLePObQ1']/*";
        private IWebDriver _driver;

        public YandexMarketPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickSearchLine()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_searchLineLocator))).Click();
        }

        public void InputSearchText(string input)
        {
            _driver.FindElement(By.XPath(_searchLineLocator)).SendKeys(input);
        }

        public void ClickSearchButton()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_serchButtonLocator))).Click();
        }

        public void AddProductsForComparison()
        {
            for (int i = 1; i <= 2; i++)
            {
                _driver.FindElement(By.XPath($"//article[{i}]//div[@class='_1CXljk9rtd']")).Click();
            }
        }

        public void ClickCompariButton()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_compariButtonLocator))).Click();
        }

        public List<IWebElement> GetListOfProductsForComparison()
        {           
           return _driver.FindElements(By.CssSelector(".e910RKmlsj")).ToList();           
        }
    }
}
