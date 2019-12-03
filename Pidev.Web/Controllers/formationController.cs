using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Pidev.Data;

namespace Pidev.Web.Controllers
{
    public class formationController : Controller
    {
        // GET: formation
        public ActionResult affpart()
        {
            HttpClient Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/api/formations").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<formation>>().Result;

            }
            else
            {
                ViewBag.result = "error";

            }


            return View();
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/pidev-web/api/formations/" + id.ToString()).Result;

            return RedirectToAction("affpart");
        }
        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            return View();

        }
    }
}