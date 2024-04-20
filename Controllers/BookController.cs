using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddUpdateBook bookObj)
        {
            if (!ValidateBook(bookObj))
            {
                return BadRequest();
            }
          
            var book = _bookService.AddBook(bookObj);

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
        public IActionResult Put([FromRoute]int id, [FromBody] AddUpdateBook bookObj)
        {

            if (!ValidateBook(bookObj))
            {
                return BadRequest();
            }

            var book = _bookService.UpdateBook(id, bookObj);

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
        public IActionResult Delete([FromRoute] int id)
        {
            var book = _bookService.DeleteBookById(id);

            if (book == null)
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
