using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models
{
    public class EFPurchaseRespository : IPurchaseRespository // inheritance
    {
        private BookstoreContext context;
        public EFPurchaseRespository(BookstoreContext temp) // receives the bookstore context
        {
            context = temp;
        }

        // may need to comment this out
        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
