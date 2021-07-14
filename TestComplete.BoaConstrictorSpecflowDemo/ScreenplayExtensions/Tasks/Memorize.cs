using Boa.Constrictor.Screenplay;
using System;
using System.Collections.Generic;
using System.Text;
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
            actor.Using<ActorMemory>().Memory.Memorize<T>(Data);
        }

        public static Memorize<T> Fact(T data)
        {
            return new Memorize<T>(data);
        }
    }
}
