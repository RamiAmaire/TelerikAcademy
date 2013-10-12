using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using TicketingSystem.Models;

namespace TicketingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }
    }
}
