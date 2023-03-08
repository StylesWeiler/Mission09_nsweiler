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

        public PurchaseModel (IBookRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);


            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket(); // ?? is the null-coalescing operator. Returns the left side if it's null, otherwise it returns the right side
            basket.AddItem(b, 1, b.Price);

            HttpContext.Session.setJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
