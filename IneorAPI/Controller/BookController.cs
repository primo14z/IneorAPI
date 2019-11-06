using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using IneorBusiness.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost("GetBookById")]
        public ActionResult<Book> GetBookById([FromBody]int Id)
        {
            var data = _bookService.GetBookById(Id);

            return data;
        }

        [HttpPost("AddBook")]
        public ActionResult<bool> AddBook(Book data)
        {
            var result = _bookService.InsertBook(data);

            return result;
        }

        [HttpPost("EditBook")]
        public ActionResult<bool> EditBook(Book data)
        {
            var result = _bookService.EditBook(data);

            return result;
        }

        [HttpPost("DeleteBook")]
        public ActionResult<bool> DeleteBook([FromBody]int Id)
        {
            var result = _bookService.DeleteBook(Id);

            return result;
        }
    }
}
