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
using System.IO;
using Error_Handler_Control;

namespace SpessartiteTwitter.Registered
{
    public partial class Settings : System.Web.UI.Page
    {
        private AspNetUser user;
        private const string PNG_FORMAT = ".png";
        private const string _200KB = "204800";
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!User.IsInRole("admin"))
            {
                CheckBoxList list = (CheckBoxList)this.FormViewSettings.FindControl("CheckBoxListRoles");
                list.Visible=false;
            }
        }

        public IQueryable<AspNetRole> CheckBoxListRoles_GetAll()
        {
            var context = new TwitterEntities();
            return context.AspNetRoles;
        }

        public AspNetUser FormViewSettings_GetItem()
        {
            string userId = string.Empty;
            if (Request.Params["userId"] == null)
            {
                userId = User.Identity.GetUserId();
            }
            else if (User.IsInRole("admin"))
            {
                userId = Request.Params["userId"];
            }

            var context = new TwitterEntities();
            AspNetUser user = context.AspNetUsers
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                ModelState.AddModelError("", "User doesn't exist in the database anymore.");
                return null;
            }

            this.user = user;
            return user;
        }
        public void FormViewSettings_UpdateItem(string id)
        {
            using (var context = new TwitterEntities())
            {
                var user = context.AspNetUsers.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", "гредЪ");
                    return;
                }

                TryUpdateModel(user);
                if (ModelState.IsValid)
                {
                    try
                    {
                        byte[] profileImage = ProcessUploadData();
                        if (profileImage != null)
                        {
                            user.Picture = profileImage;
                        }
                        var list = this.FormViewSettings.FindControl("CheckBoxListRoles") as CheckBoxList;
                        foreach (ListItem item in list.Items)
                        {
                            var role = context.AspNetRoles.First(r => r.Name == item.Text);
                            if (item.Selected)
                            {
                                user.AspNetRoles.Add(role);
                            }
                            else
                            {
                                user.AspNetRoles.Remove(role);
                            }
                        }

                        context.SaveChanges();
                        ErrorSuccessNotifier.ShowAfterRedirect = true;
                        ErrorSuccessNotifier.AddSuccessMessage("Profile edit successful.");
                        Response.Redirect("~/UserDetails.aspx?Username=" + user.UserName, false);
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
            }
        }

        private byte[] ProcessUploadData()
        {
            FileUpload fileUploadControl = (FileUpload)this.FormViewSettings.FindControl("ProfilePictureFileUpload");
            byte[] fileData = null;
            if (fileUploadControl.HasFile)
            {
                Stream fileStream = null;
                int length = 0;
                string fileName = fileUploadControl.FileName;
                string fileExtension = Path.GetExtension(fileName).ToLower();

                if (fileExtension == PNG_FORMAT)
                {
                    length = fileUploadControl.PostedFile.ContentLength;
                    fileData = new byte[length + 1];

                    if (fileData.Length <= int.Parse(_200KB))
                    {
                        fileStream = fileUploadControl.PostedFile.InputStream;
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

        protected void CheckBoxListRoles_DataBound(object sender, EventArgs e)
        {
            var list = (sender as CheckBoxList);
            var user = this.user;
            foreach (ListItem item in list.Items)
            {
                if (user.AspNetRoles.Any(r => r.Name == item.Text))
                {
                    item.Selected = true;
                }
            }
        }
    }
}