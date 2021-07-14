using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using System;
using System.Collections.Concurrent;
using static TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Abilities.ActorMemory;

namespace TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors
{

    public interface IActorsProvider
    {
        IActor ActorCalled(string name);
        void DismissCast();
    }

    public interface IActorsList
    {
        ConcurrentDictionary<string, Lazy<IActor>> CastList { get; }
    }

    public sealed class ActorsList : IActorsList
    {
        private readonly ConcurrentDictionary<string, Lazy<IActor>> castList;

        public ActorsList()
        {
            castList = new ConcurrentDictionary<string, Lazy<IActor>>();
        }

        public ConcurrentDictionary<string, Lazy<IActor>> CastList => castList;
    }

    public interface IActorsListFactory
    {
        public IActorsList Create();
    }

    public sealed class ActorsListFactory : IActorsListFactory
    {
        public IActorsList Create()
        {
            return new ActorsList();
        }
    }

    public sealed class ActorsProvider : IActorsProvider
    {
        private readonly IActorsList _actors;

        public ActorsProvider(IActorsList actors)
        {
            _actors = actors ?? throw new ArgumentNullException(nameof(actors));
        }

        public IActor ActorCalled(string name)
        {            
            return _actors.CastList.GetOrAdd(name, newName => new Lazy<IActor>(() =>
            {              
                var actor = new Actor(name: newName, logger: new ConsoleLogger());
                actor.Can(RememberThings());
                return actor;
            })).Value;
        }

        public void DismissCast()
        {
            _actors.CastList.Clear();
        }
    }
}
