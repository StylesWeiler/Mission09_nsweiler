using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_nsweiler.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            // grabs information on the basket
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // sets up the basket session
            
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket(); // first look for a pre-existing session, otherwise create a new session basket

            basket.Session = session; // set out basket session to the session variable defined above
            
            return basket;
        }


        [JsonIgnore]
        public ISession Session { get; set; } // greate a public varible of type ISession

        public override void AddItem(Book book, int qty, double price)
        {
            base.AddItem(book, qty, price);
            Session.setJson("Basket", this); // this references to the instance of the class we are operating in
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.setJson("Basket", this); // this references to the instance of the class we are operating in

        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket"); // removes the basket after the session expires


        }



    }
}
