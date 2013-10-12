using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required, MinLength(6), MaxLength(50), ShouldNotContainBug]
        public string Title { get; set; }

        [Required, DefaultValue(1)]
        public Priority Priority { get; set; }

        [MaxLength(500)]
        public string ScreenShotUrl { get; set; }

        [MinLength(6), MaxLength(1000), ShouldNotContainEmail]
        [UIHint("MultilineText")]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
