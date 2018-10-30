﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Bede.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("BedeAPITests")]
    public partial class BedeAPITestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BedeAPITests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BedeAPITests", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a new books")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        [NUnit.Framework.TestCaseAttribute("1", "AuthorWithTwentyNineLettersss", "Title 1", "Test", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("2", "AuthorWithThirtyLetterssssssss", "Title 2", "Test", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("3", "AuthorWithThirtyOneLetterssssss", "Title 3", "Test", "Bad request", null)]
        [NUnit.Framework.TestCaseAttribute("4", "Author with blank spaces", "Title 4", "Test", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("5", "Author H. Writer", "Title 5", "Test", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("6", "A.Symbols} @![\"#$%&\'()*+,-./]", "Title 6", "Description 4", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("7", "Author", "TitleWithNinetyNineCharactersAsASingleWorkTitleWithNinetyNineCharactersAsASingleW" +
            "orkTitleWithNinety", "", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("8", "Author", "TitleWithNinety Nine Characters Work Title With NinetyNine Characters WorkTitle W" +
            "ithNinetyCharacter", "Description 4", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("9", "Author", "Title With a Hundred Characters Title With a Hundred Characters Title With a Hund" +
            "red Characterssssss", "", "Bad request", null)]
        [NUnit.Framework.TestCaseAttribute("10", "Author", "Title with {symbols} @!\"#$%&\'()*+,-./", "Description 4", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("11", "Author", "TitleWithTwentyNice", "Description with 255 letters. Description with 255 letters. Description with 255 " +
            "letters. Description with 255 letters. Description with 255 letters. Description" +
            " with 255 letters. Description with 255 letters. Description with 255 letters. D" +
            "escription wit", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("12", "Author", "TitleWithTwentyNice", @"Description with 256 letters. Description with 255 letters. Description with 256 letters. Description with 256 letters. Description with 256 letters. Description with 255 letters. Description with 256 letters. Description with 256 letters. Description with", "OK", null)]
        public virtual void CreateANewBooks(string id, string author, string title, string description, string status, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new books", null, @__tags);
#line 7
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.When(string.Format("I create a new book with parameter: {0},{1},{2},{3}", id, author, title, description), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then(string.Format("a proper {0} is returned from system", status), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And("correct book details are returned from system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create the same book")]
        [NUnit.Framework.TestCaseAttribute("13", "Author", "Test", "Description", "OK", null)]
        [NUnit.Framework.TestCaseAttribute("14", "Author", "Test", "Description", "\"Message:Book with id 14 already exists!\"", null)]
        public virtual void CreateTheSameBook(string id, string author, string title, string description, string status, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create the same book", null, exampleTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 29
 testRunner.When(string.Format("I create a new book with parameter: {0},{1},{2},{3}", id, author, title, description), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then(string.Format("system return a proper already exists {0}", status), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove a book and check the books left into the library")]
        [NUnit.Framework.TestCaseAttribute("1", "Completed", null)]
        public virtual void RemoveABookAndCheckTheBooksLeftIntoTheLibrary(string id, string status, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove a book and check the books left into the library", null, exampleTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 37
 testRunner.When(string.Format("I delete a book with {0}", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then(string.Format("a proper {0} is returned from system", status), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove already deleted book")]
        public virtual void RemoveAlreadyDeletedBook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove already deleted book", null, ((string[])(null)));
#line 46
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update the details of a book")]
        public virtual void UpdateTheDetailsOfABook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update the details of a book", null, ((string[])(null)));
#line 48
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 49
 testRunner.When("I update a book with <id> with <Authro>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.Then("the book is correctly book updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.When("I update the <", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get all books")]
        public virtual void GetAllBooks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get all books", null, ((string[])(null)));
#line 53
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 54
 testRunner.Given("I request all books from the librabry", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.Then("I receive a full list of books", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("the details of each book", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get a book details")]
        public virtual void GetABookDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get a book details", null, ((string[])(null)));
#line 59
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 60
 testRunner.Given("I request a the details of a single book from the library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
 testRunner.Then("I receive the", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
