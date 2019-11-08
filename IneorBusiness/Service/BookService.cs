using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using System;
using System.Collections.Generic;

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
            try
            {
                var result = _bookRepository.GetBookById(Id);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertBook(Book data)
        {
            try
            {
                var result = _bookRepository.InsertBook(data);

                if (result == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditBook(Book data)
        {
            try
            {
                var result = _bookRepository.EditBook(data);

                if (result == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool DeleteBook(int Id)
        {
            try
            {
                var result = _bookRepository.DeleteBook(Id);

                if (result == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<Book> FilterBooks(string key)
        {
            try
            {
                var result = _bookRepository.GetBookByFilter(key);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //TestCoomit
    }
}
