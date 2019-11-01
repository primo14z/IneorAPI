using IneorBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IneorAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpPost("GetBooks")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            List<Book> data = new List<Book>()
            {
                new Book
                {
                    author = "a",
                    date_published = DateTime.Now,
                    id = 1,
                    name = "a",
                    price = 1
                }
            };

            return data;
        }
    
    }
}
