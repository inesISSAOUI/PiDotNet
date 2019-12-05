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

namespace test_web.Controllers
{
    public class lolsController : Controller
    {
        private Context db = new Context();

        // GET: lols
        public ActionResult Index()
        {
            return View(db.lols.ToList());
        }

        // GET: lols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lol lol = db.lols.Find(id);
            if (lol == null)
            {
                return HttpNotFound();
            }
            return View(lol);
        }

        // GET: lols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( lol lol)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/");
            //Client.PostAsJsonAsync("pidev-web/api/users", competance).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            lol x = new lol();
            lol.name = "x";
            HttpResponseMessage response = Client.PostAsJsonAsync<lol>("pidev-web/api/users/add", x).Result;
            System.Diagnostics.Debug.WriteLine("response :" + response);
            if (!response.IsSuccessStatusCode) { return RedirectToAction("Create"); }
            return RedirectToAction("Index");
        }

        // GET: lols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lol lol = db.lols.Find(id);
            if (lol == null)
            {
                return HttpNotFound();
            }
            return View(lol);
        }

        // POST: lols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] lol lol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lol);
        }

        // GET: lols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lol lol = db.lols.Find(id);
            if (lol == null)
            {
                return HttpNotFound();
            }
            return View(lol);
        }

        // POST: lols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lol lol = db.lols.Find(id);
            db.lols.Remove(lol);
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
