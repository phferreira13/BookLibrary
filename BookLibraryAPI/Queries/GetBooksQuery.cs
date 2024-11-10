using MediatR;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Queries
{
    public class GetBooksQuery : IRequest<List<Book>>
    {
    }
}
