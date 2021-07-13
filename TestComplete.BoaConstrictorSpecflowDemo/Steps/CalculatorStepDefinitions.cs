using TechTalk.SpecFlow;
using FluentAssertions;
using TestComplete.BoaConstrictorSpecflowDemo.Drivers;
using TestComplete.BoaConstrictorSpecflowDemo.Pages;

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

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _scenarioContext.Add("First", number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _scenarioContext.Add("Second", number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var first = _scenarioContext.Get<int>("First");
            var second = _scenarioContext.Get<int>("Second");

            _scenarioContext.Add("Result", first + second);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            int actualResult = _scenarioContext.Get<int>("Result");
            actualResult.Should().Be(result);
        }
    }
}
