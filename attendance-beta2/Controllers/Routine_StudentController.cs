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
    public class Routine_StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Routine_Student
        public ActionResult Index()
        {
            var routine_Student = db.Routine_Student.Include(r => r.Routines).Include(r => r.Students);
            return View(routine_Student.ToList());
        }

        // GET: Routine_Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine_Student routine_Student = db.Routine_Student.Find(id);
            if (routine_Student == null)
            {
                return HttpNotFound();
            }
            return View(routine_Student);
        }

        // GET: Routine_Student/Create
        public ActionResult Create()
        {
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: Routine_Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoutineStudentID,RoutineId,StudentId")] Routine_Student routine_Student)
        {
            if (ModelState.IsValid)
            {
                db.Routine_Student.Add(routine_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", routine_Student.RoutineId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", routine_Student.StudentId);
            return View(routine_Student);
        }

        // GET: Routine_Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine_Student routine_Student = db.Routine_Student.Find(id);
            if (routine_Student == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", routine_Student.RoutineId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", routine_Student.StudentId);
            return View(routine_Student);
        }

        // POST: Routine_Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoutineStudentID,RoutineId,StudentId")] Routine_Student routine_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", routine_Student.RoutineId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", routine_Student.StudentId);
            return View(routine_Student);
        }

        // GET: Routine_Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine_Student routine_Student = db.Routine_Student.Find(id);
            if (routine_Student == null)
            {
                return HttpNotFound();
            }
            return View(routine_Student);
        }

        // POST: Routine_Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Routine_Student routine_Student = db.Routine_Student.Find(id);
            db.Routine_Student.Remove(routine_Student);
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
