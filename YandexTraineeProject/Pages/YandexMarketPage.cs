using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace YandexTraineeProject
{
    class YandexMarketPage
    {
        private string _searchLineLocator = "//input[@type='text']";
        private string _serchButtonLocator = "//button[@type='submit']";
        private string _elementFromSearchResult = "//article";
        private string _compariButtonLocator = "//div[@class='_3oDLePObQ1']/*";
        private IWebDriver _driver;

        public YandexMarketPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void ClickSearchLine()
        {
            _driver.FindElement(By.XPath(_searchLineLocator)).Click();
        }

        public void InputSearchText(string input)
        {
            _driver.FindElement(By.XPath(_searchLineLocator)).SendKeys(input);
        }

        public void ClickSearchButton()
        {
            _driver.FindElement(By.XPath(_serchButtonLocator)).Click();
        }        

        public void AddProductsForComparison()
        {          

            for (int i = 1; i <=2 ; i++)
            {
               _driver.FindElement(By.XPath($"//article[{i}]//div[@class='_1CXljk9rtd']")).Click();
            }
        }

        public void ClickCompariButton()
        {
            _driver.FindElement(By.XPath("//div[@class='_3oDLePObQ1']/*")).Click();
        }


    }
}
