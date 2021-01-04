using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NUnit.Framework;

namespace YandexTraineeProject
{
    public class BrowserInitialization
    {
        public IWebDriver Driver { get; }

        public BrowserInitialization(BrowserType browserType)
        {
            var baseBrowser = new BaseBrowser();
            Driver = baseBrowser.GetBrowser(browserType);
        }
    }
}
