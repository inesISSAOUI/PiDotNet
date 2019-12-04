using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Advyteam.Models;

namespace Advyteam.Controllers
{
    public class assessmentController : Controller
    {
        private AdvyteamContext db = new AdvyteamContext();

        // GET: assessment
        public ActionResult Index()
        {
            var assessments = db.assessments.Include(a => a.employee);
            return View(assessments.ToList());
        }

        // GET: assessment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assessment assessment = db.assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

        // GET: assessment/Create
        public ActionResult Create()
        {
            ViewBag.employee_idEmployee = new SelectList(db.employees, "idEmployee", "firstName");
            return View();
        }

        // POST: assessment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAssessment,done360,doneSelf,resultAssesment,scoreGlobal,type,employee_idEmployee")] assessment assessment)
        {
            if (ModelState.IsValid)
            {
                db.assessments.Add(assessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee_idEmployee = new SelectList(db.employees, "idEmployee", "firstName", assessment.employee_idEmployee);
            return View(assessment);
        }

        // GET: assessment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assessment assessment = db.assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_idEmployee = new SelectList(db.employees, "idEmployee", "firstName", assessment.employee_idEmployee);
            return View(assessment);
        }

        // POST: assessment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAssessment,done360,doneSelf,resultAssesment,scoreGlobal,type,employee_idEmployee")] assessment assessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_idEmployee = new SelectList(db.employees, "idEmployee", "firstName", assessment.employee_idEmployee);
            return View(assessment);
        }

        // GET: assessment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assessment assessment = db.assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

        // POST: assessment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            assessment assessment = db.assessments.Find(id);
            db.assessments.Remove(assessment);
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
