using Boa.Constrictor.Screenplay;
using TechTalk.SpecFlow;

namespace TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Abilities
{
    public class ActorMemory : IAbility
    {
        public readonly IActorContext Memory;
        private ActorMemory(IActorContext memory)
        {
            Memory = memory;
        }
        public static ActorMemory RememberThings() => new ActorMemory(memory: new ActorContext());
    }

    public interface IActorContext
    {
        public T Recollect<T>();
        public T Recollect<T>(string key);
        public void Memorize<T>(T data);
        public void Memorize<T>(T data, string key);
    }

    public class ActorContext :  IActorContext
    {
        private readonly Memory _memory;

        public ActorContext()
        {
            _memory = new Memory();
        }

        private class Memory : SpecFlowContext
        {

        }

        public void Memorize<T>(T data)
        {
            _memory.Set(data: data);
        }

        public void Memorize<T>(T data, string key)
        {
            _memory.Set(data: data, key: key);
        }

        public T Recollect<T>()
        {
            return _memory.Get<T>();
                }

        public T Recollect<T>(string key)
        {
            return _memory.Get<T>(key: key);
        }
    }
}
