using Boa.Constrictor.WebDriver;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.Pages;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]
    public class SmartBearWebUiLoginSteps
    {
        private readonly TestDataConfig _testDataConfig;
        private readonly ILoginPage _loginPage;
        private readonly IWebUiActorsProvider _actors;

        public SmartBearWebUiLoginSteps(TestDataConfig testDataConfig, ILoginPage loginPage, IWebUiActorsProvider actors)
        {
            _testDataConfig = testDataConfig;
            _loginPage = loginPage;
            _actors = actors;
        }

        [Given(@"I login to smartstore portal as ""(.*)""")]
        public void GivenILoginToSmartstorePortalAs(string userName)
        {
            var actor = _actors.ActorCalled(userName);
            //todo: create custom task
            actor.AttemptsTo(Navigate.ToUrl(_testDataConfig.DefaultUrl));
            var password = _testDataConfig.DefaultPassword;
            actor.AttemptsTo(SendKeys.To(_loginPage.UserNameField, userName));
            actor.AttemptsTo(SendKeys.To(_loginPage.PasswordField, password));
            actor.AttemptsTo(Click.On(_loginPage.LoginButton));
        }
    }
}
