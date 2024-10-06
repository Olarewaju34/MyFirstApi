using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Model;
using MyFirstApi.Repository;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController(IBookRepository _bookRepository) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllbooksAsync();
            if (books.Count == 0)
            {
                return BadRequest();
            }
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var id = await _bookRepository.AddAsync(bookModel);

            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "books" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id,[FromBody] BookModel bookModel)
        {
             await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok();
           
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int id, [FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument bookModel)
        {
             await _bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok();
           
        }
    }
}
