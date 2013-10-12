using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TicketingSystem.Models;
using TicketingSystem.Web.Models;

namespace TicketingSystem.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class CategoriesAdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategories([DataSourceRequest]DataSourceRequest request)
        {
            var categories = this.Data.Categories.All().Select(CategoryAdminViewModel.FromCategory);
            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var existingCategory = this.Data.Categories.GetById(category.Id);
                existingCategory.Name = category.Name;
                this.Data.Categories.Update(existingCategory);
                this.Data.SaveChanges();
            }

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory([DataSourceRequest]DataSourceRequest request, CategoryAdminViewModel category)
        {
            var categoryToDelete = this.Data.Categories.GetById(category.Id);
            if (categoryToDelete != null)
            {
                foreach (var ticket in categoryToDelete.Tickets.ToList())
                {
                    foreach (var comment in ticket.Comments.ToList())
                    {
                        this.Data.Comments.Delete(comment);
                    }

                    this.Data.Tickets.Delete(ticket);
                }

                this.Data.Categories.Delete(categoryToDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                Category categoryToBase = new Category()
                {
                    Name = category.Name,
                };

                this.Data.Categories.Add(categoryToBase);
                this.Data.SaveChanges();
                category.Id = categoryToBase.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
	}
}