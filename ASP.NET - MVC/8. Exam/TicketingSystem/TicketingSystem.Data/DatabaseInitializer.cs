using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Models;

namespace LaptopSystem.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            // This method creates admin user with username - admin and password - admin123
            SeedUserAdmin(context);
            Random rand = new Random();
            Category sampleCategory = new Category { Name = "KendoUI" };
            // not admin user
            ApplicationUser user = new ApplicationUser() { UserName = "TestUser", Points = 10 };

            for (int i = 0; i < 10; i++)
            {
                Ticket ticket = new Ticket();
                ticket.Author = user;
                ticket.Category = sampleCategory;
                ticket.Title = "KendoUI problem.";
                ticket.Priority = Priority.Medium;
                ticket.Description = "This is awesome ticket";

                var commentsCount = rand.Next(0, 10);
                for (int j = 0; j < commentsCount; j++)
                {
                    ticket.Comments.Add(new Comment { Content = "Mnou qk ticket brat. :D",
                        User = user, Ticket = ticket });
                }

                context.Tickets.Add(ticket);
            }

            context.SaveChanges();
            base.Seed(context);
        }

        private static void SeedUserAdmin(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var db = new ApplicationDbContext();

            var userAdmin = new ApplicationUser()
            {
                UserName = "admin",
                Points = 10,
                Logins = new Collection<UserLogin>()
                {
                    new UserLogin()
                    {
                        LoginProvider = "Local",
                        ProviderKey = "admin",
                    }
                },
                Roles = new Collection<UserRole>()
                {
                    new UserRole()
                    {
                        Role = new Role("Admin")
                    }
                }
            };

            db.Users.Add(userAdmin);
            db.UserSecrets.Add(new UserSecret("admin",
                "ACQbq83L/rsvlWq11Zor2jVtz2KAMcHNd6x1SN2EXHs7VuZPGaE8DhhnvtyO10Nf5Q=="));// Password - admin123
            db.SaveChanges();
        }
    }
}
