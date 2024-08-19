using Library.Infrastructure.Commands;
using Library.Infrastructure.Queries;
using Library.Shared;
using Microsoft.AspNetCore.Mvc;


namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly GetAllBooksQueryHandler _getAllBooksHandler;
        private readonly GetBookIdQueryHandler _getBookIdHandler;
        private readonly AddBookCommandHandler _addBookHandler;
        private readonly DeleteBookCommandHandler _deleteBookHandler;


        public BooksController(GetAllBooksQueryHandler getAllBooksHandler, 
                                AddBookCommandHandler addBookHandler,
                                GetBookIdQueryHandler getBookIdHandler,
                                DeleteBookCommandHandler deleteBookHandler)
        {
            _getAllBooksHandler = getAllBooksHandler;
            _getBookIdHandler = getBookIdHandler;
            _addBookHandler = addBookHandler;
            _deleteBookHandler = deleteBookHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _getAllBooksHandler.Handle();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBookCommand command)
        {
            await _addBookHandler.Handle(command);
            return Ok();
        }
                
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteBook(int id)
        {
            try
            {
                Book book = await _getBookIdHandler.Handle(id);

                if (book == null)
                {
                    return NotFound();
                }

                await _deleteBookHandler.Handle(book);

                return Ok("Excluído com Sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Erro na Exclusão");
            }
        }  

    }
}
