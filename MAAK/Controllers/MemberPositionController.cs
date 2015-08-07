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
    public class MemberPositionController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: MemberPosition
        public ActionResult Index()
        {
            var positionRecord = db.PositionRecord.Include(p => p.MeetingRecord).Include(p => p.Member).Include(p => p.Position);
            return View(positionRecord.ToList());
        }

        // GET: MemberPosition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionRecord positionRecord = db.PositionRecord.Find(id);
            if (positionRecord == null)
            {
                return HttpNotFound();
            }
            return View(positionRecord);
        }

        // GET: MemberPosition/Create
        public ActionResult Create()
        {
            ViewBag.MeetingRecord_ID = new SelectList(db.MeetingRecord, "MeetingRecord_ID", "MeetingRecord_Title");
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name");
            ViewBag.Position_ID = new SelectList(db.Position, "Position_ID", "Position_Name");
            return View();
        }

        // POST: MemberPosition/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionRecord_ID,PositionRecord_Startdate,PositionRecord_Enddate,Member_ID,Position_ID,MeetingRecord_ID")] PositionRecord positionRecord)
        {
            if (ModelState.IsValid)
            {
                db.PositionRecord.Add(positionRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingRecord_ID = new SelectList(db.MeetingRecord, "MeetingRecord_ID", "MeetingRecord_Title", positionRecord.MeetingRecord_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", positionRecord.Member_ID);
            ViewBag.Position_ID = new SelectList(db.Position, "Position_ID", "Position_Name", positionRecord.Position_ID);
            return View(positionRecord);
        }

        // GET: MemberPosition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionRecord positionRecord = db.PositionRecord.Find(id);
            if (positionRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingRecord_ID = new SelectList(db.MeetingRecord, "MeetingRecord_ID", "MeetingRecord_Title", positionRecord.MeetingRecord_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", positionRecord.Member_ID);
            ViewBag.Position_ID = new SelectList(db.Position, "Position_ID", "Position_Name", positionRecord.Position_ID);
            return View(positionRecord);
        }

        // POST: MemberPosition/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionRecord_ID,PositionRecord_Startdate,PositionRecord_Enddate,Member_ID,Position_ID,MeetingRecord_ID")] PositionRecord positionRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingRecord_ID = new SelectList(db.MeetingRecord, "MeetingRecord_ID", "MeetingRecord_Title", positionRecord.MeetingRecord_ID);
            ViewBag.Member_ID = new SelectList(db.Member, "Member_ID", "Member_Name", positionRecord.Member_ID);
            ViewBag.Position_ID = new SelectList(db.Position, "Position_ID", "Position_Name", positionRecord.Position_ID);
            return View(positionRecord);
        }

        // GET: MemberPosition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionRecord positionRecord = db.PositionRecord.Find(id);
            if (positionRecord == null)
            {
                return HttpNotFound();
            }
            return View(positionRecord);
        }

        // POST: MemberPosition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PositionRecord positionRecord = db.PositionRecord.Find(id);
            db.PositionRecord.Remove(positionRecord);
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
