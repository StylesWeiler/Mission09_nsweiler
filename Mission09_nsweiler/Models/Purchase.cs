using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models
{
    public class Purchase
    {
        [Key]
        [BindNever] // Doesn't bind this to the form (doesn't go through the slug)
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter the city name.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the state.")]
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

    }
}
