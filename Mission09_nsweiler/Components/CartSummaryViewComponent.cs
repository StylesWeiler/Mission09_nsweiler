using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_nsweiler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mission09_nsweiler.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
