Feature: Project Library Manager
      In order to perform CRUD operations on the library
      As a Library Manager
      I want to be able to Create, Update, Delete, and List library content

  Scenario: Add a new book to the library and verify it.
      Given the following book data
          | Field       | Value            |
          | id          | 1                |
          | Title       | Test             |
          | Description | Test Description |
          | Author      | Test Author 1    |
      When the library manager posts the book data to the website
      Then a positive status should be returned
      When the library manager gets the project by id
      Then the saved book data matches the posted one