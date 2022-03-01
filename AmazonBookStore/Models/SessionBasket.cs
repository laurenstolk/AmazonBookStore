using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AmazonBookStore.Infrastructure;

namespace AmazonBookStore.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book bk, int qty)
        {
            base.AddItem(bk, qty);

            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book bk)
        {
            base.RemoveItem(bk);

            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();

            Session.Remove("Basket");
        }

    }
}
