using MediatR;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
    }
}
