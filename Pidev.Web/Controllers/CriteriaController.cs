using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Advyteam.Models;
namespace Advyteam.Controllers
{
    public class CriteriaController : Controller
    {
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/criteria").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<criteriaModel>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(criteriaModel evm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");

            client.PostAsJsonAsync<criteriaModel>("api/criteria", evm).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return View();
        }
        


        
        public ActionResult Delete(int id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.DeleteAsync($"api/criteria/{id}").Result;
            System.Diagnostics.Debug.WriteLine("response :" + response);
            if (response.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index");
            }
            else
            return RedirectToAction("Index","CriteriaController"); 
        }



        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
                client.DeleteAsync($"api/criteria/{id}").ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}