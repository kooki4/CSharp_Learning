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
        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario: Please restart the service due to need of flushing the data");
        }
    }
}
