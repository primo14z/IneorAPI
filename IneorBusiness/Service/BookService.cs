using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using IneorBusiness.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IneorBusiness.Service
{
    public class BookService : IBookService
    {
        readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public List<Book> GetBooks()
        {
            var result = _bookRepository.GetBooks();

            return result;
        }
    }
}
