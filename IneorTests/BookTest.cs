using Autofac.Extras.Moq;
using IneorBusiness.Enum;
using IneorBusiness.Infrastructure;
using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using IneorBusiness.Repository;
using IneorBusiness.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace IneorTests
{
    public class BookTest
    {
        [Fact(DisplayName = "Get Books")]
        public void GetBooks()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var data = new List<Book>
                {
                    new Book()
                    {
                    Author = "Test",
                    DatePublished = DateTime.Now.Date,
                    Name = "Test Name",
                    Price = 2
                    }
                };

                var bookRepo = mock.Mock<IBookRepository>();

                bookRepo.Setup(x => x.GetBooks()).Returns(data);

                mock.Provide(bookRepo.Object);

                var component = mock.Create<BookService>();

                var result = component.GetBooks();

                Assert.Single(result);
            }
        }

        [Fact]
        public void InsertBook()
        {
            var sqlConnectionStrings = new Dictionary<DatabaseEnum, string>();
            sqlConnectionStrings.Add(DatabaseEnum.SqlConnection, "Server=DESKTOP-CKLQMTC\\SQLEXPRESS;Database=Ineor;Trusted_Connection=True;MultipleActiveResultSets=true");

            var sqlConnectionDapper = new SqlConnectionDapper(sqlConnectionStrings);

            var data = new Book()
            {
                Author = "Test",
                DatePublished = DateTime.Now.Date,
                Name = "Test Name",
                Price = 2
            };

            var bookRepository = new BookRepository(sqlConnectionDapper);

            var component = new BookService(bookRepository);

            //INSERT
            var result = component.InsertBook(data);

            Assert.True(result);
        }
    }
}
