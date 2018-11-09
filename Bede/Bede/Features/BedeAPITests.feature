Feature: BedeAPITests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


@mytag
Scenario Outline: Create a new book
	Given I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	Then system return a proper <Status> with correct details of the book

Examples:
	| Id | Author                          | Title                                                                                                 | Description                                                                                                                                                                                                                                                      | Status     |
	| 1  | AuthorWithTwentyNineLettersss   | Title 1                                                                                               | Test                                                                                                                                                                                                                                                             | OK         |
	| 2  | AuthorWithThirtyLetterssssssss  | Title 2                                                                                               | Test                                                                                                                                                                                                                                                             | OK         |
	| 3  | AuthorWithThirtyOneLetterssssss | Title 3                                                                                               | Test                                                                                                                                                                                                                                                             | BadRequest |
	| 4  | Author with blank spaces        | Title 4                                                                                               | Test                                                                                                                                                                                                                                                             | OK         |
	| 5  | Author H. Writer                | Title 5                                                                                               | Test                                                                                                                                                                                                                                                             | OK         |
	| 6  | A.Symbols} @!["#$%&'()*+,-./]   | Title 6                                                                                               | Description 4                                                                                                                                                                                                                                                    | OK         |
	| 7  | Author                          | TitleWithNinetyNineCharactersAsASingleWorkTitleWithNinetyNineCharactersAsASingleWorkTitleWithNinety   |                                                                                                                                                                                                                                                                  | OK         |
	| 8  | Author                          | Title With a Hundred Characters Title With a Hundred Characters Title With a Hundred Charactersssss   | Description 4                                                                                                                                                                                                                                                    | OK         |
	| 9  | Author                          | Title With a Hundred and One Characters Title With a Hundred and One Characters Title With a Hundredd |                                                                                                                                                                                                                                                                  | BadRequest |
	| 10 | Author                          | Title with {symbols} @!"#$%&'()*+,-./                                                                 | Description 4                                                                                                                                                                                                                                                    | OK         |
	| 11 | Author                          | TitleWithTwentyNice                                                                                   | Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description witх | OK         |


Scenario Outline: Delete a book and verify it cannot be accessed
	Given I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	When I delete the created book
	Then system return a proper <Status>
	When I try to access the book by <id>
	Then system return a proper <deleteStatus>

Examples: 
	| Id | Author    | Title    | Description    | Status    | deleteStatus |
	| 12 | Author 12 | Title 12 | Description 12 | NoContent | NotFound     |


Scenario: Create and update a book
	Given I create a new book with parameters - 13, "Author13", "Title13" and "Description13"
    When I update the last created book with parameters - id 13, "Updated Author", "This is new title of the book." and "Description of the UDPATED book."
	Then the updated book details are coorect

Scenario: Receive list of books matching the search term for Title
	Given I create books with params
	| Id | Author          | Title             | Description            |
	| 14 | Author          | Test Title 14     | Description of book 14 |
	| 15 | Author          | Title of the Test | Description13          |
	| 16 | Author J Oliver | TestTitle         | Description13          |
	| 18 | Author J Oliver | TitleOfTheTest    | Description13          |
	| 19 | Author J Oliver | TitleOfTestABC    | Description13          |
	| 20 | Author J Oliver | %20Test%          | Description13          |
	| 21 | Author J Oliver | \n\Test\Title     | Description13          |
	| 22 | Author J Oliver | $#!Test*&^%       | Description13          |
	When I search for a book "Title" with term "Test"
	Then the list of books from search result and registered books are the equal


Scenario: Receive list of books matching the search term for Author
	Given I create books with params
	| Id | Author               | Title             | Description            |
	| 14 | aztecAuthor'Def      | Test Title 14     | Description of book 14 |
	| 15 | \nAuthor\            | Title of the Test | Description13          |
	| 16 | %20Author% J Oliver  | TestTitle         | Description13          |
	| 18 | $#!Test*&^% J Oliver | TitleOfTheTest    | Description13          |
	When I search for a book "Auhtor" with term "Test"
	Then the list of books from search result and registered books are the equal


Scenario: Receive empty list of books - search with dummy or blank term 
	Given I create books with params
	| Id | Author          | Title             | Description            |
	| 23 | Author          | Test Title 14     | Description of book 14 |
	| 24 | Author          | Title of the Test | Description13          |
	| 25 | Author J Oliver | TestTitle         | Description13          |
	When I search for a book "Title" with term "None"
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