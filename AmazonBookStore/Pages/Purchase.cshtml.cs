using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonBookStore.Infrastructure;
using AmazonBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonBookStore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public PurchaseModel (IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookID, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == bookID);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }


        public IActionResult OnPostRemove(int bookID, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookID == bookID).Book);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }

    }
}
