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

        [Given(regex: @"I login to smartstore portal as ""(.*)""")]
        public void GivenILoginToSmartstorePortalAs(string userName)
        {
            _actors.ActorCalled(name: userName)
            .AttemptsTo(task: Login()
                .To(url: _testDataConfig.DefaultUrl)
                .As(userName: userName)
                .WithPassword(password: _testDataConfig.DefaultPassword)
                .From(loginPage: _loginPage));
        }
    }
}
