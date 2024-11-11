using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Controllers;
using BookLibraryAPI.Models;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryAPI.Tests
{
    public class BooksControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<BookRepository> _bookRepositoryMock;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _bookRepositoryMock = new Mock<BookRepository>();
            _controller = new BooksController(_mediatorMock.Object, _bookRepositoryMock.Object);
        }

        [Fact]
        public void GetBooks_ReturnsListOfBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", PublishedYear = 2000 },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", PublishedYear = 2005 }
            };
            _bookRepositoryMock.Setup(repo => repo.GetBooks()).Returns(books);

            // Act
            var result = _controller.GetBooks();

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public void GetBookById_ReturnsBook()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Book 1", Author = "Author 1", PublishedYear = 2000 };
            _bookRepositoryMock.Setup(repo => repo.GetBookById(1)).Returns(book);

            // Act
            var result = _controller.GetBookById(1);

            // Assert
            Assert.IsType<ActionResult<Book>>(result);
            Assert.Equal(book, result.Value);
        }

        [Fact]
        public async Task PostBook_AddsBook()
        {
            // Arrange
            var command = new CreateBookCommand { Title = "Book 1", Author = "Author 1", PublishedYear = 2000 };
            var book = new Book { Id = 1, Title = "Book 1", Author = "Author 1", PublishedYear = 2000 };
            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(book);

            // Act
            var result = await _controller.PostBook(command);

            // Assert
            Assert.IsType<ActionResult<Book>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(book, createdAtActionResult.Value);
        }

        [Fact]
        public async Task PutBook_UpdatesBook()
        {
            // Arrange
            var command = new UpdateBookCommand { Id = 1, Title = "Updated Book", Author = "Updated Author", PublishedYear = 2020 };
            var book = new Book { Id = 1, Title = "Updated Book", Author = "Updated Author", PublishedYear = 2020 };
            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(book);

            // Act
            var result = await _controller.PutBook(1, command);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteBook_RemovesBook()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Book 1", Author = "Author 1", PublishedYear = 2000 };
            _bookRepositoryMock.Setup(repo => repo.GetBookById(1)).Returns(book);

            // Act
            var result = _controller.DeleteBook(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
