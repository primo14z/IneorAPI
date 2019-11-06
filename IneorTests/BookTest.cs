using Autofac.Extras.Moq;
using IneorBusiness.Infrastructure;
using IneorBusiness.Interfaces;
using IneorBusiness.Models;
using IneorBusiness.Repository;
using IneorBusiness.Service;
using Moq;
using System;
using Xunit;

namespace IneorTests
{
    public class BookTest
    {
        private readonly IBookRepository _bookRepository;

        [Fact(DisplayName = "Insert Book")]
        public void InsertBook()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //mock.Provide<BookRepository>(_bookRepository);
                var component = mock.Create<BookService>();

                var data = new Book
                {
                    Author = "Test",
                    DatePublished = DateTime.Now.Date,
                    Name = "Test Name",
                    Price = 2
                };

                var result = component.InsertBook(data);

                Assert.True(result);
            }
        }
    }
}
