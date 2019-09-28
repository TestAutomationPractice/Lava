using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autothon.Core.Helpers.Common;

namespace Autothon.Web.Pages
{
    public class AddMoviePage : BasePage
    {
        private By _addMovieLink = By.PartialLinkText("add movie");
        private By _movieDetails = By.CssSelector(".col-sm-10 [name = '{0}']");
        private By _movieRating = By.CssSelector(".col-sm-10 svg:nth-of-type(5)");
        private By _saveButton = By.CssSelector(".btn-group button:nth-of-type(1)");

        public void AddNewMovie()
        {
            Click(_addMovieLink);
            

        }

        public void EnterMovieDetails()
        {
            SendData(_movieDetails, "");
        }

    }
}
