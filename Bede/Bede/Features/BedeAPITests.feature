Feature: BedeAPITests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Create books to the library
	Given I create a new book with parameters: <Id>, <Author>, <Title> and <Description>
    And ModelState is correct
	Then a positive <Status> is returned

Examples:
	| Id | Author   |  Title          | Description        | Status |
	| 1  | A.1      |  Test1          | Description 1      | 200    |
	| 2  | Author 2 |  Test2          | Desciption's bla 2 | 200    |
	| 3  | Author 3 |  Title3         | Desciprtion aha 3  | 200    |
	| 4  | Author 4 |  Title4Author 1 | Description 4      | 200    |