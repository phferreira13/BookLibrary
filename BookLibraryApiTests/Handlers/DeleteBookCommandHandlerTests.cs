using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Handlers;
using BookLibraryAPI.Repositories;
using BookLibraryApiTests.Factories;

namespace BookLibraryApiTests.Handlers
{
    [TestClass]
    public class DeleteBookCommandHandlerTests
    {
        private BookRepository _bookRepository;
        private DeleteBookCommandHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _bookRepository = new BookRepository();
            _handler = new DeleteBookCommandHandler(_bookRepository);
        }

        [TestMethod]
        public async Task Handle_ShouldDeleteBookSuccessfully()
        {
            // Arrange
            var book = BookFactory.GenerateBook();
            _bookRepository.AddBook(book);

            var command = new DeleteBookCommand { Id = book.Id };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(_bookRepository.GetBookById(book.Id));
        }

        [TestMethod]
        public async Task Handle_ShouldReturnFalseForNonExistentBook()
        {
            // Arrange
            var bookId = 999; // Non-existent book ID

            var command = new DeleteBookCommand { Id = bookId };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
