using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Category
    {
        public Category()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(6), MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
