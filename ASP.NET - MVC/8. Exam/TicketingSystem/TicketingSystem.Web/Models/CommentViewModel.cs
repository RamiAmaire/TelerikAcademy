using System;
using TicketingSystem.Models;
using System.Linq.Expressions;

namespace TicketingSystem.Web.Models
{
    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    AuthorName = comment.User.UserName,
                    Content = comment.Content
                };
            }
        }

        public string AuthorName { get; set; }

        [ShouldNotContainEmailAttribute]
        public string Content { get; set; }
    }
}