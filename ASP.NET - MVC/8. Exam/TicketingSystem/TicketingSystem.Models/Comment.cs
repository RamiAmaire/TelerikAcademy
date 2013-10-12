using System;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Comment
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ScaffoldColumn(false)]
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required, MinLength(6), MaxLength(1000), ShouldNotContainEmail]
        public string Content { get; set; }
    }
}
