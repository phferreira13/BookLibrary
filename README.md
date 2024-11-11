# BookLibrary

## Setup Instructions

### Dependencies

- .NET 8.0 SDK
- MediatR 12.4.1
- FluentValidation 11.10.0
- Swashbuckle.AspNetCore 6.9.0

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/phferreira13/BookLibrary.git
   cd BookLibrary
   ```

2. Restore the dependencies:
   ```sh
   dotnet restore
   ```

3. Build the project:
   ```sh
   dotnet build
   ```

4. Run the application:
   ```sh
   dotnet run --project BookLibraryAPI
   ```

## Usage Instructions

### API Endpoints

- `GET /books` - Retrieves a list of all books.
- `GET /books/{id}` - Retrieves a specific book by ID.
- `POST /books` - Creates a new book.
- `PUT /books/{id}` - Updates an existing book.
- `DELETE /books/{id}` - Deletes a book.

### Example Requests and Responses

#### Get all books

```sh
curl -X GET "http://localhost:5279/books" -H "accept: application/json"
```

Response:
```json
[
  {
    "id": 1,
    "title": "Book Title",
    "author": "Author Name",
    "publishedYear": 2021
  }
]
```

#### Get a book by ID

```sh
curl -X GET "http://localhost:5279/books/1" -H "accept: application/json"
```

Response:
```json
{
  "id": 1,
  "title": "Book Title",
  "author": "Author Name",
  "publishedYear": 2021
}
```

#### Create a new book

```sh
curl -X POST "http://localhost:5279/books" -H "accept: application/json" -H "Content-Type: application/json" -d "{\"title\":\"New Book\",\"author\":\"New Author\",\"publishedYear\":2022}"
```

Response:
```json
{
  "id": 2,
  "title": "New Book",
  "author": "New Author",
  "publishedYear": 2022
}
```

#### Update a book

```sh
curl -X PUT "http://localhost:5279/books/1" -H "accept: application/json" -H "Content-Type: application/json" -d "{\"id\":1,\"title\":\"Updated Book\",\"author\":\"Updated Author\",\"publishedYear\":2023}"
```

Response:
```sh
HTTP/1.1 204 No Content
```

#### Delete a book

```sh
curl -X DELETE "http://localhost:5279/books/1" -H "accept: application/json"
```

Response:
```sh
HTTP/1.1 204 No Content
```

## Functionality

The BookLibrary API allows you to manage a collection of books. You can perform the following operations:

- Retrieve a list of all books.
- Retrieve a specific book by ID.
- Create a new book.
- Update an existing book.
- Delete a book.

## Contributing

If you would like to contribute to this project, please follow these guidelines:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Make your changes.
4. Submit a pull request with a detailed description of your changes.
