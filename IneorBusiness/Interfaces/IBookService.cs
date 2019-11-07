using IneorBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IneorBusiness.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        List<Book> FilterBooks(FilterModel filter);
        bool InsertBook(Book data);
        bool EditBook(Book data);
        bool DeleteBook(int data);
        Book GetBookById(int Id);
        List<Book> GetBookByFilter(string key);
    }
}
