using System;
using System.Linq;

namespace AmazonBookStore.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookContext context { get; set; }

        public EFBookRepository (BookContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

    }
}
