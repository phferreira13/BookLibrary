using MediatR;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
    }
}
