using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TestComplete.BoaConstrictorSpecflowDemo.Hooks
{
    [Binding]
    public sealed class ScreenplayHooks
    {

        private readonly IObjectContainer _objectContainer;

        public ScreenplayHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //IActor - won't use this once we get beyond the basics
            _objectContainer.RegisterFactoryAs<IActor>(c => SimpleWebActorFactory());
        }

        private Actor SimpleWebActorFactory()
        {
            Actor actor = new Actor(name: "a smart bear", logger: new ConsoleLogger());
            actor.Can(BrowseTheWeb.With(_objectContainer.Resolve<IWebDriver>()));
            return actor;
        }

        [AfterScenario]
        public void AfterScenario()
        {

        }
    }
}
