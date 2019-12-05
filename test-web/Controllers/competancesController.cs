using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using test_data;
using test_Service;
namespace test_web.Controllers
{
    public class competancesController : Controller
    {
        CompetanceService cs = new CompetanceService();
       

        // GET: competances
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("pidev-web/api/users/all").Result;

            if (response.IsSuccessStatusCode)
            {

                 ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Competance>>().Result;
            }

            else
            {
                 ViewBag.result = "error";
            }
                return View();
        }

        // GET: competances/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competance competance = cs.GetById(id);
            if (competance == null)
            {
                return HttpNotFound();
            }
            return View(competance);
        }

        // GET: competances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: competances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Competance competance)
        {

            if (ModelState.IsValid)
            {
                cs.Add(competance);
                cs.Commit();
                return RedirectToAction("Index");
            }

            return View(competance);
        

    }

        // GET: competances/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competance competance = cs.GetById(id);
            if (competance == null)
            {
                return HttpNotFound();
            }
            return View(competance);
        }

        // POST: competances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Competance competance)
        {
            if (ModelState.IsValid)
            {
                cs.Update(competance);
                cs.Commit();
                return RedirectToAction("Index");
            }
            return View(competance);
        }

        // GET: competances/Delete/5
       
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competance competance = cs.GetById(id);
            if (competance == null)
            {
                return HttpNotFound();
            }
            return View(competance);
        }

        // POST: competances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("pidev-web/api/users/del?id=" + id).Result;
            
           /* Competance competance = db.competances.Find(id);
            db.competances.Remove(competance);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }

        
    }
}
