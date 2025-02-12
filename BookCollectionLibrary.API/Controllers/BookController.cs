using Asp.Versioning;
using BookCollectionLibrary.API.Business;
using BookCollectionLibrary.API.Data.VO;
using Microsoft.AspNetCore.Mvc;

namespace BookCollectionLibrary.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            var book = _bookService.FindById(id);
            if (book is null)
                return BadRequest();

            return Ok(book);
        }

        [HttpPost()]
        public IActionResult Create(BookVO book)
        {
            if (book is null) return BadRequest();
            return Ok(_bookService.Create(book));
        }

        [HttpPut()]
        public IActionResult Update([FromBody] BookVO book)
        {
            if (book is null) return BadRequest();
            return Ok(_bookService.Update(book));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
