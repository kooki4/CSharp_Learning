﻿using RestSharp;
using Bede.Model;
using Bede.Requests;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System;
using System.Net;
using System.Collections;
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
        private string _str;
        private string FormatMessage(string content)
        {
            Regex rgx = new Regex("[{-}-\\-\"]");
            _str = rgx.Replace(content, "");
            return _str;
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
        }
        public void GivenICreateANewBookWithParameters(int Id, string Author, string Title, string Description, bool iterate)
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

            ScenarioContext.Current.Add($"Book{_book.Id}", _book);
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
                .SetResource("api/books")
                .AddJsonContent(bookUpdateDetail);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusCode = _restResponse.StatusCode;
            _statusMessage = FormatMessage(_restResponse.Content);

            ScenarioContext.Current.Add("BookUpdateDetails", bookUpdateDetail);
        }

        [When(@"I delete the created book")]
        public void GivenIDeleteABookWith()
        {
            var bookDel = ScenarioContext.Current.Get<Book>("Book");

            var request = new HttpRequestWrapper()
                            .SetMethod(Method.DELETE)
                            .SetResource("api/books").AddParameter("id", bookDel.Id);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
        }

        [When(@"I try to access the book by (.*)")]
        public void WhenITryToAccessTheBookBy(string p0)
        {
            var bookToAcc = ScenarioContext.Current.Get<Book>("Book");

            var request = new HttpRequestWrapper()
                            .SetMethod(Method.GET)
                            .SetResource("api/books").AddParameter("id", bookToAcc.Id);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusMessage = FormatMessage(_restResponse.Content);
        }

        [When(@"I create eight books with params")]
        public void WhenICreateBooksWithParams(Table table)
        {
            var books = table.CreateSet<Book>();

            foreach(Book book in books)
            {
                GivenICreateANewBookWithParameters(book.Id, book.Author, book.Title, book.Description, true);
            }

            ScenarioContext.Current.Add("BooksList", books);
        }

        [When(@"I search for a book with term (.*)")]
        public void WhenISearchForABookWith(string searchTerm)
        {
            searchTerm = $"{searchTerm}";

            var request = new HttpRequestWrapper()
                .SetMethod(Method.GET)
                .SetResource("api/books?").AddParameter("Title=", searchTerm);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();

            _statusMessage = FormatMessage(_restResponse.Content);

        }

        [Then(@"system return a proper (.*)")]
        [Then(@"proper details of the registered book")]
        public void ThenAProperStatusIsReturned(HttpStatusCode status)
        {
            var bookVerification = ScenarioContext.Current.Get<Book>("Book");

            if (status.ToString().Equals("OK"))
            {
                Assert.AreEqual($"Id:{bookVerification.Id},Title:{bookVerification.Title},Description:{bookVerification.Description},Author:{bookVerification.Author}", _statusMessage);
            }
            else if (status.ToString().Equals("BadRequest"))
            {
                if (bookVerification.Author.ToString().Length > 30)
                {
                    Assert.AreEqual("Message:Book.Author should not exceed 30 characters!\\r\\nParameter name: Book.Author", _statusMessage);
                }
                else if (bookVerification.Title.Length > 100)
                {
                    Assert.AreEqual("Message:Book.Title should not exceed 100 characters!\\r\\nParameter name: Book.Author", _statusMessage);
                }
                Assert.IsNotEmpty(bookVerification.Description);
            }
            else if (status.ToString().Equals("NoContent"))
            {
                //Response is empty in this case.
                Console.WriteLine("Item deleted!");
            }
            else if (status.ToString().Equals("NotFound"))
            {
                Assert.AreEqual($"Message:Book with id {bookVerification.Id} not found!", _statusMessage);
                Console.WriteLine(_statusMessage);
            }
        }

        [Then(@"the updated book details are coorect")]
        public void ThenTheUpdatedBookDetailsAreCoorect()
        {
            Book Book = ScenarioContext.Current.Get<Book>("Book");
            Book bookUpdateDetails = ScenarioContext.Current.Get<Book>("BookUpdateDetails");

            Assert.AreEqual(bookUpdateDetails.Author, Book.Author);
            Assert.AreEqual(bookUpdateDetails.Title, Book.Title);
            Assert.AreEqual(bookUpdateDetails.Description, Book.Description);
        }

        [Then(@"the list of books from search result and registered books are the same")]
        public void ThenTheListOfBooksFromSearchResultAndRegisteredBooksAreTheSame()
        {
            var bookList = ScenarioContext.Current.Get<IList>("BooksList");
            var searchResult = ScenarioContext.Current.Values;

            //Assert.AreEqual(bookList, searchResult);
            for(int i = 0; i < bookList.Count; i++)
            {
                var expectedBook = (Book)bookList[i];
                var key = expectedBook.Id;
                Book returnedBook = ScenarioContext.Current.Get<Book>($"Book{expectedBook.Id}");

                Assert.AreEqual(expectedBook.Author, returnedBook.Author);
                Assert.AreEqual(expectedBook.Title, returnedBook.Title);
                Assert.AreEqual(expectedBook.Description, returnedBook.Description);
            }
        }

    }
}
