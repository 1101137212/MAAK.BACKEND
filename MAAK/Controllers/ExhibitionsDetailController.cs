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
    public class ExhibitionsDetailController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: ExhibitionsDetail
        public ActionResult Index()
        {
            return View(db.Exhibition.ToList());
        }

        // GET: ExhibitionsDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibition.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // GET: ExhibitionsDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExhibitionsDetail/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Exhibition_ID,Exhibition_Title,Exhibition_Startdatetime,Exhibition_Enddatetime,Exhibition_Place,Exhibition_Detail,Exhibition_Picture,Exhibition_Otherpeople")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                db.Exhibition.Add(exhibition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exhibition);
        }

        // GET: ExhibitionsDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibition.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // POST: ExhibitionsDetail/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Exhibition_ID,Exhibition_Title,Exhibition_Startdatetime,Exhibition_Enddatetime,Exhibition_Place,Exhibition_Detail,Exhibition_Picture,Exhibition_Otherpeople")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exhibition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exhibition);
        }

        // GET: ExhibitionsDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibition.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // POST: ExhibitionsDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exhibition exhibition = db.Exhibition.Find(id);
            db.Exhibition.Remove(exhibition);
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
