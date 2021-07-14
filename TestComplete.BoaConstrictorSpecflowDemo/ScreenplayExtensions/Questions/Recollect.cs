using Boa.Constrictor.Screenplay;
using System;
using System.Collections.Generic;
using System.Text;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Abilities;

namespace TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Questions
{
    public class Recollect<TAnswer> : IQuestion<TAnswer>
    {
        private Recollect()
        {

        }
        public TAnswer RequestAs(IActor actor)
        {
            return actor.Using<ActorMemory>().Memory.Recollect<TAnswer>();
        }

        public static Recollect<TAnswer> Fact()
        {
            return new Recollect<TAnswer>();
        }
    }
}
