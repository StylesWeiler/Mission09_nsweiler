using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models
{
    public interface IPurchaseRespository
    {
        IQueryable<Purchase> Purchases { get; } // only get because we just want to access what's in Purchases

        void SavePurchase(Purchase purchase);


    }
}
