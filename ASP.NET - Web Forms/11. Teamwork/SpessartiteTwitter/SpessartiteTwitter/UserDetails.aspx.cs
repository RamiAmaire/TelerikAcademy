using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;

namespace SpessartiteTwitter
{
    using Data;

    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            TwitterPanel.CheckRights = true;
            TwitterPanel.IsUserDetails = true;
            this.TwitterPanel.DataSource = UserTweetsListView_GetUserTweets(Request.Params["Username"]);
        }

        public AspNetUser UserDetailsFormView_GetUserInfo([QueryString] string Username)
        {
            var context = new TwitterEntities();

            if (!string.IsNullOrEmpty(Username))
            {
                return context.AspNetUsers
                    .FirstOrDefault(u => u.UserName == Username);
            }
            else
            {
                var userID = User.Identity.GetUserId();
                return context.AspNetUsers
                    .FirstOrDefault(u => u.Id == userID);
            }
        }

        public IQueryable<Tweet> UserTweetsListView_GetUserTweets([QueryString] string Username)
        {
            var context = new TwitterEntities();

            if (!string.IsNullOrEmpty(Username))
            {
                return context.Tweets
                    .Include("Comments")
                    .Include("AspNetUser")
                    .Where(t => t.AspNetUser.UserName == Username)
                    .OrderByDescending(t => t.DatePosted)
                    .AsQueryable();
            }
            else
            {
                var userID = User.Identity.GetUserId();
                return context.Tweets
                    .Include("Comments")
                    .Include("AspNetUser")
                    .Where(t => t.AspNetUser.Id == userID)
                    .OrderByDescending(t => t.DatePosted)
                    .AsQueryable();
            }
        }

        //protected void UserTweetsListView_DataBound(object sender, EventArgs e)
        //{
        //    var pager = this.UserTweetsDataPager;
        //    pager.Visible = pager.TotalRowCount > pager.MaximumRows;
        //}
    }
}