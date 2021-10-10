using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using System.Net;
using System.Net.Mail;
using FitnessConsultancyv4.Models;
namespace FitnessConsultancyv4.Controllers
{
    public class NewsLetterController : Controller
    {

        private Entities db = new Entities();

        // GET: NewsLetter
        public ActionResult Index()
        {
            
            return View();
        }

       public ActionResult SendBulkEmail()
        {
            ViewBag.users = db.AspNetUsers;
            return View();
        }


        [HttpPost]
        public ActionResult SendBulkEmail(HttpPostedFileBase fileUploader, string[] emails)
        {
            MailAddressCollection collection = new MailAddressCollection();
            foreach (var mail in emails)
            {
                collection.Add(mail);
            }
            // collection.Add("sagarkudale2014.sk@gmail.com");
            // collection.Add("nitinpune2000@gmail.com");
            foreach (var item in collection)
            {
                var to = item;
                var to_1 = Convert.ToString(to);
                if (ModelState.IsValid)
                {
                    string from = "siddhivinayakkudale@gmail.com"; //example:- sourabh9303@gmail.com
                    //var message = new MailMessage(from, to);
                    using (MailMessage mail = new MailMessage(from, to_1))
                    {
                       // mail.Subject = objModelMail.Subject;
                       // mail.Body = objModelMail.Body;
                        if (fileUploader != null)
                        {
                            string fileName = Path.GetFileName(fileUploader.FileName);
                            mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                        }
                        mail.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCredential = new NetworkCredential(from, "#Sagar123");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 587;
                        smtp.Send(mail);
                        TempData["AlertMessage"] = "Mail Send!!!";

                        //ViewBag.Message = "Sent";
                        //return View("Index", objModelMail);
                    }
                }
                else
                {
                    //return View();
                }
            }
           return RedirectToAction("SendBulkEmail","NewsLetter");
        }




    }
}