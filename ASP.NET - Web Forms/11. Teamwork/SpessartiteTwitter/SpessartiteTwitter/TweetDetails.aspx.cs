using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using SpessartiteTwitter.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Infrastructure;
using System.Web.UI.HtmlControls;

namespace SpessartiteTwitter
{
    public partial class TweetDetails : System.Web.UI.Page
    {
        private int? tweetId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
            }
            else
            {
                tweetId = int.Parse(Request.Params["TweetId"]);
            }
        }

        public object FormViewTweetDetails_GetItem([QueryString] int? tweetId)
        {
            if (tweetId == null)
            {
                ModelState.AddModelError("", "Selected tweet doesn't exit in the database anymore.");
                this.TweetDetailsCommentsUpdatePanel.FindControl("CommentBoxHolder").Visible = false;
                return null;
            }

            var context = new TwitterEntities();
            Tweet currentTweet = context.Tweets.Include("AspNetUser").FirstOrDefault(t => t.TweetId == tweetId);

            return currentTweet;
        }

        protected void ButtonAddComment_Click(object sender, EventArgs e)
        {
            //this.CommentBoxHolder.Visible = false;
            //if (Request.Params["TweetId"] == null)
            //{
            //    ModelState.AddModelError("", "Selected tweet doesn't exist in the database anymore.");
            //    return;
            //}

            using (var context = new TwitterEntities())
            {
                string commentText = this.CommentText.Text;
                this.CommentText.Text = "";
                this.tweetId = int.Parse(Request.Params["TweetId"]);
                Tweet currentTweet = context.Tweets.FirstOrDefault(t => t.TweetId == this.tweetId);

                string userId = string.Empty;
                try
                {
                    userId = User.Identity.GetUserId().ToString();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "You need to be logged to comment.");
                    return;
                }

                Comment comment = new Comment()
                {
                    DatePosted = DateTime.Now,
                    TweetId = currentTweet.TweetId,
                    CommentText = commentText,
                    UserId = userId
                };

                context.Comments.Add(comment);
                try
                {
                    context.SaveChanges();
                    this.ListViewTweetComments.DataBind();
                }
                catch (Exception)
                {
                    // TODO
                    throw;
                }
            }
        }

        public IQueryable<Comment> ListViewTweetComments_GetData()
        {
            if (Request.Params["TweetId"] == null)
            {
                ModelState.AddModelError("", "Selected tweet doesn't exist in the database anymore.");
                return null;
            }

            int tweetId = int.Parse(Request.Params["TweetId"]);
            var context = new TwitterEntities();
            Tweet currentTweet = context.Tweets.FirstOrDefault(t => t.TweetId == tweetId);

            var comments = currentTweet.Comments;
            return comments.AsQueryable()
                                .OrderByDescending(d => d.DatePosted);
        }
    }
}