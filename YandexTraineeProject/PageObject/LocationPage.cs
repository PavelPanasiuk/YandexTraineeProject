using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace YandexTraineeProject
{
    public class LocationPage
    {
        private const string _location = "//span[@class ='geolink__reg']";//кнопка для смены локации
        private const string _location_Input = "//input[@id='city__front-input']";//нужно очистить поле и ввести нужное и жать Enter        

        public void ChangeLocation(IWebDriver driver, string locationName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(BaseData._serchUrl);          
            driver.FindElement(By.XPath(_location)).Click();
            driver.FindElement(By.XPath(_location_Input)).Click();
            driver.FindElement(By.XPath(_location_Input)).Clear();
            driver.FindElement(By.XPath(_location_Input)).SendKeys(locationName);           
           // Thread.Sleep(2000);//Добавить ожидание загрузки веб элементов
            driver.FindElement(By.XPath("//li[@class][1]")).Click();
        }
    }
}
