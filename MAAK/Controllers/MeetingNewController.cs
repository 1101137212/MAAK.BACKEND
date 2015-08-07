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
    public class MeetingNewController : Controller
    {
        private MAAKEntities db = new MAAKEntities();

        // GET: MeetingNew
        public ActionResult Index()
        {
            return View(db.MeetingRecord.ToList());
        }

        // GET: MeetingNew/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRecord meetingRecord = db.MeetingRecord.Find(id);
            if (meetingRecord == null)
            {
                return HttpNotFound();
            }
            return View(meetingRecord);
        }

        // GET: MeetingNew/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingNew/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetingRecord_ID,MeetingRecord_Title,MeetingRecord_Detail,MeetingRecord_Date,MeetingRecord_Starttime,MeetingRecord_Endtime,MeetingRecord_Place,MeetingRecord_File,MeetingRecord_Modificationdatetime")] MeetingRecord meetingRecord)
        {
            if (ModelState.IsValid)
            {
                db.MeetingRecord.Add(meetingRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetingRecord);
        }

        // GET: MeetingNew/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRecord meetingRecord = db.MeetingRecord.Find(id);
            if (meetingRecord == null)
            {
                return HttpNotFound();
            }
            return View(meetingRecord);
        }

        // POST: MeetingNew/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetingRecord_ID,MeetingRecord_Title,MeetingRecord_Detail,MeetingRecord_Date,MeetingRecord_Starttime,MeetingRecord_Endtime,MeetingRecord_Place,MeetingRecord_File,MeetingRecord_Modificationdatetime")] MeetingRecord meetingRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetingRecord);
        }

        // GET: MeetingNew/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRecord meetingRecord = db.MeetingRecord.Find(id);
            if (meetingRecord == null)
            {
                return HttpNotFound();
            }
            return View(meetingRecord);
        }

        // POST: MeetingNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingRecord meetingRecord = db.MeetingRecord.Find(id);
            db.MeetingRecord.Remove(meetingRecord);
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
