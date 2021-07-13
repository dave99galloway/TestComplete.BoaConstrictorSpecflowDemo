using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.Pages;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]
    public class SmartBearWebUiLoginSteps
    {
        private readonly TestDataConfig _testDataConfig;
        private readonly ILoginPage _loginPage;
        private readonly IActor _actor;

        public SmartBearWebUiLoginSteps(IWebDriver webdriver, TestDataConfig testDataConfig, ILoginPage loginPage, IActor actor)
        {
            _testDataConfig = testDataConfig;
            _loginPage = loginPage;
            _actor = actor;
        }

        [Given(@"I login to smartstore portal as ""(.*)""")]
        public void GivenILoginToSmartstorePortalAs(string userName)
        {
            _actor.AttemptsTo(Navigate.ToUrl(_testDataConfig.DefaultUrl));
            var password = _testDataConfig.DefaultPassword;
            _actor.AttemptsTo(SendKeys.To(_loginPage.UserNameField, userName));
            _actor.AttemptsTo(SendKeys.To(_loginPage.PasswordField, password));
            _actor.AttemptsTo(Click.On(_loginPage.LoginButton));
        }
    }
}
