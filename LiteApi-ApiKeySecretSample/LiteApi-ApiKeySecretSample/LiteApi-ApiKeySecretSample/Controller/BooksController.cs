using LiteApi;
using LiteApi.Attributes;
using LiteApiApiKeySecretSample.Services;
using System;
using System.Collections.Generic;

namespace LiteApiApiKeySecretSample.Controller
{
    [Restful, RequiresKeySecret]
    public class BooksController: LiteController
    {
        private readonly IBookStore _bookStore;

        public BooksController(IBookStore bookStore)
        {
            _bookStore = bookStore ?? throw new ArgumentNullException(nameof(bookStore));
        }

        [ActionRoute("/{id}")]
        public BookModel GetById(Guid id) => _bookStore.GetById(id);
        
        public IEnumerable<BookModel> All() => _bookStore.GetAll();
    }
}
