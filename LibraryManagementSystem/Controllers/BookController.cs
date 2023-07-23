using Library.API.Services;
using LibraryManagementSystem.API.Entities;
using LibraryManagementSystem.DataLayer.Abstractions;
using LibraryManagementSystem.DataLayer.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger     ;
        private readonly IBookService _bookContext;
        public BookController(ILogger<BookController> logger, IBookService bookRepository)
        {
            this.logger = logger    ;
            _bookContext  = bookRepository;
        }

        [HttpPost(Name = "CreateBook")]
        public   IActionResult Post([FromBody] Book book)
        {

            if (ModelState.IsValid)
            {
                Book? createdBook =  _bookContext.AddBook(book).Result;
                return CreatedAtAction("Get", new { id = createdBook?.Id }, createdBook);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}",Name = "GetBookById")]
        public IActionResult Get(Guid id)
        {
            Book? book = _bookContext.GetBook(id).Result;

            if(book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpGet(Name = "GetAllBooks")]
        public IActionResult GetAll()
        {
            IEnumerable<Book>? x = _bookContext.GetBooks().Result;
            return Ok(x);
        }

        [HttpDelete("{id}",Name = "DeleteBook")]
        public IActionResult Delete(Guid id)
        {
            if(_bookContext.GetBook(id).Result != null)
            {
                 _bookContext.RemoveBook(id);
                return Ok();
            }

            return NotFound();
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public IActionResult Update(Guid id, [FromBody] Book book)
        {
            Book? selectedBook = _bookContext.GetBook(id).Result;

            if (selectedBook != null && ModelState.IsValid)
            {
                Book? updatedBook = _bookContext.UpdateBook(id,book).Result;
                return Ok(updatedBook);
            }

            return NotFound();
        }
    }
}
