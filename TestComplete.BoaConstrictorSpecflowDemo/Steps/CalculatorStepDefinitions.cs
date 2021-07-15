using FluentAssertions;
using TechTalk.SpecFlow;

namespace TestComplete.BoaConstrictorSpecflowDemo.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(regex: "the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _scenarioContext.Add(key: "First", value: number);
        }

        [Given(regex: "the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _scenarioContext.Add(key: "Second", value: number);
        }

        [When(regex: "the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var first = _scenarioContext.Get<int>(key: "First");
            var second = _scenarioContext.Get<int>(key: "Second");

            _scenarioContext.Add(key: "Result", value: first + second);
        }

        [Then(regex: "the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            int actualResult = _scenarioContext.Get<int>(key: "Result");
            actualResult.Should().Be(expected: result);
        }
    }
}
