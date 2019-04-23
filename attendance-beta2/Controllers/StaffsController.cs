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
    public class StaffsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Staffs
        public ActionResult Index()
        {
            //return View(db.Staffs.ToList());
            String sql = "SELECT * from Staffs";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Staff().List(dt);
            return View(model);
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Staff staff = db.Staffs.Find(id);
            String sql = "SELECT * from Staffs WHERE StaffId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Staff().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffId,Name,Contact,Address,Email")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                //db.Staffs.Add(staff);
                //db.SaveChanges();
                string sql = "INSERT INTO Staffs(Name, Contact, Address, Email) " +
                    "values( '" + staff.Name + "', '" + staff.Contact + "', '" + staff.Address + "', '"+ staff.Email + "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Staff staff = db.Staffs.Find(id);
            String sql = "SELECT * from Staffs WHERE StaffId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Staff().List(dt).FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffId,Name,Contact,Address,Email")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(staff).State = EntityState.Modified;
                //db.SaveChanges();
                String sql = "Update Staffs set Name='" + staff.Name + "', Contact='" + staff.Contact + "', Address='"+ staff.Address +"', Email = '"+staff.Email+"' where StaffId = " + staff.StaffId;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Staff staff = db.Staffs.Find(id);
            String sql = "SELECT * from Staffs WHERE staffId = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Staff().List(dt).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Staff staff = db.Staffs.Find(id);
            //db.Staffs.Remove(staff);
            //db.SaveChanges();
            String sql = "DELETE FROM Staffs where staffId = " + id;
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
