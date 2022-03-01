using System;
using System.Linq;

namespace AmazonBookStore.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchases { get; }

        void SavePurchase(Purchase purchase);

    }
}
