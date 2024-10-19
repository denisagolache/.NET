using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            var query = new GetBookByIdQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet ("GetAllBooks")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await mediator.Send(command);
            return NoContent();
        }
    }
}
