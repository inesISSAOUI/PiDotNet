using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test_data;
using test_Service;

namespace test_web.Controllers
{
    public class employesController : Controller
    {   
        private EmployeService emp = new EmployeService();
        private NiveauxMatService nm = new NiveauxMatService();
        private FicheMetierService fs = new FicheMetierService();
        private NiveauxFicheService nf = new NiveauxFicheService();
        private MatriceCompService mcs = new MatriceCompService();
        private Context db = new Context();

        // GET: employes
        
        public ActionResult Index()
        {  
            
            return View(emp.GetAllWith());
        }

        // GET: employes/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = emp.GetById(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: employes/Create
        static int ide=1;
      
        public ActionResult Create()
        {
            
            /*mcs.Add(matrice);
            mcs.Commit();*/
            ViewBag.ficheMetier_Id = new SelectList(fs.GetAll(), "Id", "category");
           
            return View();
        }

        // POST: employes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( employe employe)
        {
            if (ModelState.IsValid)
            {
                
                emp.Add(employe);
                emp.Commit();
                matricecomp matrice = new matricecomp();

                matrice.Description = "matrice " + employe.nom;
                matrice.ide = employe.Id;
                mcs.Add(matrice);
                mcs.Commit();
                int? ch = emp.GetById(employe.Id).ficheMetier_Id;
                foreach (var x in nf.GetAll().Where(f => f.fichemetier.Id == ch))
                {
                    niveauxmat niveau = new niveauxmat();
                    niveau.idComp = x.idComp;
                    niveau.idMat = matrice.Id;
                    niveau.Niveaux = x.Niveaux;
                    nm.Add(niveau);
                    nm.Commit();
                }


                employe.matriceComp_Id = matrice.Id;
                emp.Commit();

                
                return RedirectToAction("Index");
            }

            ViewBag.ficheMetier_Id = new SelectList(fs.GetAll(), "Id", "category", employe.ficheMetier_Id);
          
            return View(employe);
        }

        // GET: employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            ViewBag.ficheMetier_Id = new SelectList(db.fichemetiers, "Id", "category", employe.ficheMetier_Id);
            ViewBag.matriceComp_Id = new SelectList(db.matricecomps, "Id", "Description", employe.matriceComp_Id);
            return View(employe);
        }

        // POST: employes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( employe employe)
        {
            if (ModelState.IsValid)
            {
                emp.Update(employe);
                emp.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ficheMetier_Id = new SelectList(db.fichemetiers, "Id", "category", employe.ficheMetier_Id);
            ViewBag.matriceComp_Id = new SelectList(db.matricecomps, "Id", "Description", employe.matriceComp_Id);
            return View(employe);
        }

        // GET: employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(int id)
        {
            employe employe = db.employes.Find(id);
            db.employes.Remove(employe);
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
        public ActionResult VoirList(int id)
        {
           


            IEnumerable <niveauxmat> x= nm.GetAll().Where(s=>s.idMat==emp.GetById(id).matriceComp_Id);
            return View(x);
        }
        [Authorize(Roles = "employe")]
        public ActionResult employeProfil()
        {
            ViewBag.employe = emp.GetById(ide);
            Session["emp"]= emp.GetById(2);
            ViewBag.id = nm.GetAll().Where(s => s.idMat == emp.GetById(ide).matriceComp_Id).Count();
            return View();
        }
        public ActionResult ListComp()
        {
            
            return View(nm.GetAll().Where(s => s.idMat == emp.GetById(ide).matriceComp_Id));
        }
        public ActionResult demande()
        {

            return View();
        }
      
       public ActionResult VoirListeDemande() {
            return View(emp.GetAll().Where(x => x.demande == true));
        }
        public ActionResult Traiter(int id)
        {

            employe em = db.employes.Find(id);
            
            int niv;
           
            niveauxmat mat = new niveauxmat();
            
            if (em.grade=="debutant")
            {
               
                em.grade = "intermediare";
                db.Entry(em).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (em.grade == "intermediare"){
                em.grade = "expert";
                db.Entry(em).State = EntityState.Modified;
                db.SaveChanges();
            }

            else { return RedirectToAction("index"); }
            foreach (var x in nm.GetAll().Where(x=>x.matricecomp.Id==id))
            {
                System.Diagnostics.Debug.WriteLine(x.competance.type);
                if (x.competance.type == "coding" & em.title == "programmeur")
                {
                    niv = db.niveauxmats.Find(x.idComp, x.idMat).Niveaux;
                    mat = db.niveauxmats.Find(x.idComp, x.idMat);
                    mat.Niveaux = niv + 1;
                    db.Entry(mat).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (x.competance.type == "concept" & em.title == "concepteur")
                {
                    niv = db.niveauxmats.Find(x.idComp, x.idMat).Niveaux;
                    mat = db.niveauxmats.Find(x.idComp, x.idMat);
                    mat.Niveaux = niv + 1;
                    db.Entry(mat).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Index");
                        
                            }
            }

          /*  em.demande = false;
            db.Entry(em).State = EntityState.Modified;
            db.SaveChanges();*/
            return RedirectToAction("VoirListeDemande");


        }
        [HttpPost, ActionName("valider")]
        public ActionResult valider()
        {
            
            emp.GetById(ide).demande=true;
            emp.Commit();
            return RedirectToAction("employeProfil");
        }
        public ActionResult voirListDemande()
        {


            return View();
        }


    }
    
}
