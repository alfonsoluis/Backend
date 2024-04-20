using Backend.Helpers;  
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateBook bookObj)
        {
            if (!ValidateBook(bookObj))
            {
                return BadRequest();
            }
          
            var book = await _bookService.AddBook(bookObj);

            if (book == null)
            {
                return BadRequest();
            }

            return Ok(new { 
                message = "Book added successfully",
                id = book.Id
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] AddUpdateBook bookObj)
        {

            if (!ValidateBook(bookObj))
            {
                return BadRequest();
            }

            var book = await _bookService.UpdateBook(id, bookObj);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Book updated successfully",
                id = book!.Id
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            

            if (!await _bookService.DeleteBookById(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Book deleted successfully",
                id = id
            });
        }

        
        private bool ValidateBook(AddUpdateBook bookObj)
        {
            if (string.IsNullOrEmpty(bookObj.Title) || string.IsNullOrEmpty(bookObj.Author) || string.IsNullOrEmpty(bookObj.Genre))
            {
                return false;
            }
            return true;
        }
        
    }
}
