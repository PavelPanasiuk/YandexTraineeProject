using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace YandexTraineeProject
{
    public class WaitElement
    {
        public IWebElement IsElementClickable(IWebDriver driver, By locator)
        {
            try
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                 .Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException($"Timed out waiting\n", ex);
            }
        }

        public IWebElement IsElementVisible(IWebDriver driver, By locator)
        {
            try
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                 .Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException($"Timed out waiting\n", ex);
            }
        }

        public IWebElement IsElementExist(IWebDriver driver, By locator)
        {
            try
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                 .Until(ExpectedConditions.ElementExists(locator));
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException($"Timed out waiting\n", ex);
            }
        }

    }


}

