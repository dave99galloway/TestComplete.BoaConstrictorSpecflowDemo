using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System;
using System.Linq;

using TestComplete.BoaConstrictorSpecflowDemo.Drivers;

namespace TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors
{
    public interface IWebUiActorsProvider : IActorsProvider
    {
        new IActor ActorCalled(string name);
    }

    public sealed class WebUiActorsProvider : IWebUiActorsProvider
    {
        private readonly IActorsProvider _actorsProvider;
        private readonly IActorsList _actors;
        private readonly IWebDriverFactory _webDriverFactory;

        public WebUiActorsProvider(IActorsProvider actorsProvider, IActorsList actors, IWebDriverFactory webDriverFactory)
        {
            _actorsProvider = actorsProvider;
            _actors = actors;
            _webDriverFactory = webDriverFactory;
        }

        public IActor ActorCalled(string name)
        {
            return _actors.CastList.GetOrAdd(key: name, valueFactory: newName => new Lazy<IActor>(valueFactory: () =>
            {
                var actor = _actorsProvider.ActorCalled(name: name);
                actor.Can(ability: BrowseTheWeb.With(driver: _webDriverFactory.Create()));
                return actor;

            })).Value;
        }

        public void DismissCast()
        {
            _actors.CastList.Values.ToList().ForEach(action: actor => actor.Value.AttemptsTo(task: QuitWebDriver.ForBrowser()));
            _actors.CastList.Clear();
        }
    }
}
