using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mission09_nsweiler.Models
{
    public class BookstoreContext : DbContext
    {

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options) // inherits from the base options class
        {
        }

        public DbSet<Book> Books { get; set; } // each DbSet connects the given model to the database and names it whatever we dictate
        public DbSet<Purchase> Purchases { get; set; }

    }
}
