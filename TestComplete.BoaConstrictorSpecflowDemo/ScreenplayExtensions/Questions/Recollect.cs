using Boa.Constrictor.Screenplay;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Abilities;

namespace TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Questions
{
    public class Recollect<TAnswer> : IQuestion<TAnswer>
    {
        private Recollect() {}
        public TAnswer RequestAs(IActor actor)
        {
            return actor.Using<ActorMemory>().Memory.Recollect<TAnswer>();
        }

        public override string ToString() => $"Recollect a fact of type { typeof( TAnswer)}";


        public static Recollect<TAnswer> Fact()
        {
            return new Recollect<TAnswer>();
        }
    }

    public class Lookup<TAnswer> : IQuestion<TAnswer>
    {
        public string ByKey { get; }

        public Lookup(string byKey)
        {
            ByKey = byKey;
        }

        public TAnswer RequestAs(IActor actor)
        {
            return actor.Using<ActorMemory>().Memory.Recollect<TAnswer>(key: ByKey);
        }

        public override string ToString() => $"Recollect a fact of type { typeof(TAnswer)} stored as {ByKey}";
        
        public static Lookup<TAnswer> Fact(string byKey)
        {
            return new Lookup<TAnswer>(byKey: byKey);
        }
    }
}
