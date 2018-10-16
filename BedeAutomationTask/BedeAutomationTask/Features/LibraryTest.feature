Feature: Project Library Manager
      In order to perform CRUD operations on the library
      As a Library Manager
      I want to be able to Add, Update, Delete, and View Library content

Scenario Outline: Add new book to the library and verify status.
	Given I add a new book with <Id>, <Title>, <Description> and <Author>
	Then positive <Status> is returned

Examples:
	| Id | Title          | Description        | Author   | Status |
	| 1  | Test1          | Description 1      | A.1      | 200    |
	| 2  | Test2          | Desciption's bla 2 | Author 2 | 200    |
	| 3  | Title3         | Desciprtion aha 3  | Author 3 | 200    |
	| 4  | Title4Author 1 | Description 4      | Author 4 | 200    |
