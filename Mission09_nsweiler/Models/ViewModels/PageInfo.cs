using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models.ViewModels
{
    public class PageInfo // define the PageInfo class and it's attributes (wth getters and setters for each)
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage); // figure out how many pages we need (cast to double to calculate number of pages before making that an int that's the ceiling value)
    }
}
