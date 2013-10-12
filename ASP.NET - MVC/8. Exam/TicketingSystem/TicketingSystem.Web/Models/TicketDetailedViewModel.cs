using System;
using System.Collections.Generic;
using TicketingSystem.Models;

namespace TicketingSystem.Web.Models
{
    public class TicketDetailedViewModel
    {
        public TicketDetailedViewModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public Priority Priority { get; set; }

        public string ScreenShotUrl { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }
    }
}