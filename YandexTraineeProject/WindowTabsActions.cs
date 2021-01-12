using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace YandexTraineeProject
{
    class WindowTabsActions
    {
        public void CLoseLastTab(IWebDriver driver)
        {
            var tabs = driver.WindowHandles; // находим все хендлы табов
            if (tabs.Count > 1)
            {
                driver.SwitchTo().Window(tabs[1]); //переключаемся на таб который нужно закрыть
                driver.Close(); //закрываем
                driver.SwitchTo().Window(tabs[0]); // делаем иной таб активным
            }
        }
    }
}
