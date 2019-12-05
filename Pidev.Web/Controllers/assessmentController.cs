using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
<<<<<<< Updated upstream
using Advyteam.Models;
=======
using Services;
using Domain.Entities;
>>>>>>> Stashed changes

namespace Advyteam.Controllers
{
    public class assessmentController : Controller
    {
<<<<<<< Updated upstream
        private AdvyteamContext db = new AdvyteamContext();

        // GET: assessment
        public ActionResult Index()
        {
            var assessments = db.assessments.Include(a => a.employee);
            return View(assessments.ToList());
=======
        public AssessmentService AS;
        public EmployeeService ES;
        public AssessmentSelfService ASS;
        public assessmentself assessmentselfX;


        public assessmentController()
        {
            ASS = new AssessmentSelfService();
            AS = new AssessmentService();
            ES = new EmployeeService();

        }
        // GET: assessment
        public ActionResult Index()
        {
            var assessments = AS.GetAll();
            //ViewBag.result = assessments;
            return View(assessments);
>>>>>>> Stashed changes
        }

        // GET: assessment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
<<<<<<< Updated upstream
            assessment assessment = db.assessments.Find(id);
=======
            Domain.Entities.assessment assessment = AS.GetById( (int) id);
>>>>>>> Stashed changes
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

<<<<<<< Updated upstream
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
=======

        // GET: assessment/Create
        public ActionResult Create()
        {
            ViewBag.employee_idEmployee = new SelectList(ES.GetAll(), "idEmployee", "firstName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAssessment,done360,doneSelf,resultAssesment,scoreGlobal,type,employee_idEmployee")] Domain.Entities.assessment assessment)
        {
            if (ModelState.IsValid)
            {
                assessmentselfX = new assessmentself
                {
                    assessment_idAssessment = assessment.idAssessment,
                    assessment = assessment,
                    criteriasAgreed = true,
                    finalizedSelf = false
                };
                assessment.assessmentself.Add(assessmentselfX);
                
                ASS.Add(assessmentselfX);
                AS.Add(assessment);
                AS.Commit();

                //return RedirectToAction("CreateCriteriaScores",new {id = assessmentselfX.idSelf });
                return RedirectToAction("Index");
            }

            ViewBag.employee_idEmployee = new SelectList(ES.GetAll(), "idEmployee", "firstName", assessment.employee_idEmployee);            return View(assessment);
>>>>>>> Stashed changes
        }

        // GET: assessment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
<<<<<<< Updated upstream
            assessment assessment = db.assessments.Find(id);
=======
            assessment assessment = AS.GetById((int)id);
>>>>>>> Stashed changes
            if (assessment == null)
            {
                return HttpNotFound();
            }
<<<<<<< Updated upstream
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
=======
            ViewBag.employee_idEmployee = new SelectList(ES.GetAll(), "idEmployee", "firstName", assessment.employee_idEmployee);
            return View(assessment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,Domain.Entities.assessment assessment)
        {
            if (ModelState.IsValid)
            {
                Domain.Entities.assessment assessmentO = AS.GetById((int)id);
                assessmentO.done360 = assessment.done360;
                assessmentO.doneSelf = assessment.doneSelf;
                assessmentO.employee = assessment.employee;
                assessmentO.employee_idEmployee = assessment.employee_idEmployee;
                assessmentO.type = assessment.type;
                assessmentO.scoreGlobal = assessment.scoreGlobal;
                assessmentO.resultAssesment = assessment.resultAssesment;
                AS.Update(assessmentO);
                AS.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.employee_idEmployee = new SelectList(ES.GetAll(), "idEmployee", "firstName", assessment.employee_idEmployee);
            return View(assessment);
        }


>>>>>>> Stashed changes
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
<<<<<<< Updated upstream
            assessment assessment = db.assessments.Find(id);
=======
            Domain.Entities.assessment assessment = AS.GetById((int) id);
>>>>>>> Stashed changes
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

<<<<<<< Updated upstream
        // POST: assessment/Delete/5
=======

>>>>>>> Stashed changes
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
<<<<<<< Updated upstream
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
=======

            assessment assessment = AS.GetById((int)id);
            if (assessment.assessmentself.Count > 0)
            {
                assessmentself assessmentselfR = assessment.assessmentself.Single();
                int idSelf = assessmentselfR.idSelf;
                assessment.assessmentself.Remove(assessmentselfR);
                ASS.Delete(assessmentselfR);
                ASS.Commit();
            }
            
            AS.Delete(assessment);
            AS.Commit();
            

            return RedirectToAction("Index");
        }



        public ActionResult CreateForm(int? id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForm(int? id, [Bind(Include = "id,score1,score2,score3,score4,score5")] Advyteam.Models.CriteriasToAssess criteriasToAssess)
        {

            if (ModelState.IsValid)
            {
                assessmentselfX = AS.GetById((int)id).assessmentself.First();
                assessmentselfX.scoreSelf = criteriasToAssess.score1 + criteriasToAssess.score2 + criteriasToAssess.score3 + criteriasToAssess.score4 + criteriasToAssess.score5;
                assessmentselfX.finalizedSelf = true;
                assessmentselfX.assessment.doneSelf = true;
                if(assessmentselfX.assessment.done360)
                {
                    var x = assessmentselfX.assessment.scoreGlobal;
                    assessmentselfX.assessment.scoreGlobal = (int)( (x * 0.5) + (assessmentselfX.scoreSelf*0.5));
                }
                else
                {
                    assessmentselfX.assessment.scoreGlobal = assessmentselfX.scoreSelf;
                }
                AS.Commit();
                return RedirectToAction("Index");
            }

            return View(criteriasToAssess);
        }

        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assessment assessment = AS.GetById((int)id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_idEmployee = new SelectList(ES.GetAll(), "idEmployee", "firstName", assessment.employee_idEmployee);
            return View(assessment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2(int? id, assessment assessment)
        {
            if (ModelState.IsValid)
            {
                assessment assessmentO = AS.GetById((int)id);
                assessmentO.resultAssesment = assessment.resultAssesment;
                AS.Update(assessmentO);
                AS.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.employee_idEmployee = new SelectList(ES.GetAll(), "idEmployee", "firstName", assessment.employee_idEmployee);
            return View(assessment);
        }


        /*
        public ActionResult CreateCriteriaScores(int? id)
        {
            ViewBag.criteria = CS.GetAll();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCriteriaScores(int? id, IEnumerable<criteria> criteriascoreselfL)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                
                
                foreach (criteria item in criteriascoreselfL)
                {
                    criteriascoreself cs = new criteriascoreself();
                    cs.criteria = item;
                    ASS.GetById((int) id).criteriascoreself.Add(cs);
                }
                return RedirectToAction("Index");
            }

            ViewBag.criteria = CS.GetAll();
            return View();
        }
        */

>>>>>>> Stashed changes
    }
}
