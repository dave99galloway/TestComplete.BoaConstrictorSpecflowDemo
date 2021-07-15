using Boa.Constrictor.Screenplay;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Abilities;

namespace TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Tasks
{
    public class Memorize<T> : ITask
    {
        private Memorize(T data)
        {
            Data = data;
        }

        public T Data { get; }

        public void PerformAs(IActor actor)
        {
            actor.Using<ActorMemory>().Memory.Memorize(data: Data);
        }

        public override string ToString() => $"Memorize a fact of type { typeof(T)}";

        public static Memorize<T> Fact(T data)
        {
            return new Memorize<T>(data: data);
        }
    }

    public class MemorizeBy<T> : ITask
    {
        private MemorizeBy(T data, string key)
        {
            Data = data;
            Key = key;
        }

        public T Data { get; }
        public string Key { get; }

        public void PerformAs(IActor actor)
        {
            actor.Using<ActorMemory>().Memory.Memorize(data: Data, key: Key);
        }

        public override string ToString() => $"Memorize a fact of type { typeof(T)}";

        public static MemorizeBy<T> Fact(T data, string key)
        {
            return new MemorizeBy<T>(data: data, key: key);
        }
    }
}
