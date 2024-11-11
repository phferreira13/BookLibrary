using MediatR;
using BookLibraryAPI.Models;
using BookLibraryAPI.Queries;
using BookLibraryAPI.Repositories;

namespace BookLibraryAPI.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly BookRepository _bookRepository;

        public GetBookByIdQueryHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = _bookRepository.GetBookById(request.Id);
            return Task.FromResult(book);
        }
    }
}
