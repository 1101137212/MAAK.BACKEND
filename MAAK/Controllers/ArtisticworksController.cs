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
    public class ArtisticworksController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: Artisticworks
        public ActionResult Index()
        {
            var artisticworks = db.Artisticworks.Include(a => a.Member);
            return View(artisticworks.ToList());
        }

        // GET: Artisticworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artisticworks artisticworks = db.Artisticworks.Find(id);
            if (artisticworks == null)
            {
                return HttpNotFound();
            }
            return View(artisticworks);
        }

        // GET: Artisticworks/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: Artisticworks/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Artisticworks_ID,Artisticworks_Name,Artisticworks_Date,Artisticworks_Picture,Member_ID")] Artisticworks artisticworks)
        {
            if (ModelState.IsValid)
            {
                db.Artisticworks.Add(artisticworks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", artisticworks.Member_ID);
            return View(artisticworks);
        }

        // GET: Artisticworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artisticworks artisticworks = db.Artisticworks.Find(id);
            if (artisticworks == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", artisticworks.Member_ID);
            return View(artisticworks);
        }

        // POST: Artisticworks/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Artisticworks_ID,Artisticworks_Name,Artisticworks_Date,Artisticworks_Picture,Member_ID")] Artisticworks artisticworks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artisticworks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", artisticworks.Member_ID);
            return View(artisticworks);
        }

        // GET: Artisticworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artisticworks artisticworks = db.Artisticworks.Find(id);
            if (artisticworks == null)
            {
                return HttpNotFound();
            }
            return View(artisticworks);
        }

        // POST: Artisticworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artisticworks artisticworks = db.Artisticworks.Find(id);
            db.Artisticworks.Remove(artisticworks);
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
