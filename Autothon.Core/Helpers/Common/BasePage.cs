using Autothon.Browser;
using Autothon.Helpers.Web;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autothon.Core.Helpers.Common
{
    public class BasePage
    {
        private IWebDriver driver = Webdriver.CurrentDriver();
        GeneralUtilities generalUtilities = new GeneralUtilities();

        public void SendData(By xpathLocator, string value)
        {
            FindElement(xpathLocator).SendKeys(value);
        }

        public void Click(By locator)
        {
            //WaitUntil(ExpectedConditions.ElementToBeClickable(locator));
            FindElement(locator).Click();
        }

        public IWebElement FindElement(By locator)
        {
            //WaitUntil(ExpectedConditions.ElementExists(locator));
            return driver.FindElement(locator);
        }

        public bool IsElementVisible(By locator)
        {
            return driver.FindElement(locator).Displayed;
        }

        public void GetUrl()
        {
            string url = generalUtilities.GetUrl();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
    }
}
