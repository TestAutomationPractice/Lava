using Autothon.Core.Helpers.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Autothon.Web.Pages
{
    public class HomePage : BasePage
    {
        private By _cardBody = By.CssSelector(".card-body");
        private By _loginLink = By.XPath("//*[@id = 'navLink' and @name = '{0}']");
        private By _userName = By.XPath("//*[@name= 'password']");
        private By _password = By.XPath("//*[@name= 'username']");
        private By _loginButton = By.XPath("//*[@type= 'button']");
        private By _addMovieLink = By.PartialLinkText("add movie");

        public void Login(string username, string password)
        {
            Click(_cardBody);
            Click(_loginLink);
            SendData(_userName, username);
            SendData(_password, password);

            Click(_loginButton);

            bool AreWeOnAddMoviePage = IsElementVisible(_addMovieLink);

            Assert.IsTrue(AreWeOnAddMoviePage, "Add Movie link is not present");
        }

        public void GoToUrl()
        {
            GetUrl();
        }

        
    }
}
