using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SpessartiteTwitter.Data;
using Error_Handler_Control;
using System.Web.UI.HtmlControls;

namespace SpessartiteTwitter.Controls.Twitter
{
    public partial class Twitter : System.Web.UI.UserControl
    {
        private IQueryable<Tweet> _dataSource;

        public IQueryable<Tweet> DataSource
        {
            set { _dataSource = value; }
        }

        public bool CheckRights { get; set; }

        public bool IsUserDetails { get; set; }

        public override void DataBind()
        {
            TweetsListView.DataSource = _dataSource;
            TweetsListView.DataBind();

            base.DataBind();
        }

        public IQueryable<Tweet> GetTweets()
        {
            return this._dataSource;
        }

        //public IQueryable<Tweet> LatestTweetsListView_GetLatestTweets()
        //{
        //    var context = new TwitterEntities();

        //    return context.Tweets
        //        .Include("Comments")
        //        .Include("AspNetUser")
        //        .OrderByDescending(t => t.DatePosted)
        //        .AsQueryable();
        //}

        public string GetPostedTime(DateTime timePosted)
        {
            var timePassed = DateTime.Now - timePosted;

            if (timePassed.Days > 0)
            {
                return string.Format("{0} days ago", timePassed.Days);
            }
            else if (timePassed.Hours > 0)
            {
                return string.Format("{0} hours ago", timePassed.Hours);
            }
            else if (timePassed.Minutes > 0)
            {
                return string.Format("{0} minutes ago", timePassed.Minutes);
            }
            else if (timePassed.Seconds > 0)
            {
                return string.Format("{0} seconds ago", timePassed.Seconds);
            }

            return string.Empty;
        }

        //public void TweetSubmitBtn()
        //{
        //    var control = TweetsListView.Controls[0];
        //    Tweet tweet = new Tweet();

        //    tweet.TweetText = ((TextBox)control.FindControl("TweetTextTb")).Text;
        //    tweet.TweetTitle = ((TextBox)control.FindControl("TweetTitleTb")).Text;
        //    tweet.DatePosted = DateTime.Now;
        //    tweet.UserId = Context.User.Identity.GetUserId();

        //    TwitterEntities context = new TwitterEntities();
        //    using (context)
        //    {
        //        try
        //        {
        //            context.Tweets.Add(tweet);
        //            context.SaveChanges();
        //            ErrorSuccessNotifier.AddSuccessMessage("Tweet created.");
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrorSuccessNotifier.AddErrorMessage(ex);
        //        }
        //    }
        //}

        protected void TweetsListView_DataBound(object sender, EventArgs e)
        {
            var pager = this.TweetsDataPager;
            pager.Visible = pager.TotalRowCount > pager.MaximumRows;

            if (this.CheckRights)
            {
                CheckUserRights();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void TweetsListView_DeleteItem(int tweetId)
        {
            TwitterEntities context = new TwitterEntities();

            using (context)
            {
                var comments = context.Comments.Where(t => t.TweetId.Equals(tweetId));
                Tweet tweet = context.Tweets.Find(tweetId);
                try
                {
                    if (comments.Count() > 0)
                    {
                        context.Comments.RemoveRange(comments);
                    }
                    context.Tweets.Remove(tweet);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Delete successful.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        private void CheckUserRights()
        {
            using (var context = new TwitterEntities())
            {
                var user = context.AspNetUsers
                    .Find(Context.User.Identity.GetUserId());

                if (user != null)
                {
                    if (this.IsUserDetails)
                    {
                        if (Request.Params["Username"] != null &&
                            Request.Params["Username"] != Context.User.Identity.GetUserName())
                        {
                            TweetsListView.InsertItemPosition = InsertItemPosition.None;
                        }
                    }

                    if (user.AspNetRoles.All(r => r.Name != "admin"))
                    {
                        // User Logged in
                        foreach (ListViewItem item in TweetsListView.Items)
                        {
                            if ((item.FindControl("UserProfileHyperLink") as HyperLink).Text != user.UserName)
                            {
                                item.FindControl("LinkButtonEditTweet").Visible = false;
                                item.FindControl("LinkButtonDeleteTweet").Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    // Not Logged In
                    TweetsListView.InsertItemPosition = InsertItemPosition.None;
                    foreach (ListViewItem item in TweetsListView.Items)
                    {
                        item.FindControl("LinkButtonEditTweet").Visible = false;
                        item.FindControl("LinkButtonDeleteTweet").Visible = false;
                    }
                }
            }
        }

        public void TweetsListView_InsertItem()
        {
            using (var context = new TwitterEntities())
            {
                var control = TweetsListView.InsertItem;

                try
                {
                    Tweet newTweet = new Tweet()
                    {
                        DatePosted = DateTime.Now,
                        UserId = Context.User.Identity.GetUserId(),
                        TweetText = (control.FindControl("TweetTextTb") as TextBox).Text,
                        TweetTitle = (control.FindControl("TweetTitleTb") as TextBox).Text,
                    };

                    context.Tweets.Add(newTweet);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Tweet created.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }
    }
}