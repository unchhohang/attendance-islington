
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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            //var courses = db.Courses.Include(c => c.Faculties);
            //return View(courses.ToList());
            string sql = "SELECT c.*, f.FacultyName AS FacultyName FROM courses c JOIN Faculties f ON c.FacultyId = f.FacultyId;";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);
            return View(model);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Course course = db.Courses.Find(id);
            String sql = "SELECT c.*, f.FacultyName AS FacultyName FROM courses c JOIN Faculties f ON c.FacultyId = f.FacultyId WHERE courseId= " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Name,FacultyId")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Courses.Add(course);
                //db.SaveChanges();
                string sql = "INSERT INTO Courses(Name, FacultyId) " +
                    "values( '" + course.Name + "', '" + course.FacultyId + "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", course.FacultyId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Course course = db.Courses.Find(id);
            String sql = "SELECT c.*, f.FacultyName AS FacultyName FROM courses c JOIN Faculties f ON c.FacultyId = f.FacultyId WHERE courseId= " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt).FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", model.FacultyId);
            return View(model);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Name,FacultyId")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(course).State = EntityState.Modified;
                //db.SaveChanges();
                String sql = "Update Courses set Name='" + course.Name+ "' where courseId = " + course.CourseId;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", course.FacultyId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Course course = db.Courses.Find(id);
            String sql = "SELECT c.*, f.FacultyName AS FacultyName FROM courses c JOIN Faculties f ON c.FacultyId = f.FacultyId WHERE courseId= " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt).FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Course course = db.Courses.Find(id);
            //db.Courses.Remove(course);
            //db.SaveChanges();
            String sql = "DELETE FROM courses where courseid = " + id;
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
