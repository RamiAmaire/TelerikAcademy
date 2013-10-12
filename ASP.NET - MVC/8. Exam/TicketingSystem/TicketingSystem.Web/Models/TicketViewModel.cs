using System;
using System.Linq.Expressions;
using TicketingSystem.Models;

namespace TicketingSystem.Web.Models
{
    public class TicketViewModel
    {
        public static Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    CategoryName = ticket.Category.Name,
                    AuthorName = ticket.Author.UserName,
                    CommentsCount = ticket.Comments.Count
                };
            }
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int CommentsCount { get; set; }
    }
}