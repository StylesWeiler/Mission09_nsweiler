using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models
{
    // interface is a template for a class
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
