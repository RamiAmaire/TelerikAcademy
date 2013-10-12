using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Models;
using TicketingSystem.Data;

namespace TicketingSystem.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class CommentsAdministrationController : BaseController
    {
        public ActionResult Index()
        {
            var comments = this.Data.Comments.All();
            return View(comments);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int commentId = int.Parse(id.ToString());
            Comment comment = this.Data.Comments.GetById(commentId);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int commentId = int.Parse(id.ToString());
            Comment comment = this.Data.Comments.GetById(commentId);
            if (comment == null)
            {
                return HttpNotFound();
            }

            ViewBag.TicketId = new SelectList(this.Data.Tickets.All(), "Id", "AuthorId", comment.TicketId);
            ViewBag.UserId = new SelectList(this.Data.Users.All(), "Id", "UserName", comment.UserId);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.Data.Comments.Update(comment);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(this.Data.Tickets.All(), "Id", "AuthorId", comment.TicketId);
            ViewBag.UserId = new SelectList(this.Data.Users.All(), "Id", "UserName", comment.UserId);
            return View(comment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int commentId = int.Parse(id.ToString());
            Comment comment = this.Data.Comments.GetById(commentId);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.Data.Comments.GetById(id);
            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
