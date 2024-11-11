using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories
{
    public class BookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
        }

        public Book UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublishedYear = book.PublishedYear;
            }
            return existingBook;
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
