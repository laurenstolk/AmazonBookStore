using System;
using AmazonBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonBookStore.Components
{
    public class BasketSummaryViewComponent : ViewComponent
    {
        private Basket basket;

        public BasketSummaryViewComponent (Basket basketService)
        {
            basket = basketService;
        }

        public IViewComponentResult Invoke()
        {
            return View(basket);
        }

    }
}
