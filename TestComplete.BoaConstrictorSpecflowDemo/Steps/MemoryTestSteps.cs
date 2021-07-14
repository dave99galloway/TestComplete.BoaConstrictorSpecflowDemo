using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Actors;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Questions;
using TestComplete.BoaConstrictorSpecflowDemo.ScreenplayExtensions.Tasks;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]

    public sealed class MemoryTestSteps
    {
        private readonly IActorsProvider _actorsProvider;

        public MemoryTestSteps(IActorsProvider actorsProvider)
        {
            _actorsProvider = actorsProvider;
        }

        [When(@"""(.*)"" memorises this list")]
        public void WhenMemorisesThisList(string actorName, Table table)
        {
           // var data = table.CreateSet<string>();
            _actorsProvider.ActorCalled(actorName).AttemptsTo(Memorize<TableRows>.Fact(table.Rows));
         }

        [Then(@"""(.*)"" remembers the list")]
        public void ThenRemembersTheList(string actorName, Table table)
        {
            var actual = _actorsProvider.ActorCalled(actorName).AskingFor(Recollect<TableRows>.Fact());
            actual.Count.Should().Be(table.Rows.Count);
        }

    }
}
