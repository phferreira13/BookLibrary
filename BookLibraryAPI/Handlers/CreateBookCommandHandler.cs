using MediatR;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;
using FluentValidation;

namespace BookLibraryAPI.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly BookRepository _bookRepository;
        private readonly IValidator<CreateBookCommand> _validator;

        public CreateBookCommandHandler(BookRepository bookRepository, IValidator<CreateBookCommand> validator)
        {
            _bookRepository = bookRepository;
            _validator = validator;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return null; // ou você pode lançar uma exceção de validação
            }

            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                PublishedYear = request.PublishedYear
            };

            _bookRepository.AddBook(book);

            return book;
        }
    }
}
