Feature: BedeAPITests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Create a new books
	Given I create a new book with parameter: <Id>,<Author>,<Title>,<Description>
	Then a proper add <Status> and book details are correct

Examples:
	| Id | Author                          | Title               | Description   | Status |
	| 1  | AuthorWithTwentyNineLettersss   | Test                | Test          | 200    |
	| 2  | AuthorWithThirtyLetterssssssss  | Test                | Test          | 200    |
	| 3  | AuthorWithThirtyOneLetterssssss | Title               | Test          | 400    |
	| 4  | Author with blank spaces        | Title4Author 1      | Test          | 200    |
	| 5  | Author .H Banks                 | Title4Author 1      | Test          | 200    |
	| 6  | AuthorWithSymbols%&^*!@#$       | Title4Author 1      | Description 4 | 200    |
	| 7  | Author                          | TitleWithTwentyNice |               |        |


Scenario: Delete book from library
	Given I delete a book with <id>
	#Then a proper delete <Status> is returned