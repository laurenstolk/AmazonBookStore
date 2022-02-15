using System;
using System.Linq;

namespace AmazonBookStore.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

    }
}
