﻿using Bede.Model;
using Bede.Requests;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Bede
{
    [Binding]
    public class BedeAPITestsSteps
    {
        private IRestResponse _restResponse;

        private string FormatMessage(string content)
        {
            Regex rgx = new Regex("[{-}-\\-\"]");
            return rgx.Replace(content, "");
        }

        [Given(@"I create a new book with parameters - (.*), (.*), (.*) and (.*)")]
        public void GivenICreateANewBookWithParameters(int Id, string Author, string Title, string Description)
        {
            var book = new Book()
            {
                Id = Id,
                Author = Author,
                Title = Title, 
                Description = Description
            };
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.POST)
                            .SetResource("api/books")
                            .AddJsonContent(book);
            _restResponse = request.Execute();

            ScenarioContext.Current.Add("Book", book);
            ScenarioContext.Current.Add("srvResponse", _restResponse);
        }
        public void GivenICreateANewBookWithParameters(int Id, string Author, string Title, string Description, bool iterate)
        {
            var book = new Book()
            {
                Id = Id,
                Author = Author,
                Title = Title,
                Description = Description
            };
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.POST)
                            .SetResource("api/books")
                            .AddJsonContent(book);
            _restResponse = request.Execute();
        }

        [Given(@"I create books with params")]
        public void WhenICreateBooksWithParams(Table table)
        {
            var books = table.CreateSet<Book>();

            foreach (Book book in books)
            {
                GivenICreateANewBookWithParameters(book.Id, book.Author, book.Title, book.Description, true);
            }

            ScenarioContext.Current.Add("BooksList", books);
        }

        [When(@"I update the last created book with parameters - id (.*), (.*), (.*) and (.*)")]
        public void WhenIUpdateTheLastCreatedBookWith(int Id, string Author, string Title, string Description)
        {
            var bookUpdateDetail = new Book()
            {
                Id = Id,
                Author = Author,
                Title = Title,
                Description = Description
            };
            var request = new HttpRequestWrapper()
                .SetMethod(Method.PUT)
                .SetResource($"api/books/{bookUpdateDetail.Id}")
                .AddJsonContent(bookUpdateDetail);
            _restResponse = request.Execute();

            ScenarioContext.Current.Add("BookUpdateResponse", _restResponse);
            ScenarioContext.Current.Add("BookUpdateDetails", bookUpdateDetail);
        }

        [When(@"I delete the created book")]
        public void GivenIDeleteABookWith()
        {
            var bookDel = ScenarioContext.Current.Get<Book>("Book");

            var request = new HttpRequestWrapper()
                            .SetMethod(Method.DELETE)
                            .SetResource("api/books").AddParameter("id", bookDel.Id);
            _restResponse = request.Execute();

            ScenarioContext.Current.Remove("srvResponse");
            ScenarioContext.Current.Add("srvResponse", _restResponse);
        }

        [When(@"I try to access the book by (.*)")]
        public void WhenITryToAccessTheBookBy(string p0)
        {
            var bookToAcc = ScenarioContext.Current.Get<Book>("Book");

            var request = new HttpRequestWrapper()
                            .SetMethod(Method.GET)
                            .SetResource("api/books").AddParameter("id", bookToAcc.Id);
            _restResponse = request.Execute();

            ScenarioContext.Current.Remove("srvResponse");
            ScenarioContext.Current.Add("srvResponse", _restResponse);
        }

        [When(@"I search for a book (.*) with term (.*)")]
        public void WhenISearchForABookWith(string param,string searchTerm)
         {
            var request = new HttpRequestWrapper()
                .SetMethod(Method.GET)
                .SetResource("api/books?").AddParameter($"{param}=", searchTerm);
            _restResponse = request.Execute();

            if(_restResponse.Content.Length > 0)
            {
                ScenarioContext.Current.Add("NotEmpty", _restResponse.Content);
            }
        }

        [When(@"I search for not existing book ""(.*)"" with term ""(.*)""")]
        public void WhenISearchWithNotExistingBookWithTerm(string param, string searchTerm)
        {
            var request = new HttpRequestWrapper()
                            .SetMethod(Method.GET)
                            .SetResource("api/books?").AddParameter($"{param}=", searchTerm);
            _restResponse = request.Execute();
        }

        [Then(@"system return a proper (.*) with correct details of the book")]
        public void ThenAProperStatusIsReturned(HttpStatusCode status)
        {
            var bookVerification = ScenarioContext.Current.Get<Book>("Book");
            var response = ScenarioContext.Current.Get<RestResponse>("srvResponse");
            var srvRespMsg = FormatMessage(response.Content);

            if (status.ToString().Equals("OK"))
            {
                Assert.AreEqual($"Id:{bookVerification.Id},Title:{bookVerification.Title},Description:{bookVerification.Description},Author:{bookVerification.Author}", srvRespMsg);
            }
            else if (status.ToString().Equals("BadRequest"))
            {
                if (bookVerification.Author.ToString().Length > 30)
                {
                    Assert.AreEqual("Message:Book.Author should not exceed 30 characters!\\r\\nParameter name: Book.Author", srvRespMsg);
                }
                else if (bookVerification.Title.Length > 100)
                {
                    Assert.AreEqual("Message:Book.Title should not exceed 100 characters!\\r\\nParameter name: Book.Title", srvRespMsg);
                }
                Assert.IsNotEmpty(bookVerification.Description);
            }
            else if (status.ToString().Equals("NoContent"))
            {
                Assert.AreEqual(status.ToString(), response.StatusCode.ToString());
            }
        }

        [Then(@"system return an author is required error message")]
        public void ThenSystemReturnAnAuthorisRequiredErrorMessage()
        {
            var srvRespMsg = ScenarioContext.Current.Get<RestResponse>("srvResponse").Content.ToString();
            srvRespMsg = FormatMessage(srvRespMsg);
            string requiredMsgChars = "Message:Book.Author is a required field.\\r\\nParameter name: book.Author";

            Assert.AreEqual(requiredMsgChars, srvRespMsg);
        }

        [Then(@"system return a title is required error message")]
        public void ThenSystemReturnATitleIsRequiredErrorMessage()
        {
            var srvRespMsg = ScenarioContext.Current.Get<RestResponse>("srvResponse").Content.ToString();
            srvRespMsg = FormatMessage(srvRespMsg);
            string requiredMsgChars = "Message:Book.Title is a required field\\r\\nParameter name: Book.Title";

            Assert.AreEqual(requiredMsgChars, srvRespMsg);
        }

        [Then(@"system return a id is required error message")]
        public void ThenSystemReturnAIdIsRequiredErrorMessage()
        {
            var srvRespMsg = ScenarioContext.Current.Get<RestResponse>("srvResponse").Content.ToString();
            srvRespMsg = FormatMessage(srvRespMsg);
            string requiredMsgChars = "Message:Book.Id should be a positive integer!\\r\\nParameter name: book.Id";

            Assert.AreEqual(requiredMsgChars, srvRespMsg);
        }



        [Then(@"system return a proper (.*) status")]
        public void ThenSystemReturnAProperNotFound(HttpStatusCode status)
        {
            var bookVerification = ScenarioContext.Current.Get<Book>("Book");
            var response = ScenarioContext.Current.Get<RestResponse>("srvResponse");
            var srvRespMsg = FormatMessage(response.Content);

             Assert.AreEqual($"Message:Book with id {bookVerification.Id} not found!", srvRespMsg);
        }

        [Then(@"the updated book details are coorect")]
        public void ThenTheUpdatedBookDetailsAreCoorect()
        {
            Book Book = JsonConvert.DeserializeObject<Book>(ScenarioContext.Current.Get<RestResponse>("BookUpdateResponse").Content);
            Book bookUpdateDetails = ScenarioContext.Current.Get<Book>("BookUpdateDetails");

            Assert.AreEqual(bookUpdateDetails.Author, Book.Author);
            Assert.AreEqual(bookUpdateDetails.Title, Book.Title);
            Assert.AreEqual(bookUpdateDetails.Description, Book.Description);
        }

        [Then(@"the list of books from search result and registered books are equal")]
        public void ThenTheListOfBooksFromSearchResultAndRegisteredBooksAreTheSame()
        {
            //Get expected books in IList, due to the usage of Context Values.
            var expBooksList = ScenarioContext.Current.Get<IList>("BooksList");

            //Get the actual result from the service as a string and desirialize it in List of object type Book.
            var actBooksList = JsonConvert.DeserializeObject<List<Book>>(ScenarioContext.Current.Get<string>("NotEmpty"));

            Assert.AreEqual(expBooksList.Count, actBooksList.Count);

            for (int i = 0; i < expBooksList.Count; i++)
            {
                var expBook = (Book)expBooksList[i];
                var actBook = actBooksList[i];

                Assert.AreEqual(expBook.Author, actBook.Author);
                Assert.AreEqual(expBook.Title, actBook.Title);
                Assert.AreEqual(expBook.Description, actBook.Description);
            }
        }

        [Then(@"the list of books returned by the search result is empty")]
        public void ThenTheListOfBooksReturnedByTheSearchResultIsEmpty()
        {
            Assert.AreEqual(0, ScenarioContext.Current.Values.Count);
        }
    }
}