using System;
using TechTalk.SpecFlow;

namespace BedeAutomationTask
{
    [Binding]
    public class LibrarySteps
    {
        [Given(@"I add a new book with (.*), (.*), (.*) and (.*)")]
        public void GivenIAddANewBookWithAnd(string p0, string p1, string p2, string p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"positive (.*) is returned")]
        public void ThenPositiveIsReturned(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
