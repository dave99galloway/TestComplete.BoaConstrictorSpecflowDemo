using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestComplete.BoaConstrictorSpecflowDemo.Drivers
{
    public interface IWebDriverFactory
    {
        IWebDriver Create();
    }

    public sealed class WebDriverFactory : IWebDriverFactory
    {
        public IWebDriver Create()
        {
            //todo: switch on config to get default driver type
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }
    }
}
