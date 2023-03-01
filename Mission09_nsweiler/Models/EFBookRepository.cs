using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models
{
    public class EFBookRepository : IBookRepository
    {
        // previously done in the Home controller
        private BookstoreContext context { get; set; }
        public EFBookRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
