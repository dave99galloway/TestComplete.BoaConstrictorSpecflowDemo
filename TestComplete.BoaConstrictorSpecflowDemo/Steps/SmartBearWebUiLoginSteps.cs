using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]
    public class SmartBearWebUiLoginSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly TestDataConfig _testDataConfig;

        public SmartBearWebUiLoginSteps(IWebDriver webdriver, TestDataConfig testDataConfig)
        {
            _webdriver = webdriver;
            this._testDataConfig = testDataConfig;
        }

        public SmartBearWebUiLoginSteps()
        {
        }

        [Given(@"I login to smartstore portal as ""(.*)""")]
        public void GivenILoginToSmartstorePortalAs(string userName)
        {
            _webdriver.Navigate().GoToUrl(_testDataConfig.DefaultUrl);
            var password = _testDataConfig.DefaultPassword;
            _webdriver.FindElement(By.CssSelector("#UsernameOrEmail")).SendKeys(userName);
            _webdriver.FindElement(By.CssSelector("#Password")).SendKeys(password);
            _webdriver.FindElement(By.CssSelector(".btn-login")).Click();

            
        }
    }
}
