using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace YandexTraineeProject
{
    class YandexMarketPage
    {
        private string _searchLineLocator = "//input[@type='text']";
        private string _serchButtonLocator = "//button[@type='submit']";
        private string _compariButtonLocator = "//div[@class='_3oDLePObQ1']/*";
        private string _deleteListButtonLocator = "//button[text()='Удалить список']";
        private string _electronikCategoryButtonLocator = "//div[@class='_381y5orjSo _21NjfY1k45']/*[5]";
        private string _tabletButtonLocator = "//a[text()='Планшеты']";
        private string _byPriceButtonLocator = "//button[text()='по цене']";
        private string _householAppliancesCategoryButtonLocator = "//div[text()='Бытовая техника']";
        private string _fridgeButtonLocator = "//span[text()='Холодильники'][1]";
        private string _frigeWidthInputLine = "#textfield9342528263";
        private string _sortByWidthMessage = "[data-tid='75993b0d']";
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
            for (int i = 1; i < 2; i++)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//article[{i}]//div[@class='_1CXljk9rtd']"))).Click();
                //_driver.FindElement(By.XPath($"//article[{i}]//div[@class='_1CXljk9rtd']"));
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

        public void ClickDeleteAllProductsFromComparisonListButton()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                 .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_deleteListButtonLocator))).Click();
        }

        public void ClickElectronikCategory()
        {
            _driver.FindElement(By.XPath("//span[text()='Понятно']")).Click();
            Thread.Sleep(1000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_electronikCategoryButtonLocator))).Click();
        }

        public void ClickTabletButton()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_tabletButtonLocator))).Click();
        }

        public void ClickSortingButtonByPrice()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                 .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_byPriceButtonLocator))).Click();
        }

        public void SortPriceListDescending()
        {
            var getTypeOfSorting = _driver.FindElement(By.XPath(_byPriceButtonLocator)).GetAttribute("data-autotest-id");
            if (getTypeOfSorting != "dprice")
            {
                ClickSortingButtonByPrice();
            }
        }

        public string GetTypeOfPriceSorting()
        {
            return _driver.FindElement(By.XPath(_byPriceButtonLocator)).GetAttribute("data-autotest-id");
        }

        public void ClickHouseholAppliancesCategory()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                 .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_householAppliancesCategoryButtonLocator))).Click();
        }

        public void ClickFridgeButton()
        {
            _driver.FindElement(By.XPath("//div/button[@data-tid-prop]/span[text()='Да, верно']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//span[text()='Дальше']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//span[text()='Хорошо']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath(_fridgeButtonLocator)).Click();
            // new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            //    .Until(ExpectedConditions.ElementToBeClickable(By.XPath(_fridgeButtonLocator))).Click();
        }

        public void ClickFridgeWidthLine()
        {
            _driver.FindElement(By.XPath("//label[text()='до 91,2']")).Click();
        }

        public void IputFridgeWidth(string width)
        {
            _driver.FindElement(By.CssSelector(_frigeWidthInputLine)).SendKeys(width);
        }

        public string GetTagMessage()
        {
            return _driver.FindElement(By.CssSelector("[data-tid='75993b0d']")).Text;
        }
    }
}
