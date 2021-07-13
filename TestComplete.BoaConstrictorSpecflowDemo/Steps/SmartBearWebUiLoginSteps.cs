using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]
    public class SmartBearWebUiLoginSteps
    {
        private IWebDriver _webdriver;

        public SmartBearWebUiLoginSteps(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public SmartBearWebUiLoginSteps()
        {
        }

        [Given(@"I login to smartstore portal as ""(.*)""")]
        public void GivenILoginToSmartstorePortalAs(string userName)
        {
            _webdriver.Navigate().GoToUrl("https://services.smartbear.com/samples/TestComplete14/smartstore/login");

            
        }
    }
}
