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
        private HttpStatusCode _statusCode;
        private string _statusMessage;
        private string str;
        private string FormatMessage(string content)
        {
            Regex rgx = new Regex("[{-}-\\-\"]");
            str = rgx.Replace(content, "");
            return str;
        }

        [When(@"I create a new book with parameter: (.*),(.*),(.*),(.*)")]
        public void GivenICreateANewBookWithParameterA_TestDescription(int Id, string Author, string Title, string Description)
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
        }
        [Then(@"a proper (.*) is returned from system")]
        [Then(@"correct book details are returned from system")]
        public void ThenAProperStatusIsReturned(HttpStatusCode status)
        {
            Assert.IsTrue(_statusCode.ToString().Equals("OK") || _statusCode.ToString().Equals("BadRequest"));

            if (status.Equals(HttpStatusCode.OK))
            {
                Assert.AreEqual($"Id:{_book.Id},Title:{_book.Title},Description:{_book.Description},Author:{_book.Author}", _statusMessage);
            }
            else if (status.Equals(_restResponse.ResponseStatus.ToString()))
            {
                Assert.AreEqual("Message:Book.Author should not exceed 30 characters!\\r\\nParameter name: Book.Author", _statusMessage);
            }
//else if (status.Equals(HttpStatusCode.C))
        }

        [Then(@"system return a proper already exists (.*)")]
        public void ThenSystemReturnAProperAlreadyExistsStatus(HttpStatusCode status)
        {
            if (status.Equals(HttpStatusCode.BadRequest))
            {
                Assert.AreEqual(status, _statusMessage);
            }
        }

        [When(@"I delete a book with (.*)")]
        public void GivenIDeleteABookWith(string id)
        {
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.DELETE)
                            .SetResource("api/books").AddParameter("id", id);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
// _statusCode = _restResponse.StatusDescription;
            _statusMessage = _restResponse.ResponseStatus.ToString();
        }

    }
}
