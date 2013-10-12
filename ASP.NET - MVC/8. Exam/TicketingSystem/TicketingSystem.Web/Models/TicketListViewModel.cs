using System;
using System.Linq.Expressions;
using TicketingSystem.Models;

namespace TicketingSystem.Web.Models
{
    public class TicketListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public string Priority { get; set; }
    }
}