using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using IneorBusiness.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IneorBusiness.Service
{
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public List<Book> GetBooks()
        {
            var result = _bookRepository.GetBooks();

            return result;
        }

        public Book GetBookById(int Id)
        {
            var result = _bookRepository.GetBookById(Id);

            return result;
        }

        public bool InsertBook(Book data)
        {
            var result = _bookRepository.InsertBook(data);

            if (result == 1)
                return true;
            else
                return false;
        }

        public bool EditBook(Book data)
        {
            var result = _bookRepository.EditBook(data);

            if (result == 1)
                return true;
            else
                return false;
        }
        public bool DeleteBook(int Id)
        {
            var result = _bookRepository.DeleteBook(Id);

            if (result == 1)
                return true;
            else
                return false;
        }
        
        public List<Book> GetBookByFilter(string key)
        {
            var result = _bookRepository.GetBookByFilter(key);

            return result;
        }

        //TestCoomit
    }
}
