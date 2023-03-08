using Microsoft.AspNetCore.Mvc;
using Mission09_nsweiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public TypesViewComponent (IBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTypes = RouteData?.Values["categoryType"]; // assign the value from the url 

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x); // return the uniqe book types in order


            return View(types); 
        }
    }
}
