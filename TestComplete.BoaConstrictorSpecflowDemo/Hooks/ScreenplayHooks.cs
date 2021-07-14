using BoDi;
using TechTalk.SpecFlow;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors;

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
        public void RegisterActorListFactory()
        {
            _objectContainer.RegisterFactoryAs<IActorsListFactory>(c => new ActorsListFactory());
        }

        [BeforeScenario]
        public void RegisterActorProvider()
        {
            _objectContainer.RegisterFactoryAs<IActorsProvider>(c =>
            {
                return new ActorsProvider(actors: c.Resolve<IActorsListFactory>().Create());
            });
        }

        [BeforeScenario]
        public void RegisterWebUiActorProvider()
        {
            _objectContainer.RegisterFactoryAs<IWebUiActorsProvider>(c =>
            {
                return new WebUiActorsProvider(
                    actorsProvider: c.Resolve<IActorsProvider>(),
                    actors: c.Resolve<IActorsListFactory>().Create(),
                    webDriverFactory: c.Resolve<IWebDriverFactory>());
            });
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _objectContainer.Resolve<IActorsProvider>().DismissCast();
        }
    }
}
