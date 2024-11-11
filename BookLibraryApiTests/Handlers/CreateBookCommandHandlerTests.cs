using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Handlers;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;
using BookLibraryApiTests.Factories;
using FluentValidation;
using BookLibraryAPI.Validators;

namespace BookLibraryApiTests.Handlers
{
    [TestClass]
    public class CreateBookCommandHandlerTests
    {
        private BookRepository _bookRepository;
        private CreateBookCommandHandler _handler;
        private IValidator<CreateBookCommand> _validator = new CreateBookCommandValidator();

        [TestInitialize]
        public void Setup()
        {
            _bookRepository = new BookRepository();
            _handler = new CreateBookCommandHandler(_bookRepository, _validator);
        }

        [TestMethod]
        public async Task Handle_ShouldCreateBookSuccessfully()
        {
            // Arrange
            var book = BookFactory.GenerateBook();
            var command = new CreateBookCommand
            {
                Title = book.Title,
                Author = book.Author,
                PublishedYear = book.PublishedYear
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(command.Title, result.Title);
            Assert.AreEqual(command.Author, result.Author);
            Assert.AreEqual(command.PublishedYear, result.PublishedYear);
            Assert.IsTrue(_bookRepository.GetBooks().Contains(result));
        }

        [TestMethod]
        public async Task Handle_ShouldReturnNullForInvalidData()
        {
            // Arrange
            var book = BookFactory.GenerateBook();
            var command = new CreateBookCommand
            {
                Title = string.Empty, // Invalid title
                Author = book.Author,
                PublishedYear = book.PublishedYear
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
            Assert.IsFalse(_bookRepository.GetBooks().Contains(result));
        }
    }
}
