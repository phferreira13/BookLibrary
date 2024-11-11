using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Models;
using MediatR;
using BookLibraryAPI.Commands;

namespace BookLibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var query = new GetBooksQuery();
            var books = await _mediator.Send(query);
            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var query = new GetBookByIdQuery { Id = id };
            var book = await _mediator.Send(query);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(CreateBookCommand command)
        {
            var book = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var book = await _mediator.Send(command);

            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
