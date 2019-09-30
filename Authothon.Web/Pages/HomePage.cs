using OpenQA.Selenium;

namespace Autothon.Web.Pages
{
    public class HomePage
    {
        private By _loginLink = By.XPath("//*[@id = 'navLink' and @name = '{0}']");
        private By _userName = By.XPath("//*[@name= 'password']");
        private By _password = By.XPath("//*[@name= 'username']");
        private By _loginButton = By.XPath("//*[@type= 'button']");

        public void Login()
        {
            
        }
    }
}
