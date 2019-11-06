using Dapper;
using IneorBusiness.Infrastructure;
using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IneorBusiness.Repository
{
    public class BookRepository : IBookRepository
    {
        readonly IDbConnection _db;
        public BookRepository(SqlConnectionDapper db)
        {
            this._db = db.SQLConnection();
        }

        public List<Book> GetBooks()
        {
            var query = @"Select * from Book";

            var result = _db.Query<Book>(query).ToList();

            return result;
        }

        public Book GetBookById(int Id)
        {
            var query = @"Select * from Book
                        WHERE Id = @Id";

            var result = _db.Query<Book>(query, new
            {
                Id = Id
            }).SingleOrDefault();

            return result;
        }

        public int InsertBook(Book data)
        {
            var query = @"INSERT INTO Book
                        (Author, Price, DatePublished,Name)
                    VALUES (@Author, @Price, @DatePublished, @Name)";

            var result = _db.Execute(query, new
            {
                Author = data.Author,
                Price = data.Price,
                DatePublished = data.DatePublished,
                Name = data.Name
            });

            return result;
        }

        public int EditBook(Book data)
        {
            var query = @"UPDATE Book
                        SET Name = @Name, Price = @Price, Author = @Author, DatePublished = @DatePublished
                        WHERE Id = @Id";

            var result = _db.Execute(query, new
            {
                Author = data.Author,
                Price = data.Price,
                DatePublished = data.DatePublished,
                Name = data.Name,
                Id = data.Id
            });

            return result;
        }

        public int DeleteBook(int Id)
        {
            var query = @"DELETE from Book
                            WHERE Id = @Id";

            var result = _db.Execute(query, new
            {
                Id = Id
            });

            return result;
        }
    }
}
