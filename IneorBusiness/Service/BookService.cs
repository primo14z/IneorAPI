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

        public Book GetBookById(int Id)
        {
            var result = _bookRepository.GetBookById(Id);

            return result;
        }

        public bool AddBook(Book data)
        {
            //Data Validation
            if(data.Name == null)
            {
                return false;
            }
            if (data.Author == null)
                return false;

            if (data.DatePublished == null)
                return false;

            if (!data.Price.HasValue)
                return false;

            var result = _bookRepository.AddBook(data);

            if (result == 1)
                return true;
            else
                return false;
        }

        public bool EditBook(Book data)
        {
            //Data Validation
            if (data.Name == null)
            {
                return false;
            }
            if (data.Author == null)
                return false;

            if (data.DatePublished == null)
                return false;

            if (!data.Price.HasValue)
                return false;

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
    }
}
