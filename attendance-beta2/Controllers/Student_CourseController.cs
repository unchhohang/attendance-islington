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
    public class Student_CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student_Course
        public ActionResult Index()
        {
            var student_Course = db.Student_Course.Include(s => s.Courses).Include(s => s.Students);
            return View(student_Course.ToList());
        }

        // GET: Student_Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // GET: Student_Course/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: Student_Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentCourseId,CourseId,StudentId")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                db.Student_Course.Add(student_Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", student_Course.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", student_Course.StudentId);
            return View(student_Course);
        }

        // GET: Student_Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", student_Course.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", student_Course.StudentId);
            return View(student_Course);
        }

        // POST: Student_Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentCourseId,CourseId,StudentId")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", student_Course.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", student_Course.StudentId);
            return View(student_Course);
        }

        // GET: Student_Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // POST: Student_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Course student_Course = db.Student_Course.Find(id);
            db.Student_Course.Remove(student_Course);
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
