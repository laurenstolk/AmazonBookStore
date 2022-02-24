using System;
using System.Linq;
using AmazonBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonBookStore.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public CategoryViewComponent (IBookRepository temp)
        {
            repo = temp;
        }

        //Components to get all the categories and send them to the view
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
