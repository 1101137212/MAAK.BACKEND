using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MAAK.Models;

namespace MAAK.Controllers
{
    public class LatestactivityNewsController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: LatestactivityNews
        public ActionResult Index()
        {
            var latestNews = db.LatestNews.Include(l => l.Member);
            return View(latestNews.ToList());
        }

        // GET: LatestactivityNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestNews latestNews = db.LatestNews.Find(id);
            if (latestNews == null)
            {
                return HttpNotFound();
            }
            return View(latestNews);
        }

        // GET: LatestactivityNews/Create
        public ActionResult Create()
        {
            ViewBag.LatestNews_Modifier = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: LatestactivityNews/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LatestNews_ID,LatestNews_Title,LatestNews_Detail,LatestNews_State,LatestNews_Startdatetime,LatestNews_Enddatetime,LatestNews_Place,LatestNews_Organizer,LatestNews_Organizertelephonearea,LatestNews_Organizertelephone,LatestNews_Organizertelephoneext,LatestNews_Presscontacts,LatestNews_Presscontactstelephonearea,LatestNews_Presscontactstelephone,LatestNews_Presscontactstelephoneext,LatestNews_Presscontactsmobile,LatestNews_Presscontactsemail,LatestNews_Modifier,LatestNews_Modificationdatetime")] LatestNews latestNews)
        {
            if (ModelState.IsValid)
            {
                db.LatestNews.Add(latestNews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LatestNews_Modifier = new SelectList(db.Member, "Member_ID", "Member_Name", latestNews.LatestNews_Modifier);
            return View(latestNews);
        }

        // GET: LatestactivityNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestNews latestNews = db.LatestNews.Find(id);
            if (latestNews == null)
            {
                return HttpNotFound();
            }
            ViewBag.LatestNews_Modifier = new SelectList(db.Member, "Member_ID", "Member_Name", latestNews.LatestNews_Modifier);
            return View(latestNews);
        }

        // POST: LatestactivityNews/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LatestNews_ID,LatestNews_Title,LatestNews_Detail,LatestNews_State,LatestNews_Startdatetime,LatestNews_Enddatetime,LatestNews_Place,LatestNews_Organizer,LatestNews_Organizertelephonearea,LatestNews_Organizertelephone,LatestNews_Organizertelephoneext,LatestNews_Presscontacts,LatestNews_Presscontactstelephonearea,LatestNews_Presscontactstelephone,LatestNews_Presscontactstelephoneext,LatestNews_Presscontactsmobile,LatestNews_Presscontactsemail,LatestNews_Modifier,LatestNews_Modificationdatetime")] LatestNews latestNews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latestNews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LatestNews_Modifier = new SelectList(db.Member, "Member_ID", "Member_Name", latestNews.LatestNews_Modifier);
            return View(latestNews);
        }

        // GET: LatestactivityNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestNews latestNews = db.LatestNews.Find(id);
            if (latestNews == null)
            {
                return HttpNotFound();
            }
            return View(latestNews);
        }

        // POST: LatestactivityNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LatestNews latestNews = db.LatestNews.Find(id);
            db.LatestNews.Remove(latestNews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
