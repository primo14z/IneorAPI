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
    
    }
}
