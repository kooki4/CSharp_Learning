using System;
using TechTalk.SpecFlow;
using System.Diagnostics;

namespace BedeAutomationTask
{
    [Binding]
    public class StartLibraryManager
    {
        [Given(@"the Library Manager is started")]
        public void GivenTheLibraryManagerIsStarted()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
