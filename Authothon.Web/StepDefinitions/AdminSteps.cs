using Autothon.Web.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Autothon.Web.Step_Definitions.Movie
{
    [Binding]
    public class AdminSteps
    {
        AddMoviePage addMoviePage = new AddMoviePage();
        HomePage homePage = new HomePage();

        [Given(@"I am on Autothon challenge page")]
        public void GivenIAmOnAutothonChallengePage()
        {
            homePage.GoToUrl();
        }

        [Given(@"I login with below details")]
        public void GivenILoginWithBelowDetails(Table table)
        {
            
        }


        [When(@"I add a new movie with below details")]
        public void WhenIAddANewMovieWithBelowDetails(Table table)
        {

            addMoviePage.EnterMovieDetails();
        }

        [Then(@"I should be able to add movie successfully")]
        public void ThenIShouldBeAbleToAddMovieSuccessfully()
        {
            
        }

    }
}
