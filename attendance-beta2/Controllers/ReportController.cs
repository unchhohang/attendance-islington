using attendance_beta2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace attendance_beta2.Controllers
{
    public class ReportController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Report
        public ActionResult DailyReport()
        {
            string sql = "SELECT A.*, S.StudentName FROM Attendances A JOIN Students S ON S.StudentId = A.StudentId ";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Report().GetReport(dt);
            
            ViewBag.Date = new SelectList(db.Attendances, "AttendanceId", "punchTime");
            return View(model);
        }
        //Post:Report
        [HttpPost]
        public ActionResult DailyReport(string reportType, string GivenDate)
        {
            if (reportType == "Daily")
            {

                string sql = "SELECT A.*, S.StudentName FROM Attendances A JOIN Students S ON S.StudentId = A.StudentId where A.punchTime >= '" + GivenDate + " 00:00:000" + "' AND A.punchTime < '" + GivenDate + " 23:00:000" + "'";
                db.List(sql);
                var dt = db.List(sql);
                var model = new Report().GetReport(dt);
                return View(model);
            }
            else if (reportType == "Weekly")
            {
                string sql = "SELECT A.*, S.StudentName FROM Attendances A JOIN Students S ON S.StudentId = A.StudentId where DATEPART(week, A.punchTime) = DATEPART(week, '"+ GivenDate +"')" +
                    "AND DATEPART(year, A.punchTime) = DATEPART(year, '" + GivenDate + "')";
                db.List(sql);
                var dt = db.List(sql);
                var model = new Report().GetReport(dt);
                return View(model);
            }
            else if (reportType == "Monthly")
            {
                string sql = "SELECT A.*, S.StudentName FROM Attendances A JOIN Students S ON S.StudentId = A.StudentId where DATEPART(month, A.punchTime) = DATEPART(month, '" + GivenDate + "')" +
                    "AND DATEPART(year, A.punchTime) = DATEPART(year, '" + GivenDate + "')";
                db.List(sql);
                var dt = db.List(sql);
                var model = new Report().GetReport(dt);
                return View(model);
            }

            return View();
        }

        public ActionResult weeklyReport()
        {

            return View();
        }

        public ActionResult monthlyReport()
        {

            return View();
        }
    }


}