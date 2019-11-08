using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IneorAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet("GetBooks")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var data = _bookService.GetBooks();

            return data;
        }

        [HttpPost("FilterBooks")]
        public ActionResult<IEnumerable<Book>> FilterBooks(FilterModel filter)
        {
            try
            {
                var data = _bookService.FilterBooks(filter);

                return data;
            }
           catch
            {
                return BadRequest();
            }
        }

        [HttpPost("GetBookById")]
        public ActionResult<Book> GetBookById([FromBody]int Id)
        {
            try
            {
                var data = _bookService.GetBookById(Id);

                return data;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddBook")]
        public ActionResult<bool> AddBook(Book data)
        {
            try
            {
                var result = _bookService.InsertBook(data);

                return result;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("EditBook")]
        public ActionResult<bool> EditBook(Book data)
        {
            try
            {
                var result = _bookService.EditBook(data);

                return result;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("DeleteBook")]
        public ActionResult<bool> DeleteBook([FromBody]int Id)
        {
            try
            {
                var result = _bookService.DeleteBook(Id);

                return result;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("GetBookByFilter")]
        public ActionResult<List<Book>> GetBookByFilter(FilterModel data)
        {
            try
            {
                var result = _bookService.GetBookByFilter(data.key);

                return result;
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
