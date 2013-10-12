using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class ApplicationUser : User
    {
        [Required, DefaultValue(10)]
        public int Points { get; set; }
    }
}
