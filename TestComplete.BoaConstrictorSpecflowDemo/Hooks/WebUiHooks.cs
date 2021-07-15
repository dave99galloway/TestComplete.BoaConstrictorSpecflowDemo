using BoDi;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors;

namespace TestComplete.BoaConstrictorSpecflowDemo.Hooks
{
    [Binding, Scope(Tag = "WebUi")]
    public sealed class WebUiHooks
    {
        private readonly IObjectContainer _objectContainer;

        public WebUiHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterFactoryAs<IWebDriverFactory>(factoryDelegate: c => new WebDriverFactory());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _objectContainer.Resolve<IWebUiActorsProvider>().DismissCast();
        }
    }
}
