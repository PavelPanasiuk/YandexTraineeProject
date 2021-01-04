using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OpenQA.Selenium;


namespace YandexTraineeProject
{
    class ElseButtonMenuLondon
    {
        public List<string> GetListOfLondonElseMenuElements(IWebDriver driver)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            List<IWebElement> elems = driver.FindElements(By.XPath("//a[@data-id]")).ToList();

            List<string> listElseMenuValues = new List<string>();
            driver.FindElement(By.XPath(BaseData._elseButton)).Click();
            for (int i = 1; i<=elems.Count; i++)
            {
                listElseMenuValues.Add(driver.FindElement(By.XPath($"//div[@class='services-new__more-popup-services']/*[{i}]"))
                     .GetAttribute("data-id"));
            }
            return listElseMenuValues;
        }
    }
}
