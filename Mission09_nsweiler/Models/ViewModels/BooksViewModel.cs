using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mission09_nsweiler.Models.ViewModels
{
    public class BooksViewModel // Model for the bookView with getters and setters for the Book and PageInfo classes
    {
        public IQueryable<Book> Books { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
