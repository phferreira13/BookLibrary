using MediatR;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;

namespace BookLibraryAPI.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly BookRepository _bookRepository;

        public CreateBookCommandHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                PublishedYear = request.PublishedYear
            };

            _bookRepository.AddBook(book);

            return Task.FromResult(book);
        }
    }
}
