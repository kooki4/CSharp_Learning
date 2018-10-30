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

# Not fully implemented the second call returns an error  !!!
Scenario Outline: Create the same book
	When I create a new book with parameter: <Id>,<Author>,<Title>,<Description>
	Then system return a proper already exists <Status>
Examples: 
	| Id | Author | Title | Description | Status                                    |
	| 13 | Author | Test  | Description | OK                                        |
	| 14 | Author | Test  | Description | "Message:Book with id 14 already exists!" |

Scenario Outline: Remove a book and check the books left into the library
	When I delete a book with <id>
	Then a proper <Status> is returned from system
	#And correct library book details are returned
Examples: 
	| id | Status    |
	| 1  | Completed |



Scenario: Remove already deleted book

Scenario: Update the details of a book
	When  I update a book with <id> with <Authro>
	Then the book is correctly book updated
	When I update the <

Scenario: Get all books
	Given I request all books from the librabry
	Then I receive a full list of books 
	And the details of each book


Scenario: Get a book details
	Given  I request a the details of a single book from the library
	Then I receive the

