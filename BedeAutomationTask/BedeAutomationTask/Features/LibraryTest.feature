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



	  Hint for endpoint class:
	  Folder TestData


namespace Experian.Qas.Updates.Metadata.WebApi.TestData
{
  public static class Endpoints
  {
    public const string FileDownloadEndPointV1 = @"/metadata/V1/filedownload";
    public const string PackagesEndPointV1 = @"/metadata/V1/packages";

    public const string FileDownloadEndPointV2 = @"/metadata/V2/filelink";
    public const string PackagesEndPointV2 = @"/metadata/V2/packages";
    public const string TokenV2 = @"/metadata/V2/token";
  }
}