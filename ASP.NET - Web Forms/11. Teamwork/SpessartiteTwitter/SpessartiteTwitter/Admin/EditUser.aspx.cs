using SpessartiteTwitter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpessartiteTwitter.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public AspNetUser FormViewSettings_GetItem(int? id)
        //{
        //    string userId = string.Empty;
        //    try
        //    {
        //        userId = User.Identity.GetUserId().ToString();
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "You need to be logged to comment.");
        //        return null;
        //    }

        //    var context = new TwitterEntities();
        //    AspNetUser user = context.AspNetUsers.FirstOrDefault(u => u.Id == userId);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "User doesn't exist in the database anymore.");
        //        return null;
        //    }

        //    return user;
        //}

        // The id parameter name should match the DataKeyNames value set on the control
        //public void FormViewEditUser_UpdateItem(string id)
        //{
        //    AspNetUser user = null;
        //    // Load the item here, e.g. item = MyDataLayer.Find(id);
        //    if (user == null)
        //    {
        //        // The item wasn't found
        //        ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
        //        return;
        //    }
        //    TryUpdateModel(user);
        //    if (ModelState.IsValid)
        //    {
        //        // Save changes here, e.g. MyDataLayer.SaveChanges();

        //    }
        //}
    }
}