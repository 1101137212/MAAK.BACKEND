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
    public class AwardsController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: Awards
        public ActionResult Index()
        {
            var awardRecord = db.AwardRecord.Include(a => a.Award).Include(a => a.Member);
            return View(awardRecord.ToList());
        }

        // GET: Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardRecord awardRecord = db.AwardRecord.Find(id);
            if (awardRecord == null)
            {
                return HttpNotFound();
            }
            return View(awardRecord);
        }

        // GET: Awards/Create
        public ActionResult Create()
        {
            ViewBag.Award_ID = new SelectList(db.Award, "Award_ID", "Award_Title");
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            return View();
        }

        // POST: Awards/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AwardRecord_ID,AwardRecord_Date,Award_ID,Member_IDxx")] AwardRecord awardRecord)
        {
            if (ModelState.IsValid)
            {
                db.AwardRecord.Add(awardRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Award_ID = new SelectList(db.Award, "Award_ID", "Award_Title", awardRecord.Award_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", awardRecord.Member_ID);
            return View(awardRecord);
        }

        // GET: Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardRecord awardRecord = db.AwardRecord.Find(id);
            if (awardRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.Award_ID = new SelectList(db.Award, "Award_ID", "Award_Title", awardRecord.Award_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", awardRecord.Member_ID);
            return View(awardRecord);
        }

        // POST: Awards/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AwardRecord_ID,AwardRecord_Date,Award_ID,Member_ID")] AwardRecord awardRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(awardRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Award_ID = new SelectList(db.Award, "Award_ID", "Award_Title", awardRecord.Award_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", awardRecord.Member_ID);
            return View(awardRecord);
        }

        // GET: Awards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AwardRecord awardRecord = db.AwardRecord.Find(id);
            if (awardRecord == null)
            {
                return HttpNotFound();
            }
            return View(awardRecord);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AwardRecord awardRecord = db.AwardRecord.Find(id);
            db.AwardRecord.Remove(awardRecord);
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
