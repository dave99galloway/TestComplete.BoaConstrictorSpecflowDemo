using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using System;
using System.Collections.Concurrent;

namespace TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors
{

    public interface IActorsProvider
    {
        IActor ActorCalled(string name);
        void DismissCast();
    }

    public sealed class ActorsProvider : IActorsProvider
    {
        private readonly ConcurrentDictionary<string, Lazy<IActor>> _actors;

        public ActorsProvider(ConcurrentDictionary<string, Lazy<IActor>> actors)
        {
            _actors = actors ?? throw new ArgumentNullException(nameof(actors));
        }

        public IActor ActorCalled(string name)
        {
            var actor = _actors.GetOrAdd(name, newName => new Lazy<IActor>(() =>
            {
                //todo: add ability to memorise/recall - all actors will need this
                return new Actor(name: newName, logger: new ConsoleLogger());
            }));

            return actor.Value;
        }

        public void DismissCast()
        {
            _actors.Clear();
        }
    }
}
