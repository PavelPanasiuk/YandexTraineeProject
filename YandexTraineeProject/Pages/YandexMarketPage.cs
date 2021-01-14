using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace YandexTraineeProject
{
    public class YandexMarketPage
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
        private IWebDriver _driver;
        WaitElement waitElement = new WaitElement();

        public YandexMarketPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickSearchLine()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_searchLineLocator)).Click();
        }

        public void InputSearchLine(string input)
        {
            waitElement.IsElementClickable(_driver, By.XPath(_searchLineLocator)).SendKeys(input);
        }

        public void ClickSearchButton()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_serchButtonLocator)).Click();
        }

        public void AddProductsForComparison()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            for (int i = 1; i <= 2; i++)
            {
                var elem = waitElement.IsElementExist(_driver, By.XPath($"//article[{i}]//div[@tabindex][2]"));
                js.ExecuteScript("arguments[0].click();", elem);
            }
        }

        public void ClickCompariButton()
        {
            waitElement.IsElementVisible(_driver, By.XPath(_compariButtonLocator));
            waitElement.IsElementClickable(_driver, By.XPath(_compariButtonLocator)).Click();
        }

        public List<IWebElement> GetListOfProductsForComparison()
        {
            return _driver.FindElements(By.CssSelector(".e910RKmlsj")).ToList();
        }

        public void DeleteProductsFromComparisonList()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_deleteListButtonLocator)).Click();
        }

        public void ClickElectronikCategory()
        {
            waitElement.IsElementClickable(_driver, By.XPath("//span[text()='Понятно']")).Click();
            waitElement.IsElementVisible(_driver, By.XPath(_electronikCategoryButtonLocator));
            waitElement.IsElementClickable(_driver, By.XPath(_electronikCategoryButtonLocator)).Click();
        }

        public void ClickTabletButton()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_tabletButtonLocator)).Click();
        }

        public void ClickSortingButtonByPrice()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_byPriceButtonLocator)).Click();
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
            return waitElement.IsElementExist(_driver, By.XPath(_byPriceButtonLocator)).GetAttribute("data-autotest-id");
        }

        public void ClickHouseholAppliancesCategory()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_householAppliancesCategoryButtonLocator)).Click();
        }

        public void ClosePopUpMenu()
        {
            waitElement.IsElementClickable(_driver, By.XPath("//div/button[@data-tid-prop]/span[text()='Да, верно']")).Click();
            waitElement.IsElementClickable(_driver, By.XPath("//span[text()='Дальше']")).Click();
            waitElement.IsElementClickable(_driver, By.XPath("//span[text()='Хорошо']")).Click();
        }

        public void ClickFridgeButton()
        {
            waitElement.IsElementClickable(_driver, By.XPath(_fridgeButtonLocator)).Click();
        }

        public void ClickFridgeWidthLine()
        {
            waitElement.IsElementClickable(_driver, By.XPath("//div[@class='b_2rWdZSWQdz b_nkiJ02woLW'][8]//span[2]//input")).Click();
        }

        public void IputFridgeWidth(string width)
        {
            waitElement.IsElementClickable(_driver, By.XPath("//div[@class='b_2rWdZSWQdz b_nkiJ02woLW'][8]//span[2]//input")).SendKeys(width);
        }

        public string GetTagMessage()
        {
            return waitElement.IsElementExist(_driver, By.CssSelector("[data-tid='75993b0d']")).Text;
        }
    }
}
