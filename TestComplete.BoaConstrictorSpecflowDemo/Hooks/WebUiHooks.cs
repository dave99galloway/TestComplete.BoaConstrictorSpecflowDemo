﻿using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestComplete.BoaConstrictorSpecflowDemo.Hooks
{
    [Binding, Scope(Tag = "WebUi")]
    public sealed class WebUiHooks
    {
        private readonly IObjectContainer _objectContainer;

        public WebUiHooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // _objectContainer.RegisterFactoryAs(c => WebDriverFactory());
            _objectContainer.RegisterFactoryAs<IWebDriverFactory>(c => new WebDriverFactory());
        }

        //private IWebDriver WebDriverFactory()
        //{
        //    new DriverManager().SetUpDriver(new ChromeConfig());
        //    return new ChromeDriver();
        //}

        [AfterScenario]
        public void AfterScenario()
        {
            _objectContainer.Resolve<IWebUiActorsProvider>().DismissCast();
        }
    }
}
