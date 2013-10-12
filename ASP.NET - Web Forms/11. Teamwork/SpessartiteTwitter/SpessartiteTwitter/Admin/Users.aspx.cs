using SpessartiteTwitter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpessartiteTwitter
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
          
        }
        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteUser_Command(object sender, CommandEventArgs e)
        {

        }

        protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AspNetUser> GridViewUsers_GetData()
        {
            var context = new TwitterEntities();

            return context.AspNetUsers
                .OrderBy(u => u.UserName);
        }
    }
}