using Microsoft.AspNetCore.Mvc;
using Mission09_nsweiler.Models;
using Mission09_nsweiler.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository repo;

        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            // 10 books per page
            int pageSize = 10;


            // define the Books and PageInfo
            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            // IQueryable type NOT list so change what the model expects to recieve in the Index
            // 10 books are shown per page
            var bookList = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);

            return View(x);
        }
    }
}
