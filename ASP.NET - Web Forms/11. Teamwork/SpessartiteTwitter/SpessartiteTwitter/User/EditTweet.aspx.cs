using Error_Handler_Control;
using SpessartiteTwitter.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpessartiteTwitter.Registered
{
    public partial class EditTweet : System.Web.UI.Page
    {
        private const string PNG_FORMAT = ".png";
        private const string _200KB = "204800";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int tweetId = Convert.ToInt32(Request.Params["tweetId"]);
                TwitterEntities context = new TwitterEntities();
                using (context)
                {
                    Tweet currentTweet = context.Tweets.Find(tweetId);
                    if (!CheckUserRights(currentTweet))
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    this.TextBoxTitle.Text = currentTweet.TweetTitle;
                    this.TextBoxText.Text = currentTweet.TweetText;
                    this.TextBoxDate.Text = currentTweet.DatePosted.ToShortDateString();
                    this.RepeaterComments.DataSource = currentTweet.Comments.ToList();
                    this.DataBind();
                }
            }
        }

        private bool CheckUserRights(Tweet tweet)
        {
            if (User.IsInRole("admin"))
            {
                return true;
            }
            else if (User.Identity.GetUserId() == tweet.UserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            int tweetId = Convert.ToInt32(Request.Params["tweetId"]);
            TwitterEntities context = new TwitterEntities();

            using (context)
            {
                Tweet currentTweet = context.Tweets.Find(tweetId);
                if (currentTweet != null)
                {
                    if (!string.IsNullOrEmpty(this.TextBoxTitle.Text))
                    {
                        currentTweet.TweetTitle = this.TextBoxTitle.Text;
                    }
                    else
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Please enter tweet title.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(this.TextBoxText.Text))
                    {
                        currentTweet.TweetText = this.TextBoxText.Text;
                    }
                    else
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Please enter tweet text.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(this.TextBoxDate.Text))
                    {
                        try
                        {
                            currentTweet.DatePosted = DateTime.Parse(this.TextBoxDate.Text);
                        }
                        catch (Exception ex)
                        {
                            ErrorSuccessNotifier.AddErrorMessage(ex);
                        }
                    }
                    else
                    {
                        currentTweet.DatePosted = DateTime.Now;
                    }
                }
                try
                {
                    byte[] image = ProcessUploadData();
                    if (image != null)
                    {
                        currentTweet.Image = image;
                    }

                    context.SaveChanges();
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    ErrorSuccessNotifier.AddSuccessMessage("Tweet edit succesfull");
                    Response.Redirect("MyTweets.aspx", false);
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
            ErrorSuccessNotifier.ShowAfterRedirect = true;
            ErrorSuccessNotifier.AddSuccessMessage("Editing canceled.");
            Response.Redirect("MyTweets.aspx", false);
        }

        private byte[] ProcessUploadData()
        {
            byte[] fileData = null;
            if (this.ProfilePictureFileUpload.HasFile)
            {
                Stream fileStream = null;
                int length = 0;
                string fileName = this.ProfilePictureFileUpload.FileName;
                string fileExtension = Path.GetExtension(fileName).ToLower();

                if (fileExtension == PNG_FORMAT)
                {
                    length = ProfilePictureFileUpload.PostedFile.ContentLength;
                    fileData = new byte[length + 1];

                    if (fileData.Length <= int.Parse(_200KB))
                    {
                        fileStream = ProfilePictureFileUpload.PostedFile.InputStream;
                        fileStream.Read(fileData, 0, length);
                    }
                    else
                    {
                        throw new FileLoadException("Image must be up to 200KB.");
                    }
                }
                else
                {
                    throw new FileLoadException("Image must be in png format");
                }
            }

            return fileData;
        }

        protected void DeleteComment_Command(object sender, CommandEventArgs e)
        {
            int tweetId = Convert.ToInt32(Request.Params["tweetId"]);
            int commentId = Convert.ToInt32(e.CommandArgument);

            using (TwitterEntities context = new TwitterEntities())
            {
                Comment comment = context.Comments.Find(commentId);
                if (comment != null)
                {
                    try
                    {
                        context.Comments.Remove(comment);
                        context.SaveChanges();
                        ErrorSuccessNotifier.ShowAfterRedirect = true;
                        ErrorSuccessNotifier.AddSuccessMessage("Comment deleted.");
                        Response.Redirect("EditTweet?tweetId=" + tweetId, false);
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("There is no such comment.");
                }

            }
        }

        protected void LinkButtonCreateComment_Click(object sender, EventArgs e)
        {

        }
    }
}