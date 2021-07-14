using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System;
using System.Collections.Concurrent;
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
        private readonly ConcurrentDictionary<string, Lazy<IActor>> _actors;
        private readonly IWebDriverFactory _webDriverFactory;


        public WebUiActorsProvider(IActorsProvider actorsProvider, ConcurrentDictionary<string, Lazy<IActor>> actors, IWebDriverFactory webDriverFactory)
        {
            _actorsProvider = actorsProvider;
            _actors = actors;
            _webDriverFactory = webDriverFactory;
        }

        public IActor ActorCalled(string name)
        {
            return _actors.GetOrAdd(name, newName => new Lazy<IActor>(() =>
            {
                var actor = _actorsProvider.ActorCalled(name);
                actor.Can(BrowseTheWeb.With(_webDriverFactory.Create()));
                return actor;

            })).Value;
        }

        public void DismissCast()
        {
            _actors.Values.ToList().ForEach(actor => actor.Value.AttemptsTo(QuitWebDriver.ForBrowser()));
            _actors.Clear();
        }
    }
}
