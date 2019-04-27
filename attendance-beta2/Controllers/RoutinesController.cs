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
            //Routine routine = db.Routines.Find(id);
            String sql = "SELECT R.*, C.Name AS CourseName, T.Name AS TeacherName, SE.Level AS SemesterLevel FROM Routines R JOIN Courses C ON R.CourseId = C.CourseId JOIN Staffs T ON R.TeacherId = T.StaffId JOIN Semesters SE ON R.SemesterId = SE.SemesterId" +
                " WHERE RoutineId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().List(dt).FirstOrDefault();
            if (model== null)
            {
                return HttpNotFound();
            }
            return View(model);
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
                //db.Routines.Add(routine);
                //db.SaveChanges();
                
                string sql = "INSERT INTO Routines(CourseId, Day, StartTime, EndTime, Room, ClassType, TeacherId, SemesterId) " +
                    "values( '" + routine.CourseId + "', '" + routine.DayName+ "', '" + routine.StartTime + "', '" + routine.EndTime + "', '" + routine.Room + "', '" + routine.ClassType + "', '" + routine.TeacherId + "', '" + routine.SemesterId + "')";
                db.Create(sql);
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
            //Routine routine = db.Routines.Find(id);
            String sql = "SELECT R.*, C.Name AS CourseName, T.Name AS TeacherName, SE.Level AS SemesterLevel FROM Routines R JOIN Courses C ON R.CourseId = C.CourseId JOIN Staffs T ON R.TeacherId = T.StaffId JOIN Semesters SE ON R.SemesterId = SE.SemesterId WHERE RoutineId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", model.CourseId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Year", model.SemesterId);
            ViewBag.TeacherId = new SelectList(db.Staffs, "StaffId", "Name", model.TeacherId);
            return View(model);
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
                //db.Entry(routine).State = EntityState.Modified;
                //db.SaveChanges();
                String sql = "Update Routines set CourseId='" + routine.CourseId + "', Day='" + routine.DayName+ "', StartTime='" + routine.StartTime + "', EndTime='" + routine.EndTime + "', Room='" + routine.Room + "', ClassTYpe='" + routine.ClassType + "', TeacherId='" + routine.TeacherId+ "', SemesterId='" + routine.SemesterId + "' where RoutineId= " + routine.RoutineId;
                db.Edit(sql);
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
            //Routine routine = db.Routines.Find(id);
            String sql = "SELECT R.*, C.Name AS CourseName, T.Name AS TeacherName, SE.Level AS SemesterLevel FROM Routines R JOIN Courses C ON R.CourseId = C.CourseId JOIN Staffs T ON R.TeacherId = T.StaffId JOIN Semesters SE ON R.SemesterId = SE.SemesterId" +
                " WHERE RoutineId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Routines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Routine routine = db.Routines.Find(id);
            //db.Routines.Remove(routine);
            //db.SaveChanges();
            String sql = "DELETE FROM Routines where RoutineId = " + id;
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

        public ActionResult InRoutineModuleTeacherReport()
        {
            string sql = "SELECT R.*, C.Name AS CourseName, T.Name AS TeacherName, SE.Level AS SemesterLevel FROM Routines R JOIN Courses C ON R.CourseId = C.CourseId JOIN Staffs T ON R.TeacherId = T.StaffId JOIN Semesters SE ON R.SemesterId = SE.SemesterId Where R.courseId < 0";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().List(dt);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InRoutineModuleTeacherReport(Routine routine)
        {
            string sql = "SELECT R.*, C.Name AS CourseName, T.Name AS TeacherName, SE.Level AS SemesterLevel FROM Routines R JOIN Courses C ON R.CourseId = C.CourseId JOIN Staffs T ON R.TeacherId = T.StaffId JOIN Semesters SE ON R.SemesterId = SE.SemesterId Where R.CourseId = " + routine.CourseId;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().List(dt);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View(model);
        }

        public ActionResult TeacherWorkingHoursReport()
        {
            string sql = "SELECT T.Name AS TeacherName, MAX(T.Email) AS Email, MAX(C.Name) AS CourseName,MAX(SE.Level) AS SemesterLevel, SUM(DATEDIFF(hour, Convert(DateTime,R.StartTime, 5), Convert(DateTime,R.EndTime,5))) AS WorkingHour FROM Routines R JOIN Courses C ON R.CourseId = C.CourseId JOIN Staffs T ON R.TeacherId = T.StaffId JOIN Semesters SE ON R.SemesterId = SE.SemesterId GROUP BY T.Name";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Routine().getWorkingHours(dt);
            
            return View(model);
        }

    }
}
