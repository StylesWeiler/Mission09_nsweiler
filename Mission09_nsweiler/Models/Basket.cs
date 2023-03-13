using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>(); // declare and instantiate in one line
    
        public virtual void AddItem (Book book, int qty, double price) // virtual allows this method to be overridden when we inherit from it
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty,
                    Price = price
                });
            }
            else
            {
                line.Quantity += qty; 
            }
        }

        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);


        }

        public virtual void ClearBasket()
        {
            Items.Clear();


        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);

            return sum;
        }

    }

    public class BasketLineItem
    {
        [Key] // establish a key for the Purchases table to be migrated to the DB
        public int LineID { get; set; }
        public Book Book { get; set; } //instance of Book class
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
