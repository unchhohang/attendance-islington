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
    public class teacher_courseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: teacher_course
        public ActionResult Index()
        {
            var teacher_course = db.teacher_course.Include(t => t.Courses).Include(t => t.Teachers);
            return View(teacher_course.ToList());
        }

        // GET: teacher_course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_course teacher_course = db.teacher_course.Find(id);
            if (teacher_course == null)
            {
                return HttpNotFound();
            }
            return View(teacher_course);
        }

        // GET: teacher_course/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name");
            return View();
        }

        // POST: teacher_course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Teacher_Course_Id,TeacherId,CourseId")] teacher_course teacher_course)
        {
            if (ModelState.IsValid)
            {
                db.teacher_course.Add(teacher_course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", teacher_course.CourseId);
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name", teacher_course.TeacherId);
            return View(teacher_course);
        }

        // GET: teacher_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_course teacher_course = db.teacher_course.Find(id);
            if (teacher_course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", teacher_course.CourseId);
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name", teacher_course.TeacherId);
            return View(teacher_course);
        }

        // POST: teacher_course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Teacher_Course_Id,TeacherId,CourseId")] teacher_course teacher_course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher_course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", teacher_course.CourseId);
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name", teacher_course.TeacherId);
            return View(teacher_course);
        }

        // GET: teacher_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_course teacher_course = db.teacher_course.Find(id);
            if (teacher_course == null)
            {
                return HttpNotFound();
            }
            return View(teacher_course);
        }

        // POST: teacher_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacher_course teacher_course = db.teacher_course.Find(id);
            db.teacher_course.Remove(teacher_course);
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
