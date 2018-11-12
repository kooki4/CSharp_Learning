using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using Bede.Model;

namespace Bede.Steps
{
    [Binding]
    public sealed class BedeScenarioHooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            if(ScenarioContext.Current.Count > 0)
            {
               throw new SpecFlowException($"Context is not empty but it must be before executing each snecario. ContextInfo: {ScenarioContext.Current.Values}\n");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario: Please restart the service due to need of flushing the data");
        }
    }
}
