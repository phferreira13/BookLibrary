using FluentValidation;
using BookLibraryAPI.Commands;

namespace BookLibraryAPI.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(50).WithMessage("Author must not exceed 50 characters.");

            RuleFor(x => x.PublishedYear)
                .InclusiveBetween(1450, DateTime.Now.Year).WithMessage("Published year must be between 1450 and the current year.");
        }
    }
}
