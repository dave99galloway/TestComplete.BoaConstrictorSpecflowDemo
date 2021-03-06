using BoDi;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Pages;

namespace TestComplete.BoaConstrictorSpecflowDemo.Hooks
{
    [Binding]
    public sealed class PageHooks
    {
        private readonly IObjectContainer _objectContainer;

        public PageHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // this is where we avoid relying on concrete implementations of page objects
            // in steps / interactions. We can re-wire pages based on custom criteria to 
            // allow for e.g. different locales / versions / white labeled products.
            // unnecessary if elements are consistently identifiable across different variations
            // but in practice this is unlikely
            // don't worry about pages / elements not being static, BoDi is controlling the lifecycle
            // so we'll only get one instance
            _objectContainer.RegisterFactoryAs<ILoginPage>(factoryDelegate: c => new LoginPage());

        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
