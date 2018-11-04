using RestSharp;
using Bede.Model;
using Bede.Requests;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Net;
using System;
using System.Text.RegularExpressions;

namespace Bede
{
    [Binding]
    public class BedeAPITestsSteps
    {
        private IRestResponse _restResponse;
        private Book _book;
        private Book _bookUpdDtl;
        private HttpStatusCode _statusCode;
        private string _statusMessage;
        private string str;
        private string FormatMessage(string content)
        {
            Regex rgx = new Regex("[{-}-\\-\"]");
            str = rgx.Replace(content, "");
            return str;
        }

        [When(@"I create a new book with parameters - (.*), (.*), (.*) and (.*)")]
        public void GivenICreateANewBookWithParameters(int Id, string Author, string Title, string Description)
        {
            _book = new Book()
            {
                Id = Id,
                Author = Author,
                Title = Title,
                Description = Description
            };
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.POST)
                            .SetResource("api/books")
                            .AddJsonContent(_book);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusCode = _restResponse.StatusCode;
            _statusMessage = FormatMessage(_restResponse.Content);

            ScenarioContext.Current.Add("Book", _book);
            var si = ScenarioContext.Current.Values;

        }

        [When(@"I update the last created book with parameters - id (.*), (.*), (.*) and (.*)")]
        public void WhenIUpdateTheLastCreatedBookWith(int Id, string Author, string Title, string Description)
        {
            _bookUpdDtl = new Book()
            {
                Id = Id,
                Author = Author,
                Title = Title,
                Description = Description
            };
            var request = new HttpRequestWrapper()
                .SetMethod(Method.PUT)
                .SetResource("api/books")
                .AddJsonContent(_bookUpdDtl);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusCode = _restResponse.StatusCode;
            _statusMessage = FormatMessage(_restResponse.Content);

            ScenarioContext.Current.Add("BookUpd", _restResponse);
        }

        [When(@"I delete the created book")]
        public void GivenIDeleteABookWith()
        {
            _book = ScenarioContext.Current.Get<Book>("Book");

            // _book = ScenarioContext.Current.Get<Book>("");
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.DELETE)
                            .SetResource("api/books").AddParameter("id", _book.Id);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
        }

        [When(@"I try to access the book by (.*)")]
        public void WhenITryToAccessTheBookBy(string p0)
        {
            _book = ScenarioContext.Current.Get<Book>("Book");

            // _book = ScenarioContext.Current.Get<Book>("");
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.GET)
                            .SetResource("api/books").AddParameter("id", _book.Id);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusMessage = FormatMessage(_restResponse.Content);
        }

        [When(@"I create (.*) books with params")]
        public void WhenICreateBooksWithParams(Table table)
        {

        }


        [Then(@"system return a proper (.*)")]
        [Then(@"proper details of the registered book")]
        public void ThenAProperStatusIsReturned(HttpStatusCode status)
        {
            if (status.ToString().Equals("OK"))
            {
                Assert.AreEqual($"Id:{_book.Id},Title:{_book.Title},Description:{_book.Description},Author:{_book.Author}", _statusMessage);
            }
            else if (status.ToString().Equals("BadRequest"))
            {
                if (_book.Author.ToString().Length > 30)
                {
                    Assert.AreEqual("Message:Book.Author should not exceed 30 characters!\\r\\nParameter name: Book.Author", _statusMessage);
                }
                else if (_book.Title.Length > 100)
                {
                    Assert.AreEqual("Message:Book.Title should not exceed 100 characters!\\r\\nParameter name: Book.Author", _statusMessage);
                }
                Assert.IsNotEmpty(_book.Description);
            }
            else if (status.ToString().Equals("NoContent"))
            {
                //Response is empty in this case.
                Console.WriteLine("Item deleted!");
            }
            else if (status.ToString().Equals("NotFound"))
            {
                Assert.AreEqual($"Message:Book with id {_book.Id} not found!", _statusMessage);
                Console.WriteLine(_statusMessage);
            }
        }

        [Then(@"the updated book details are coorect")]
        public void ThenTheUpdatedBookDetailsAreCoorect()
        {
            Book bookUpd = ScenarioContext.Current.Get<Book>("Book");

            Assert.AreEqual(_bookUpdDtl.Author, bookUpd.Author);
            Assert.AreEqual(_bookUpdDtl.Title, bookUpd.Title);
            Assert.AreEqual(_bookUpdDtl.Description, bookUpd.Description);
        }


    }
}
