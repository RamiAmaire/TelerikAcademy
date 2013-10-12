using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using TicketingSystem.Web.Models;

namespace TicketingSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var topSixTickets = this.Data.Tickets.All().
                OrderByDescending(t => t.Comments.Count).Take(6).Select(TicketViewModel.FromTicket);

                this.HttpContext.Cache.Add("HomePageTickets", topSixTickets.ToList(), null,
                    DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageTickets"]);
        }
    }
}