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
    public class SemestersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Semesters
        public ActionResult Index()
        {
            //return View(db.Semesters.ToList());
            String sql = "SELECT * from Semesters";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Semester().List(dt);
            return View(model);
        }

        // GET: Semesters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Semester semester = db.Semesters.Find(id);
            String sql = "SELECT * from Semesters WHERE SemesterId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Semester().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Semesters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterId,Year,Level")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                //db.Semesters.Add(semester);
                //db.SaveChanges();
                string sql = "INSERT INTO Semesters(Year, Level) " +
                    "values( '" + semester.Year + "', '" + semester.Level + "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(semester);
        }

        // GET: Semesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Semester semester = db.Semesters.Find(id);
            String sql = "SELECT * from Semesters WHERE SemesterId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Semester().List(dt).FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterId,Year,Level")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(semester).State = EntityState.Modified;
                //db.SaveChanges();
                String sql = "Update Semesters set Year='" + semester.Year + "', Level='" + semester.Level + "   ' where semesterId = " + semester.SemesterId;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(semester);
        }

        // GET: Semesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Semester semester = db.Semesters.Find(id);
            String sql = "SELECT * from Semesters WHERE semesterId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Semester().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Semester semester = db.Semesters.Find(id);
            //db.Semesters.Remove(semester);
            //db.SaveChanges();
            String sql = "DELETE FROM Semesters where semesterId = " + id;
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
