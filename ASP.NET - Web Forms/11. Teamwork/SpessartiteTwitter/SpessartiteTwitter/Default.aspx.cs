namespace SpessartiteTwitter
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Data;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.TwitterPanel.CheckRights = true;
            this.TwitterPanel.DataSource = LatestTweetsListView_GetLatestTweets();
        }

        public IQueryable<Tweet> LatestTweetsListView_GetLatestTweets()
        {
            var context = new TwitterEntities();
            return context.Tweets
                .Include("Comments")
                .Include("AspNetUser")
                .OrderByDescending(t => t.DatePosted);
        }

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
    }
}