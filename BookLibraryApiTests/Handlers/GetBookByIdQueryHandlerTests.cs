using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using BookLibraryAPI.Handlers;
using BookLibraryAPI.Models;
using BookLibraryAPI.Queries;
using BookLibraryAPI.Repositories;
using BookLibraryApiTests.Factories;

namespace BookLibraryApiTests.Handlers
{
    [TestClass]
    public class GetBookByIdQueryHandlerTests
    {
        private BookRepository _bookRepository;
        private GetBookByIdQueryHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _bookRepository = new BookRepository();
            _handler = new GetBookByIdQueryHandler(_bookRepository);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            var book = BookFactory.GenerateBook();
            _bookRepository.AddBook(book);

            var query = new GetBookByIdQuery { Id = book.Id };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(book.Id, result.Id);
            Assert.AreEqual(book.Title, result.Title);
            Assert.AreEqual(book.Author, result.Author);
            Assert.AreEqual(book.PublishedYear, result.PublishedYear);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Arrange
            var query = new GetBookByIdQuery { Id = 999 };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
