using System;
using TechTalk.SpecFlow;

namespace Bede.Steps
{
    [Binding]
    public sealed class BedeScenarioHooks
    {
        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario: Please restart the service due to need of flushing the data");
        }
    }
}
