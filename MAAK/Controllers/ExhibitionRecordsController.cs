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
    public class ExhibitionRecordsController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: ExhibitionRecords
        public ActionResult Index()
        {
            var exhibitionRecord = db.ExhibitionRecord.Include(e => e.Exhibition).Include(e => e.Member);
            return View(exhibitionRecord.ToList());
        }

        // GET: ExhibitionRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExhibitionRecord exhibitionRecord = db.ExhibitionRecord.Find(id);
            if (exhibitionRecord == null)
            {
                return HttpNotFound();
            }
            return View(exhibitionRecord);
        }

        // GET: ExhibitionRecords/Create
        public ActionResult Create()
        {
            ViewBag.Exhibition_ID = new SelectList(db.Exhibition, "Exhibition_ID", "Exhibition_Title");
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: ExhibitionRecords/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExhibitionRecord_ID,ExhibitionRecord_State,Member_ID,Exhibition_ID")] ExhibitionRecord exhibitionRecord)
        {
            if (ModelState.IsValid)
            {
                db.ExhibitionRecord.Add(exhibitionRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Exhibition_ID = new SelectList(db.Exhibition, "Exhibition_ID", "Exhibition_Title", exhibitionRecord.Exhibition_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", exhibitionRecord.Member_ID);
            return View(exhibitionRecord);
        }

        // GET: ExhibitionRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExhibitionRecord exhibitionRecord = db.ExhibitionRecord.Find(id);
            if (exhibitionRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.Exhibition_ID = new SelectList(db.Exhibition, "Exhibition_ID", "Exhibition_Title", exhibitionRecord.Exhibition_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", exhibitionRecord.Member_ID);
            return View(exhibitionRecord);
        }

        // POST: ExhibitionRecords/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExhibitionRecord_ID,ExhibitionRecord_State,Member_ID,Exhibition_ID")] ExhibitionRecord exhibitionRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exhibitionRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Exhibition_ID = new SelectList(db.Exhibition, "Exhibition_ID", "Exhibition_Title", exhibitionRecord.Exhibition_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", exhibitionRecord.Member_ID);
            return View(exhibitionRecord);
        }

        // GET: ExhibitionRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExhibitionRecord exhibitionRecord = db.ExhibitionRecord.Find(id);
            if (exhibitionRecord == null)
            {
                return HttpNotFound();
            }
            return View(exhibitionRecord);
        }

        // POST: ExhibitionRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExhibitionRecord exhibitionRecord = db.ExhibitionRecord.Find(id);
            db.ExhibitionRecord.Remove(exhibitionRecord);
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
