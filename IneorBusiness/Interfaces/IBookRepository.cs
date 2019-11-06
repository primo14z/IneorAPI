using IneorBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IneorBusiness.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int Id);
        int InsertBook(Book data);
        int EditBook(Book data);
        int DeleteBook(int Id);
    }
}
