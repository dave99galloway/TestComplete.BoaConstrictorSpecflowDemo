using FluentAssertions;
using TechTalk.SpecFlow;
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

        [When(regex: @"""(.*)"" memorises this list")]
        public void WhenMemorisesThisList(string actorName, Table table)
        {
           // var data = table.CreateSet<string>();
            _actorsProvider.ActorCalled(name: actorName).AttemptsTo(task: Memorize<TableRows>.Fact(data: table.Rows));
         }

        [Then(regex: @"""(.*)"" remembers the list")]
        public void ThenRemembersTheList(string actorName, Table table)
        {
            var actual = _actorsProvider.ActorCalled(name: actorName).AskingFor(question: Recollect<TableRows>.Fact());
            actual.Count.Should().Be(expected: table.Rows.Count);
        }

    }
}
