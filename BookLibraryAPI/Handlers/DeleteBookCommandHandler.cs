using MediatR;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Repositories;

namespace BookLibraryAPI.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly BookRepository _bookRepository;

        public DeleteBookCommandHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _bookRepository.GetBookById(request.Id);
            if (book == null)
            {
                return Task.FromResult(false);
            }

            _bookRepository.DeleteBook(request.Id);
            return Task.FromResult(true);
        }
    }
}
