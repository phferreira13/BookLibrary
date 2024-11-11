using BookLibraryAPI.Handlers;
using BookLibraryAPI.Models;
using BookLibraryAPI.Queries;
using BookLibraryAPI.Repositories;
using BookLibraryApiTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibraryApiTests.Handlers
{
    [TestClass]
    public class GetBooksQueryHandlerTests
    {
        private BookRepository _bookRepository;
        private GetBooksQueryHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _bookRepository = new BookRepository();
            _handler = new GetBooksQueryHandler(_bookRepository);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnListOfBooks()
        {
            // Arrange
            var books = BookFactory.GenerateBooks(5);
            foreach (var book in books)
            {
                _bookRepository.AddBook(book);
            }

            var query = new GetBooksQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(5, result.Count);
            CollectionAssert.AreEqual(books, result);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnEmptyListWhenNoBooks()
        {
            // Arrange
            var query = new GetBooksQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
