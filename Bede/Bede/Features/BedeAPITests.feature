Feature: BedeAPITests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


@mytag
Scenario Outline: Create a new book
	When I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	Then system return a proper <Status>
	And proper details of the registered book
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
	When I create a new book with parameters - <Id>, <Author>, <Title> and <Description>
	When I delete the created book
	Then system return a proper <Status>
	When I try to access the book by <id>
	Then system return a proper <deleteStatus>
Examples: 
	| Id | Author    | Title    | Description   | Status    | deleteStatus |
	| 12 | Author 12 | Title 12 | Description13 | NoContent | NotFound     |


Scenario: Update Author, Title and Description of a book
	When I create a new book with parameters - 13, "Author13", "Title13" and "Description13"
    And I update the last created book with parameters - id 13, "Updated Author", "This is new title of the book." and "Description of the UDPATED book."
	Then the updated book details are coorect



Scenario: Get all 
	When I create eight books with params
	| Id | Author   | Title   | Description   |
	| 14 | Author13 | Title13 | Description13 |
	| 15 | Author13 | Title13 | Description13 |
	| 16 | Author13 | Title13 | Description13 |
	| 18 | Author13 | Title13 | Description13 |
	| 19 | Author13 | Title13 | Description13 |
	| 20 | Author13 | Title13 | Description13 |
	| 21 | Author13 | Title13 | Description13 |
	| 22 | Author13 | Title13 | Description13 |
	Then I can receive a proper list of books by searching with <tearms>
	And the details of each book
