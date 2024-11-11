using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Handlers;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;
using BookLibraryApiTests.Factories;

namespace BookLibraryApiTests.Handlers
{
    [TestClass]
    public class UpdateBookCommandHandlerTests
    {
        private BookRepository _bookRepository;
        private UpdateBookCommandHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _bookRepository = new BookRepository();
            _handler = new UpdateBookCommandHandler(_bookRepository);
        }

        [TestMethod]
        public async Task Handle_ShouldUpdateBookSuccessfully()
        {
            // Arrange
            var existingBook = BookFactory.GenerateBook();
            _bookRepository.AddBook(existingBook);

            var command = new UpdateBookCommand
            {
                Id = existingBook.Id,
                Title = "Updated Title",
                Author = "Updated Author",
                PublishedYear = 2022
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(command.Title, result.Title);
            Assert.AreEqual(command.Author, result.Author);
            Assert.AreEqual(command.PublishedYear, result.PublishedYear);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnNullForNonExistentBook()
        {
            // Arrange
            var command = new UpdateBookCommand
            {
                Id = 999,
                Title = "Non-existent Title",
                Author = "Non-existent Author",
                PublishedYear = 2022
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
