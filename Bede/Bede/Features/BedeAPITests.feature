﻿Feature: BedeAPITests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Create a new books
	Given I create a new book with parameter: <Id>,<Author>,<Title>,<Description>
	Then a proper add <Status> and correct book details are returned

Examples:
	| Id | Author                          | Title                                                                                                | Description                                                                                                                                                                                                                                                      | Status      |
	| 1  | AuthorWithTwentyNineLettersss   | Title 1                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 2  | AuthorWithThirtyLetterssssssss  | Title 2                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 3  | AuthorWithThirtyOneLetterssssss | Title 3                                                                                              | Test                                                                                                                                                                                                                                                             | Bad request |
	| 4  | Author with blank spaces        | Title 4                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 5  | Author .H Banks                 | Title 5                                                                                              | Test                                                                                                                                                                                                                                                             | OK          |
	| 6  | A.Symbols} @!["#$%&'()*+,-./]   | Title 6                                                                                              | Description 4                                                                                                                                                                                                                                                    | OK          |
	| 7  | Author                          | TitleWithNinetyNineCharactersAsASingleWorkTitleWithNinetyNineCharactersAsASingleWorkTitleWithNinety  |                                                                                                                                                                                                                                                                  | OK          |
	| 8  | Author                          | TitleWithNinety Nine Characters Work Title With NinetyNine Characters WorkTitle WithNinetyCharacter  | Description 4                                                                                                                                                                                                                                                    | OK          |
	| 9  | Author                          | Title With a Hundred Characters Title With a Hundred Characters Title With a Hundred Characterssssss |                                                                                                                                                                                                                                                                  | Bad request |
	| 10 | Author                          | Title with {symbols} @!"#$%&'()*+,-./                                                                | Description 4                                                                                                                                                                                                                                                    | OK          |
	| 11 | Author                          | TitleWithTwentyNice                                                                                  | Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description with 255 letters. Description wit  | OK          |
	| 12 | Author                          | TitleWithTwentyNice                                                                                  | Description with 256 letters. Description with 255 letters. Description with 256 letters. Description with 256 letters. Description with 256 letters. Description with 255 letters. Description with 256 letters. Description with 256 letters. Description with | OK          |

Scenario: Delete book from library
	Given I delete a book with <id>
	#Then a proper delete <Status> is returned