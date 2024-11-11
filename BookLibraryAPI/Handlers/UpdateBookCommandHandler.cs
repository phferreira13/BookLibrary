using MediatR;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;
using FluentValidation;

namespace BookLibraryAPI.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly BookRepository _bookRepository;
        private readonly IValidator<UpdateBookCommand> _validator;

        public UpdateBookCommandHandler(BookRepository bookRepository, IValidator<UpdateBookCommand> validator)
        {
            _bookRepository = bookRepository;
            _validator = validator;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return null;
            }

            var book = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author,
                PublishedYear = request.PublishedYear
            };            

            return _bookRepository.UpdateBook(book);
        }
    }
}
