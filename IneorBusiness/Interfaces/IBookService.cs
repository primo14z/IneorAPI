using IneorBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IneorBusiness.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        bool AddBook(Book data);
        bool EditBook(Book data);
        bool DeleteBook(int data);
        Book GetBookById(int Id);
    }
}
