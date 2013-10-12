using SpessartiteTwitter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpessartiteTwitter.Registered
{
    public partial class MyTweets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TwitterPanel.DataSource = GridViewTweets_GetData();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TwitterPanel.DataSource = GridViewTweets_GetData();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IOrderedQueryable<Tweet> GridViewTweets_GetData()
        {
            TwitterEntities context = new TwitterEntities();
            var userId = User.Identity.GetUserId();
            return context.Tweets
                                .Where(u => u.UserId.Equals(userId))
                                .OrderByDescending(t => t.DatePosted);
        }

        protected void GridViewTweets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}