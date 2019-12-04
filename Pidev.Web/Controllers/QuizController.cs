using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using Pidev.Domaine.Entities;
using Pidev.Service;
using Rotativa.MVC;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Pidev.Web.Controllers
{
    public class QuizController : Controller
    {
        QuizService Ps;
        QuestionService Pv = new QuestionService();
        public QuizController()
        {
            Ps = new QuizService();

        }

        // GET: Quiz
        public ActionResult Index()
        {
            return View(Ps.GetMany());
        }
        public ActionResult Indexmelcreate()
        {
            return View(Ps.GetMany());
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult CreateQuiz(int id)
        {
            Quiz pe = new Quiz();

            pe.FormationId = id;
            pe.Score = 0;
            pe.Type = "En cours";
            Ps.Add(pe);
            Ps.Commit();
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("carrozzeria@splendorsrl.it"));
            message1.To.Add(new MailboxAddress("anas.abdelkafi@esprit.tn"));
            message1.Subject = "Application";
            message1.Body = new TextPart("plain")
            {

                Text = "Dear Employe, \nYour Quiz has been successfully registered on " + DateTime.Now + ". We will come back to you to indicate the date of the interview and the quiz. \n Best regards."
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH");
                client.Authenticate("carrozzeria@splendorsrl.it", "At066bn1!");
                client.Send(message1);
                client.Disconnect(true);
            }
           // Use your account SID and authentication token instead
            // of the placeholders shown here.
            const string accountSID = "AC112bf29cc2ba0b15cd7ea143a03ec786";
            const string authToken = "fc2060027600fdb5558b01670e6a2e39";

            // Initialize the TwilioClient.
            TwilioClient.Init(accountSID, authToken);

            // Use the Twilio-provided site for the TwiML response.
            var url = "https://twimlets.com/message";
            url = $"{url}?Message%5B0%5D=Hello%20World";


            try
            {
                // Send an SMS message.
                var message = MessageResource.Create(
                    to: new PhoneNumber("+21621646533"),
                    from: new PhoneNumber("+14243659381"),
                     body: "Your application has been validated successfully \nThe " + DateTime.Now + "\n We will come back to you in order to pass your quiz \n Best regards.");
            }
            catch (TwilioException ex)
            {
                // An exception occurred making the REST call
                Console.WriteLine(ex.Message);
            }
            
            return RedirectToAction("Index");
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }




        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            Quiz p;
            p = Ps.GetById(id);
            Ps.Delete(p);
            Ps.Commit();
            return RedirectToAction("Index");
        }

        // POST: Quiz/Delete/5
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
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = Ps.GetMany();


            // recherche
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.Type.ToString().Equals(filtre)).ToList();
            }

            return View(list);



        }
           public ActionResult Export()
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
       
    }


