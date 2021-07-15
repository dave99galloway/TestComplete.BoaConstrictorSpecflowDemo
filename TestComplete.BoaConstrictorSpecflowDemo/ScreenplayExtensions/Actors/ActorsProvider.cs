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
        public ActorsList()
        {
            CastList = new ConcurrentDictionary<string, Lazy<IActor>>();
        }

        public ConcurrentDictionary<string, Lazy<IActor>> CastList { get; }
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
            _actors = actors ?? throw new ArgumentNullException(paramName: nameof(actors));
        }

        public IActor ActorCalled(string name)
        {            
            return _actors.CastList.GetOrAdd(key: name, valueFactory: newName => new Lazy<IActor>(valueFactory: () =>
            {              
                var actor = new Actor(name: newName, logger: new ConsoleLogger());
                actor.Can(ability: RememberThings());
                return actor;
            })).Value;
        }

        public void DismissCast()
        {
            _actors.CastList.Clear();
        }
    }
}
