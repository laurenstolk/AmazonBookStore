using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazonBookStore.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookContext context;

        public EFPurchaseRepository (BookContext temp)
        {
            context = temp;
        }

        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseID == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();
        }

    }
}
