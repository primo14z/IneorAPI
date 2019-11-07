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
            var query = @"Select * FROM Book";

            var result = _db.Query<Book>(query).ToList();

            return result;
        }

        public List<Book> FilterBooks(FilterModel filter)
        {
            var query = @"Select TOP(@pageSize) *
                            From 
                            (
                                Select 
                                  Row_Number() Over (Order By Id) As RowNum
                                , *
                                From Book
                            ) t2
                            Where RowNum BETWEEN @From AND @To";

            var result = _db.Query<Book>(query, new
            {
                From = filter.pageIndex * filter.pageSize,
                To = (filter.pageIndex + 1 ) * filter.pageSize,
                pageSize = filter.pageSize
            }).ToList();

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

        public List<Book> GetBookByFilter(string key)
        {
            var query = @"SELECT * from Book
                            WHERE Name like CONCAT('%',@key,'%')
                                OR Author like CONCAT('%',@key,'%')";

            var result = _db.Query<Book>(query, new
            {
                key = key
            }).ToList();

            return result;
        }
    }
}
