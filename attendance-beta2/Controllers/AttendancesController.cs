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
    //[Authorize ]
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendances
        public ActionResult Index()
        {
            //var attendances = db.Attendances.Include(a => a.Routines).Include(a => a.Students);
            String sql = "SELECT A.*, S.StudentName from Attendances A JOIN Students S" +
                " ON S.StudentId = A.StudentId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Attendance().List(dt);
            return View(model);


            //List<SelectList> items = new List<SelectList>();
            //return View(attendances.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Create(List<Attendance> attendance)
        {
            
                foreach (var item in attendance)
                {
                item.RoutineId = attendance.FirstOrDefault().RoutineId;
                //db.Attendances.Add(item);
                item.punchTime = DateTime.Now.ToUniversalTime();
                String sql = "INSERT INTO Attendances(StudentId, RoutineId, punchtime, Present) " +
                    "values('" + item.StudentId + "','" + item.RoutineId + "','" + DateTime.Now + "','" + item.Attended + "')";
                db.Create(sql);

            }
                db.SaveChanges();
                return RedirectToAction("Index");
            
            

           
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", attendance.RoutineId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", attendance.StudentId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendanceId,StudentId,RoutineId,PunchTime")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoutineId = new SelectList(db.Routines, "RoutineId", "Room", attendance.RoutineId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", attendance.StudentId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Show(Routine routine)
        {
            if (routine.CourseId != 0)
            {

                ViewBag.CourseId = new SelectList(db.Courses.ToList(), "CourseId", "Name", routine.CourseId);

                var r = db.Routines.Where(x => x.CourseId == routine.CourseId).Select(x => x.TeacherId).ToList();
                if (r.Count > 0)
                {
                    var teachers = "select * from staffs where staffid in(" + String.Join(",", r) + ")";
                    var dt = db.List(teachers);
                    var listTeachers = new Staff().List(dt);
                    ViewBag.StaffId = new SelectList(listTeachers, "StaffId", "Name", routine.TeacherId);


                }
                else
                {
                    List<Staff> lst = new List<Staff>();
                    ViewBag.StaffId = new SelectList(lst, "StaffId", "Name");
                }
            }
            if (routine.CourseId > 0 && routine.TeacherId > 0)
            {
                var sems = db.Routines.Where(x => x.TeacherId == routine.TeacherId && x.CourseId == routine.CourseId).Select(x => x.SemesterId).ToList();

                if (sems.Count > 0)
                {
                    var semSql = "select * from Semesters where SemesterId in(" + String.Join(",", sems) + ")";
                    var dt = db.List(semSql);
                    var listSems = new Semester().List(dt);
                    ViewBag.SemesterId = new SelectList(listSems, "SemesterId", "Level");
                }
                else
                {
                    List<Semester> lstse = new List<Semester>();
                    ViewBag.SemesterId = new SelectList(lstse, "SemesterId", "Level");
                }


            }
            else
            {
                List<Semester> lstse = new List<Semester>();
                ViewBag.SemesterId = new SelectList(lstse, "SemesterId", "Level");
            }

            if (routine.SemesterId > 0)
            {
                var rtnSql =
"SELECT * FROM Routines where CourseId = " + routine.CourseId + " and TeacherId = " + routine.TeacherId + " and SemesterId = " + routine.SemesterId;
                var lstRtn = db.List(rtnSql);
                var rtn = new Routine().List(lstRtn);
                ViewBag.RoutineId = rtn.FirstOrDefault().RoutineId;
                var sql = "select * from Students s inner join Student_Course sc on sc.StudentId=s.StudentId" +
                    " where CourseId=" + routine.CourseId;
                db.List(sql);
                var dt = db.List(sql);
                var attendances = new Attendance().List(dt);

                return View("AttendanceInterface", attendances);
            }
            var attendance = new List<Attendance>();
            return View("AttendanceInterface", attendance);
        }

        public ActionResult AttendanceInterface() {
            string sql = "select * from Students s inner join Student_Course sc on sc.StudentId=s.StudentId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Attendance().List(dt);

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            List<Staff> staffs = new List<Staff>();
            ViewBag.StaffId = new SelectList(staffs, "StaffId", "Name");
            List<Semester> sems = new List<Semester>();
            ViewBag.SemesterId = new SelectList(sems, "SemesterId", "Level");
            
            return View(model);
        }


    }
}
