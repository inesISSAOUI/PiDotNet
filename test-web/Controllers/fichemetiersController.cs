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
    public class fichemetiersController : Controller
    {
        private FicheMetierService fs = new FicheMetierService();
        private Context db = new Context();

        // GET: fichemetiers
        public ActionResult Index()
        {
            return View(fs.GetAll());
        }

        // GET: fichemetiers/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fichemetier fichemetier = fs.GetById(id);
            if (fichemetier == null)
            {
                return HttpNotFound();
            }
            return View(fichemetier);
        }

        // GET: fichemetiers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fichemetiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fichemetier fichemetier)
        {
            if (ModelState.IsValid)
            {
                fs.Add(fichemetier);
                fs.Commit();
                return RedirectToAction("Index");
            }

            return View(fichemetier);
        }

        // GET: fichemetiers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fichemetier fichemetier = fs.GetById(id);
            if (fichemetier == null)
            {
                return HttpNotFound();
            }
            return View(fichemetier);
        }

        // POST: fichemetiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( fichemetier fichemetier)
        {
            if (ModelState.IsValid)
            {
                fs.Update(fichemetier);
                fs.Commit();
                return RedirectToAction("Index");
            }
            return View(fichemetier);
        }

        // GET: fichemetiers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fichemetier fichemetier = fs.GetById(id);
            if (fichemetier == null)
            {
                return HttpNotFound();
            }
            return View(fichemetier);
        }

        // POST: fichemetiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fichemetier fichemetier = fs.GetById(id);
            fs.Delete(fichemetier);
            fs.Commit();
            return RedirectToAction("Index");
        }

       
    }
}
