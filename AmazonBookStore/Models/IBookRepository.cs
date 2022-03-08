using System;
using System.Linq;

namespace AmazonBookStore.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book b);

        public void CreateBook(Book b);

        public void DeleteBook(Book b);

    }
}
