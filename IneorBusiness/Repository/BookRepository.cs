using Dapper;
using IneorBusiness.Infrastructure;
using IneorBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IneorBusiness.Repository
{
    public class BookRepository
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

    }
}
