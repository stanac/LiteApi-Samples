using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteApiApiKeySecretSample.Services
{
    /// <summary>
    /// Dummy book model, should have relation to Author and use ISBN for Id
    /// </summary>
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int? PublishYear { get; set; }
    }

    public interface IBookStore
    {
        BookModel GetById(Guid id);
        IEnumerable<BookModel> GetAll();
    }

    /// <summary>
    /// Dummy implementation of book store, should be implemented using DB.
    /// </summary>
    public class DummyBookStore : IBookStore
    {
        private readonly BookModel[] _books;

        public DummyBookStore()
        {
            _books = new [] {
                new BookModel
                {
                    Id = Guid.Parse("c3b0c912-31c7-4fea-a95e-a5c6eee2757f"),
                    Title = "Foundation",
                    Author = "Isaac Asimov",
                    PublishYear = 1951
                },
                new BookModel
                {
                    Id = Guid.Parse("8a998de3-436a-4f16-b228-d9944066cde1"),
                    Title = "Solaris",
                    Author = "Stanislaw Lem",
                    PublishYear = 1961
                },
                new BookModel
                {
                    Id = Guid.Parse("d3e47929-2e7e-4adb-8142-f85ea72818b6"),
                    Title = "Childhood's End",
                    Author = "Arthur C. Clarke",
                    PublishYear = 1953
                }
            };
        }

        public IEnumerable<BookModel> GetAll() => _books;

        public BookModel GetById(Guid id) => _books.FirstOrDefault(x => x.Id == id);
    }
}
