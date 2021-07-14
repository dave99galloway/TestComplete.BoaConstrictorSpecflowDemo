using Boa.Constrictor.WebDriver;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.Pages;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors;
using static TestComplete.BoaConstrictorSpecflowDemo.Screenplay.Tasks.SmartBearWebUiLoginTask;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]
    public sealed class SmartBearWebUiLoginSteps
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
            _actors.ActorCalled(userName)
            .AttemptsTo(Login()
                .To(_testDataConfig.DefaultUrl)
                .As(userName)
                .WithPassword(_testDataConfig.DefaultPassword)
                .From(_loginPage));
        }
    }
}
