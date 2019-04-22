﻿using System;
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
    public class FacultiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Faculties
        public ActionResult Index()
        {
            //return View(db.Faculties.ToList());
            String sql = "SELECT * from Faculties";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Faculty().List(dt);
            return View(model);
        }

        // GET: Faculties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Faculty faculty = db.Faculties.Find(id);
            String sql = "SELECT * from Faculties WHERE facultyid = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Faculty().List(dt).FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Faculties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyId,FacultyName,Description")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                // db.Faculties.Add(faculty);
                // db.SaveChanges();
                string sql = "INSERT INTO Faculties(FacultyName, Description) " +
                    "values( '" + faculty.FacultyName+ "', '" + faculty.Description+ "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Faculty faculty = db.Faculties.Find(id);
            String sql = "SELECT * from Faculties WHERE facultyid = " + id;
            db.List(sql);
            var dt = db.List(sql);
            var model = new Faculty().List(dt).FirstOrDefault();


            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyId,FacultyName,Description")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(faculty).State = EntityState.Modified;
                //db.SaveChanges();
                String sql = "Update Faculties set FacultyName='" + faculty.FacultyName + "', Description='" + faculty.Description + "   ' where facultyId = " + faculty.FacultyId;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Faculty faculty = db.Faculties.Find(id);
            //db.Faculties.Remove(faculty);
            //db.SaveChanges();
            String sql = "DELETE FROM faculties where facultyid = " + id;
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
