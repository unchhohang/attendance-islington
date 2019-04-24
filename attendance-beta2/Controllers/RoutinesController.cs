using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using attendance_beta2.Models;

namespace attendance_beta2.Controllers
{
    public class RoutinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Routines
        public ActionResult Index()
        {
            //var routines = db.Routines.Include(r => r.Courses).Include(r => r.Semesters).Include(r => r.Teachers);
            //return View(routines.ToList());

            String sql = "SELECT R.*, C.Name AS CourseName, T.Name AS TeacherName, SE.Level AS SemesterLevel FROM Routines R JOIN Courses C ON R.CourseId = C.CourseId JOIN Staffs T ON R.TeacherId = T.StaffId JOIN Semesters SE ON R.SemesterId = SE.SemesterId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().List(dt);
            return View(model);

            
        }

        // GET: Routines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // GET: Routines/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Year");
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name");
            return View();
        }

        // POST: Routines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoutineId,CourseId,Day,StartTime,EndTime,Room,ClassType,TeacherId,SemesterId")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Routines.Add(routine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", routine.CourseId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Year", routine.SemesterId);
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name", routine.TeacherId);
            return View(routine);
        }

        // GET: Routines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", routine.CourseId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Year", routine.SemesterId);
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name", routine.TeacherId);
            return View(routine);
        }

        // POST: Routines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoutineId,CourseId,Day,StartTime,EndTime,Room,ClassType,TeacherId,SemesterId")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", routine.CourseId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Year", routine.SemesterId);
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name", routine.TeacherId);
            return View(routine);
        }

        // GET: Routines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // POST: Routines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Routine routine = db.Routines.Find(id);
            db.Routines.Remove(routine);
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
