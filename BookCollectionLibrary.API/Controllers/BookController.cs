using Asp.Versioning;
using BookCollectionLibrary.API.Business;
using BookCollectionLibrary.API.Data.VO;
using BookCollectionLibrary.API.Hypermedia.Filters;
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAll()
        {
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id:long}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(long id)
        {
            var book = _bookService.FindById(id);
            if (book is null)
                return BadRequest();

            return Ok(book);
        }

        [HttpPost()]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create(BookVO book)
        {
            if (book is null) return BadRequest();
            return Ok(_bookService.Create(book));
        }

        [HttpPut()]
        [TypeFilter(typeof(HyperMediaFilter))]
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
