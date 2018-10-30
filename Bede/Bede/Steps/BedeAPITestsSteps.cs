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
        private string _statusContent;
        private string str;
        private string FormatMessage(string content)
        {
            Regex rgx = new Regex("[{-}-\\-\"]");
            str = rgx.Replace(content, "");
            return str;
        }

        [Given(@"I create a new book with parameter: (.*),(.*),(.*),(.*)")]
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
            _statusContent = FormatMessage(_restResponse.Content);
        }
        [Then(@"a proper add (.*) and correct book details are returned")]
        public void ThenAStatusIsReturned(HttpStatusCode status)
        {
            if(_statusCode.Equals(HttpStatusCode.OK)){
                Assert.AreEqual($"Id: {_book.Id}, Title: {_book.Title}, Description: {_book.Description}, Author: {_book.Author}", _statusContent);
            }
            else
            {
                Assert.AreEqual("Message:Book.Author should not exceed 30 characters!\\r\\nParameter name: Book.Author", _statusContent);
            }
            //whever i try to add already existing library
            //string message = string.Format("Message:Book with id {0} already exists!", _book.Id);
            Assert.AreEqual(status, _statusCode);
            //Assert.AreEqual(message, _statusContent);
        }

        [Given(@"I delete a book with (.*)")]
        public void GivenIDeleteABookWith(string id)
        {
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.DELETE)
                            .SetResource("api/books").AddParameter("id", id);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusCode = _restResponse.StatusCode;
            _statusContent = FormatMessage(_restResponse.Content);
        }

    }
}
