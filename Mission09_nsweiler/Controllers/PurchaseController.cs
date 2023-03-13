using Microsoft.AspNetCore.Mvc;
using Mission09_nsweiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Controllers
{
    public class PurchaseController : Controller // inherits from the main Controller
    {

        private IPurchaseRespository repo { get; set; } // variable declarations for the repo and basket that are set in the method below
        private Basket basket { get; set; }

        public PurchaseController(IPurchaseRespository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout() // get method for the checkout that returns the purchase view
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase) // post method for the checkout that checks the number of items in the cart is greater than zero before saving the purchases
        {
            if(basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty.");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else 
            {
                return View();
            }

        }
    }
}
