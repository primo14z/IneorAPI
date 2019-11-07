using IneorBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IneorBusiness.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        bool InsertBook(Book data);
        bool EditBook(Book data);
        bool DeleteBook(int data);
        Book GetBookById(int Id);
        List<Book> GetBookByFilter(string key);
    }
}
