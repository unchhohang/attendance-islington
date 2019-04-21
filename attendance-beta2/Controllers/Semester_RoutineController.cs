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
    public class Semester_RoutineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Semester_Routine
        public ActionResult Index()
        {
            var semester_Routine = db.Semester_Routine.Include(s => s.Routines).Include(s => s.Semesters);
            return View(semester_Routine.ToList());
        }

        // GET: Semester_Routine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Routine semester_Routine = db.Semester_Routine.Find(id);
            if (semester_Routine == null)
            {
                return HttpNotFound();
            }
            return View(semester_Routine);
        }

        // GET: Semester_Routine/Create
        public ActionResult Create()
        {
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Level");
            return View();
        }

        // POST: Semester_Routine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterRoutineId,SemesterId,RoutineId")] Semester_Routine semester_Routine)
        {
            if (ModelState.IsValid)
            {
                db.Semester_Routine.Add(semester_Routine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", semester_Routine.RoutineId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Level", semester_Routine.SemesterId);
            return View(semester_Routine);
        }

        // GET: Semester_Routine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Routine semester_Routine = db.Semester_Routine.Find(id);
            if (semester_Routine == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", semester_Routine.RoutineId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Level", semester_Routine.SemesterId);
            return View(semester_Routine);
        }

        // POST: Semester_Routine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterRoutineId,SemesterId,RoutineId")] Semester_Routine semester_Routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester_Routine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", semester_Routine.RoutineId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Level", semester_Routine.SemesterId);
            return View(semester_Routine);
        }

        // GET: Semester_Routine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Routine semester_Routine = db.Semester_Routine.Find(id);
            if (semester_Routine == null)
            {
                return HttpNotFound();
            }
            return View(semester_Routine);
        }

        // POST: Semester_Routine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester_Routine semester_Routine = db.Semester_Routine.Find(id);
            db.Semester_Routine.Remove(semester_Routine);
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
