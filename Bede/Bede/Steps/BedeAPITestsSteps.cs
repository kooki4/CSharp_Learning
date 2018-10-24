using RestSharp;
using Bede.Model;
using Bede.Requests;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Net;

namespace Bede
{
    [Binding]
    public class BedeAPITestsSteps
    {
        private IRestResponse _restResponse;
        private Book _book;
        private HttpStatusCode _statusCode;
        private string[] _statusDesc = null;
        private List<Book> _books;

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
            _statusDesc = _restResponse.Content.Split();
        }
        [Then(@"a (.*) is returned")]
        public void ThenAStatusIsReturned(HttpStatusCode status)
        {
            var asd = typeof(_book);
            string message = string.Format("{\"Message\":\"Book with id {0} already exists!\"}", _book.Id);
            Assert.AreEqual(message, _statusDesc);
        }
    }
}
