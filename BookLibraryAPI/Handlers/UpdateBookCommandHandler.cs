using MediatR;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;

namespace BookLibraryAPI.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly BookRepository _bookRepository;

        public UpdateBookCommandHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author,
                PublishedYear = request.PublishedYear
            };

            _bookRepository.UpdateBook(book);

            return Task.FromResult(book);
        }
    }
}
