Feature: BedeAPITests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
# I may want to replace Given with When since When is the ACTION word
@mytag
Scenario Outline: Create a new books
	When I create a new book with parameter: <Id>,<Author>,<Title>,<Description>
	Then a proper <Status> is returned from system 
	And correct book details are returned from system
# ToDo
#	And correct list of all available books

Examples:
	| Id | Author                          | Title                                                                                                | Description                                                                                                                                                                                                                                                      | Status      |
	| 1  | AuthorWithTwentyNineLettersss   | Title 1                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 2  | AuthorWithThirtyLetterssssssss  | Title 2                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 3  | AuthorWithThirtyOneLetterssssss | Title 3                                                                                              | Test                                                                                                                                                                                                                                                             | Bad request |
	| 4  | Author with blank spaces        | Title 4                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 5  | Author H. Writer                | Title 5                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 6  | A.Symbols} @!["#$%&'()*+,-./]   | Title 6                                                                                              | Description 4                                                                                                                                                                                                                                                    | OK          |
	| 7  | Author                          | TitleWithNinetyNineCharactersAsASingleWorkTitleWithNinetyNineCharactersAsASingleWorkTitleWithNinety  |                                                                                                                                                                                                                                                                  | OK          |
	| 8  | Author                          | TitleWithNinety Nine Characters Work Title With NinetyNine Characters WorkTitle WithNinetyCharacter  | Description 4                                                                                                                                                                                                                                                    | OK          |
	| 9  | Author                          | Title With a Hundred Characters Title With a Hundred Characters Title With a Hundred Characterssssss |                                                                                                                                                                                                                                                                  | Bad request |
	| 10 | Author                          | Title with {symbols} @!"#$%&'()*+,-./                                                                | Description 4                                                                                                                                                                                                                                                    | OK          |
	| 11 | Author                          | TitleWithTwentyNice                                                                                  | Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description wit  | OK          |
	| 12 | Author                          | TitleWithTwentyNice                                                                                  | Description with 256 letters. Description with 255 letters. Description with 256 letters. Description with 256 letters. Description with 256 letters. Description with 255 letters. Description with 256 letters. Description with 256 letters. Description with | OK          |

Scenario Outline: Delete a book and verify it cannot be accessed
	When I create a new book with parameter: <Id>,<Author>,<Title>,<Description>
	When I delete the created book
	Then a proper <Status> is returned from system
	And I am not able to access it by <id>
Examples: 
	| Id | Author   | Title   | Description   | Status |
	| 13 | Author13 | Title13 | Description13 |        |


Scenario Outline: Update Author, Title and Description of a book
	When I create a new book with parameter: <Id>,<Author>,<Title>,<Description>
	And I update the <Author> of a book with <id>
	Then the new book details are coorect
	And I update the <Title> of a book with <id>
	Then the new book details are coorect
	And I update the <Description> of a book with <id>
	Then the new book details are coorect
Examples: 
	| Id | Author   | Title   | Description   | Status |
	| 14 | Author13 | Title13 | Description13 |        |


Scenario: Get all 
	When I create a 10 books
	| Id | Author   | Title   | Description   |
	| 15 | Author13 | Title13 | Description13 |
	| 15 | Author13 | Title13 | Description13 |
	| 15 | Author13 | Title13 | Description13 |
	| 15 | Author13 | Title13 | Description13 |
	Then I can receive a proper list of books by searching with <tearms>
	And the details of each book
