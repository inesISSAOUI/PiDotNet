using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pidev.Domaine.Entities;
using Pidev.Service;

namespace Pidev.Web.Controllers
{
    public class QuestionController : Controller
    {
        QuestionService Ps = new QuestionService();
        FormationService Pa = new FormationService(); 
        QuizService Pq = new QuizService();
        // GET: Question(
        public ActionResult Index()
        {
            return View(Ps.GetMany());
        }
        // GET: Question
        public ActionResult PasserQuiz(int id)
        {
            var listformation = Pa.GetMany();
            var listquiz = Pq.GetMany();
            var listquestion = Ps.GetMany();

            Quiz q = new Quiz();
            // recherche

         /*   listformation = listformation.Where(m => m.CandidatId == id).ToList();
            foreach (var item in listapplication)
            {
                a.ApplicationId = item.ApplicationId;
                a.CandidatId = id;
                a.OfferId = item.OfferId;
            }*/
            listquiz = listquiz.Where(m => m.QuizId == id).ToList();
            foreach (var item1 in listquiz)
            {
                q.FormationId = item1.FormationId;
                q.QuizId = id;
                q.Score = item1.Score;

            }

            listquestion = listquestion.Where(m => m.QuizId == q.QuizId).ToList();
            if (q.Score > 0)
                return RedirectToAction("../Quiz/Index");
            return View(listquestion);


            //return View(Ps.GetMany());
        }

        public ActionResult ValiderQuiz(FormCollection collection)
        {
            int o = int.Parse(collection["ido"].ToString());
            string c = "";
            string c1 = "";
            string c2 = "";
            string c3 = "";
            string quizzradio = "";
            string quizzradio1 = "";
            string quizzradio2 = "";
            string quizzradio3 = "";
            int i = 0;
            int j = 1;
            var listquestion = Ps.GetMany();
            listquestion = listquestion.Where(m => m.QuizId == o).ToList();
            foreach (var item1 in listquestion)
            {
                if (i == 0)
                {
                    c = item1.QuestionCorrectAnswer;
                    quizzradio = collection["response" + j].ToString();
                }
                if (i == 1)
                {
                    c1 = item1.QuestionCorrectAnswer;
                    quizzradio1 = collection["response" + j].ToString();
                }
                if (i == 2)
                {
                    c2 = item1.QuestionCorrectAnswer;
                    quizzradio2 = collection["response" + j].ToString();
                }
                if (i == 3)
                {
                    c3 = item1.QuestionCorrectAnswer;
                    quizzradio3 = collection["response" + j].ToString();
                }
                i++;
                j++;
            }


            int score = 0;
            if (quizzradio == c)
                score += 5;
            if (quizzradio1 == c1)
                score += 5;
            if (quizzradio2 == c2)
                score += 5;
            if (quizzradio3 == c3)
                score += 5;
            Quiz pn;
            pn = Pq.GetById(o);

            pn.Score = score;
            if (score >= 10)
            { pn.Type = "Valider"; }
            else
            {
                pn.Type = "Refuser";
            }
            Pq.Update(pn);
            Pq.Commit();
            Question p;
            foreach (var item1 in listquestion)
            {
                p = item1;
                Ps.Delete(p);
                Ps.Commit();
            }
            return RedirectToAction("../Quiz/Index");
            //  return View();

        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create/5
        public ActionResult Create(int id)
        {
            var applications = Ps.GetMany();
            ViewBag.CategoryId = new SelectList(applications, "QuestionId");
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(int id, Question q)
        {
            Question p = new Question();
            p.QuizId = id;
            p.QuestionDescription = q.QuestionDescription;
            p.Question1stSuggestion = q.Question1stSuggestion;
            p.Question2ndSuggestion = q.Question2ndSuggestion;
            p.Question3rdSuggestion = q.Question3rdSuggestion;
            p.QuestionCorrectAnswer = q.QuestionCorrectAnswer;
            Ps.Add(p);
            Ps.Commit();
            return RedirectToAction("Index");
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {

            return View(Ps.GetById(id));
        }


        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question p)
        {
            Question pn;
            pn = Ps.GetById(id);
            pn.Question1stSuggestion = p.Question1stSuggestion;
            pn.Question2ndSuggestion = p.Question2ndSuggestion;
            pn.Question3rdSuggestion = p.Question3rdSuggestion;
            pn.QuestionCorrectAnswer = p.QuestionCorrectAnswer;
            pn.QuestionDescription = p.QuestionDescription;
            Ps.Update(pn);
            Ps.Commit();

            return RedirectToAction("Index");

        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            Question p;
            p = Ps.GetById(id);
            Ps.Delete(p);
            Ps.Commit();
            return RedirectToAction("Index");
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /* public ActionResult Export()
         {
             return new ActionAsPdf("Index")
             {
                 FileName = Server.MapPath("~/Content/PDF/Liste.pdf")
             };
         }
         public ActionResult Statistique()
         {
             return View(Ps.GetMany());
         }

     }
     */
    }

}
