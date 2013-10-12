using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SpessartiteTwitter.Models
{
    public class ApplicationUser : User
    {
        //public byte[] ProfilePicture { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        //public DbSet<Tweet> Tweets { get; set; }

        //public DbSet<Comment> Comments { get; set; }
    }
}