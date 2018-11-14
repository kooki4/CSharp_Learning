Feature: Libraray Management Tests
	In manage a library content
	As a Library Manager
	I want to be able to Create, Update, Delete and Find books


@mytag
Scenario Outline: Create new book with valid data validate returned status and book details
	Given I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	Then system return a proper <Status> with correct details of the book

Examples:
	| Id | Author                          | Title                                                                                                 | Description                                                             | Status     |
	| 1  | AuthorWithTwentyNineLettersss   | Title 1                                                                                               | Description 1 Test                                                      | OK         |
	| 2  | AuthorWithThirtyLetterssssssss  | Title 2                                                                                               | Description 2 Test                                                      | OK         |
	| 3  | AuthorWithThirtyOneLetterssssss | Title 3                                                                                               | Description 3 Test                                                      | BadRequest |
	| 4  | Author with blank spaces        | Title 4                                                                                               | Description 4 Test                                                      | OK         |
	| 5  | A.{symbols} @!["#$%&'()*+,-./]  | Title 6                                                                                               | Description 6 Test                                                      | OK         |
	| 6  | Author                          | TitleWithNinetyNineCharactersAsASingleWorkTitleWithNinetyNineCharactersAsASingleWorkTitleWithNinety   | Description 7 Test                                                      | OK         |
	| 7  | Author                          | Title With a Hundred Characters Title With a Hundred Characters Title With a Hundred Characterssssss  | Description 8 Test                                                      | OK         |
	| 8  | Author                          | Title With a Hundred and One Characters Title With a Hundred and One Characters Title With a Hundredd | Description 9 Test                                                      | BadRequest |
	| 9  | Author                          | Title with {symbols} @!"#$%&'()*+,-./                                                                 | Description 10 Test                                                     | OK         |
	| 10 | Author                          | TitleWithTwentyNice                                                                                   | Description with {256} letters. \\Descr\\iption with 256 [lette]rs. Des | OK         |


Scenario Outline: Create new book without an author
	Given I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	Then system return an author is required error message

Examples:
	| Id | Author | Title      | Description      |
	| 1  |        | Book Title | Book Description | 


Scenario Outline: Create new book without a title
	Given I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	Then system return a title is required error message

Examples:
	| Id | Author          | Title | Description      |
	| 1  | Author H Oliver |       | Book Description |


Scenario Outline: Create new book without id
	Given I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	Then system return a id is required error message

Examples:
	| Id | Author | Title | Description |
	| -1 | Author | Title |             |
	| 0  | Author | Title | Description |


Scenario Outline: Delete a book and verify that it cannot be accessed
	Given I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	When I delete the created book
	Then system return a proper <Status> with correct details of the book
	When I try to access the book by <id>
	Then system return a proper <NotFound> status

Examples: 
	| Id | Author   | Title   | Description   | Status    | NotFound |
	| 1  | Author 1 | Title 1 | Description 1 | NoContent | NotFound |


Scenario: Create and update a book
	Given I create a new book with parameters - 13, "Author13", "Title13" and "Description13"
    When I update the last created book with parameters - id 13, "Updated Author", "This is new title of the book." and "Description of the UDPATED book."
	Then the updated book details are coorect


Scenario: Receive list of books matching the search term for Title
	Given I create books with params
	| Id | Author          | Title             | Description           |
	| 1  | Author          | Test Title 1      | Description of book 1 |
	| 2  | Author          | Title of the Test | Description           |
	| 3  | Author J Oliver | TestTitle         | Description           |
	| 4  | Author J Oliver | TitleOfTheTest    | Description           |
	| 5  | Author J Oliver | TitleOfTestABC    | Description           |
	| 6  | Author J Oliver | %20Test           | Description           |
	| 7  | Author J Oliver | \n\Test\Title     | Description           |
	| 8  | Author J Oliver | $#!Test*&^%       | Description           |
	When I search for a book "Title" with term "Test"
	Then the list of books from search result and registered books are equal


Scenario: Receive list of books matching the search term for Author
	Given I create books with params
	| Id | Author               | Title             | Description              |
	| 1  | aztecAuthor'Def      | Test Title 1      | Description of Book 1    |
	| 2  | \nAuthor\            | Title of the Test | Description of Book  2   |
	| 3  | %20Author% J Oliver  | TestTitle         | Description of Book   3  |
	| 4  | $#!Test*&^% J Oliver | TitleOfTheTest    | Description of Book    4 |
	When I search for a book "Auhtor" with term "Author"
	Then the list of books from search result and registered books are equal


Scenario: Receive list of books matching the search term for Description
	Given I create books with params
	| Id | Author        | Title              | Description               |
	| 1  | Autor D James | Test Title         | TheStoryOfThisBook        |
	| 2  | Author        | Title of Test Book | The \Story of \ this book |
	| 3  | J Oliver      | TestTitle          | %20Story% of this book .  |
	| 4  | Oliver        | TitleOfTheTest     | $$%!@StoryB#o*o&k of Book |
	When I search for a book "Description" with term "Story"
	Then the list of books from search result and registered books are equal


Scenario: Receive empty list of books - search with dummy or blank term 
	Given I create books with params
	| Id | Author          | Title             | Description              |
	| 1  | Author          | Test Title 14     | Description of book 14   |
	| 2  | Author          | Title of the Test | Description 14           |
	| 3  | Author J Oliver | Amazing Birds     | Description of the novel |
	When I search for not existing book "Title" with term "None"
	Then the list of books returned by the search result is empty
	When I search for a book "Title" with term ""
	Then the list of books returned by the search result is empty
	When I search for a book "Author" with term "None"
	Then the list of books returned by the search result is empty
	When I search for a book "Author" with term ""
	Then the list of books returned by the search result is empty
	When I search for a book "Description" with term "None"
	Then the list of books returned by the search result is empty
	When I search for a book "Description" with term ""
	Then the list of books returned by the search result is empty