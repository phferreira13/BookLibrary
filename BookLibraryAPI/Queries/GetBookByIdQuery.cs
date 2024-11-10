using MediatR;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}
