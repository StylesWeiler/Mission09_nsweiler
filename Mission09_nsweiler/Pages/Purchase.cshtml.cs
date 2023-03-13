using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_nsweiler.Infrastructure;
using Mission09_nsweiler.Models;

namespace Mission09_nsweiler.Pages
{
    public class PurchaseModel : PageModel
    {

        private IBookRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public PurchaseModel (IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b; // assigning the basket variable with the incoming basket 
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

             // ?? is the null-coalescing operator. Returns the left side if it's null, otherwise it returns the right side
            basket.AddItem(b, 1, b.Price);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book); // search for the first Item with a matching bookId and then grab the associated Book

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
