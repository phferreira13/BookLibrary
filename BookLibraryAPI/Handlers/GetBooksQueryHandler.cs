using MediatR;
using BookLibraryAPI.Models;
using BookLibraryAPI.Queries;
using BookLibraryAPI.Repositories;

namespace BookLibraryAPI.Handlers
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Book>>
    {
        private readonly BookRepository _bookRepository;

        public GetBooksQueryHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.GetBooks().ToList();
            return Task.FromResult(books);
        }
    }
}
