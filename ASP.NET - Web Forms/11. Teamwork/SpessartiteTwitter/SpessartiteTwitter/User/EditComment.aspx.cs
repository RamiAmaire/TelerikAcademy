using Error_Handler_Control;
using SpessartiteTwitter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpessartiteTwitter.Registered
{
    public partial class EditComment : System.Web.UI.Page
    {
        private int tweetId;
        private int commentId;
        private bool isNewComment;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tweetId = Convert.ToInt32(Request.Params["tweetId"]);
            this.commentId = Convert.ToInt32(Request.Params["commentId"]);
            isNewComment = (this.commentId == 0);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!isNewComment)
            {
                TwitterEntities context = new TwitterEntities();

                using (context)
                {
                    Comment currentComment = context.Comments.Find(commentId);
                    this.TextBoxText.Text = currentComment.CommentText;
                    this.TextBoxDate.Text = currentComment.DatePosted.ToShortDateString();
                }
            }
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            TwitterEntities context = new TwitterEntities();
            Comment comment;
            using (context)
            {
                comment = context.Comments.Find(this.commentId);
                if (comment != null)
                {
                    if (!string.IsNullOrEmpty(this.TextBoxText.Text))
                    {
                        comment.CommentText = this.TextBoxText.Text;
                    }
                    else
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Please enter comment text.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(this.TextBoxDate.Text))
                    {
                        try
                        {
                            comment.DatePosted = DateTime.Parse(this.TextBoxDate.Text);
                        }
                        catch (Exception ex)
                        {
                            ErrorSuccessNotifier.AddErrorMessage(ex);
                        }
                    }
                    else
                    {
                        comment.DatePosted = DateTime.Now;
                    }
                }
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    ErrorSuccessNotifier.AddSuccessMessage("Comment edit successful");
                    Response.Redirect("EditTweet.aspx?tweetId=" + comment.TweetId, false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                    return;
                }
            }
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            TwitterEntities context = new TwitterEntities();
            Comment currentComment = context.Comments.Find(commentId);
            ErrorSuccessNotifier.ShowAfterRedirect = true;
            ErrorSuccessNotifier.AddSuccessMessage("Comment editing canceled.");
            Response.Redirect("EditTweet.aspx?tweetId=" + currentComment.TweetId, false);
        }
    }
}