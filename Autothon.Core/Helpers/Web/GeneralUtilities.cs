using Autothon.Browser;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;

namespace Autothon.Helpers.Web
{
    public class GeneralUtilities
    {
        private static IWebDriver driver = Webdriver.CurrentDriver();

        public static string getCurrentProjectDirectory()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            baseDir = Directory.GetParent(Directory.GetParent(baseDir).ToString()).FullName;
            baseDir = Directory.GetParent(baseDir).ToString();
            return baseDir;
        }

        public string GetConfigApplicationName()
        {
            return GetConfigValueFor("ApplicationName");
        }

        public string GetUrlValue()
        {
            return GetConfigValueFor("Url");
        }

        public string GetUrl()
        {
            return GetConfigValueFor("Url");
        }
        //Similarly we can get the value for other keys based on the requirement 

        public void TakeScreenshots(IWebDriver driver, string fileName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalPath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + fileName + ".png";
            string localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
        }
        public string GetConfigValueFor(string configKey)
        {
            string keyValue = "";
            string paramValue = GetValueFromClp(configKey);
            string appConfigValue = GetValueFromAppConfig(configKey);
            if (!string.IsNullOrEmpty(paramValue))
                keyValue = paramValue;
            else if (!string.IsNullOrEmpty(appConfigValue))
                keyValue = appConfigValue;
            else
                throw new System.Exception("Could not find value for [" + configKey + "] in command prompt or app.config file");

            return keyValue;
        }

        public string GetValueFromClp(string paramKey)
        {
            return TestContext.Parameters.Get(paramKey);
        }

        public string GetValueFromAppConfig(string configKey)
        {
            string configValue = "";
            try
            {
                configValue = ConfigurationManager.AppSettings[configKey];
            }
            catch(System.Exception)
            {
                return configValue;
            }

            return configValue;
        }

        public void SendData(By xpathLocator, string value)
        {
            FindElement(xpathLocator).SendKeys(value);
        }

        public static void Click(By locator)
        {
            //WaitUntil(ExpectedConditions.ElementToBeClickable(locator));
            FindElement(locator).Click();
        }

        public static IWebElement FindElement(By locator)
        {
            //WaitUntil(ExpectedConditions.ElementExists(locator));
            return driver.FindElement(locator);
        }
    }
}
