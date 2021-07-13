using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.Pages;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]
    public class SmartBearWebUiLoginSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly TestDataConfig _testDataConfig;
        private readonly ILoginPage _loginPage;

        public SmartBearWebUiLoginSteps(IWebDriver webdriver, TestDataConfig testDataConfig, ILoginPage loginPage)
        {
            _webdriver = webdriver;
            this._testDataConfig = testDataConfig;
            _loginPage = loginPage;
        }

        public SmartBearWebUiLoginSteps()
        {
        }

        [Given(@"I login to smartstore portal as ""(.*)""")]
        public void GivenILoginToSmartstorePortalAs(string userName)
        {
            _webdriver.Navigate().GoToUrl(_testDataConfig.DefaultUrl);
            var password = _testDataConfig.DefaultPassword;
            _webdriver.FindElement(_loginPage.UserNameField).SendKeys(userName);
            _webdriver.FindElement(_loginPage.PasswordField).SendKeys(password);
            _webdriver.FindElement(_loginPage.LoginButton).Click();

            
        }
    }
}
