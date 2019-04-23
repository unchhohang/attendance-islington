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
            //var student_Course = db.Student_Course.Include(s => s.Courses).Include(s => s.Students);
            //return View(student_Course.ToList());
            String sql = "SELECT sc.*, c.Name, s.StudentName FROM Student_Course sc JOIN Courses c ON sc.CourseId = c.CourseId JOIN Students s ON sc.StudentId = s.StudentId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student_Course().List(dt);
            return View(model);
        }

        // GET: Student_Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student_Course student_Course = db.Student_Course.Find(id);
            String sql = "SELECT sc.*, c.Name, s.StudentName FROM Student_Course sc JOIN Courses c ON sc.CourseId = c.CourseId JOIN Students s ON sc.StudentId = s.StudentId WHERE sc.StudentCourseId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student_Course().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
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
                //db.Student_Course.Add(student_Course);
                //db.SaveChanges();
                string sql = "INSERT INTO Student_Course(CourseId, StudentId) " +
                    "values( '" + student_Course.CourseId+ "', '" + student_Course.StudentId+ "')";
                db.Create(sql);
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
            //Student_Course model = db.Student_Course.Find(id);
            String sql = "SELECT sc.*, c.Name, s.StudentName FROM Student_Course sc JOIN Courses c ON sc.CourseId = c.CourseId JOIN Students s ON sc.StudentId = s.StudentId WHERE sc.StudentCourseId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student_Course().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", model.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", model.StudentId);
            return View(model);
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
                //String sql = "Update Student_Course set CourseId='" + student_Course.CourseId + "', StudentId='" + student_Course.StudentId+ "' where StudentCourseId = " + student_Course.StudentCourseId;
                //db.Edit(sql);
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
            //Student_Course student_Course = db.Student_Course.Find(id);
            String sql = "SELECT sc.*, c.Name, s.StudentName FROM Student_Course sc JOIN Courses c ON sc.CourseId = c.CourseId JOIN Students s ON sc.StudentId = s.StudentId WHERE sc.StudentCourseId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student_Course().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Student_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Student_Course student_Course = db.Student_Course.Find(id);
            //db.Student_Course.Remove(student_Course);
            //db.SaveChanges();
            String sql = "DELETE FROM Student_Course where StudentCourseId = " + id;
            db.Delete(sql);
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
