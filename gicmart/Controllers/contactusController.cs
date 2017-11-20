using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.Mail;



namespace gicmart.Controllers
{
    public class contactusController : Controller
    {
      
        //
        // GET: /contact us/

        public ActionResult contactusmethod()
        {
            return View();
        }
        public ActionResult contactus()
        {
            return View("contactus");
        }
         [HttpPost]  
        public ViewResult contactus(gicmart.Models.contactus obj) {  
            if (ModelState.IsValid) {  
                //MailMessage mail = new MailMessage();  
                //mail.To.Add(obj.To);  
                //mail.From = new MailAddress(obj.From);  
                //mail.Subject = obj.Subject;  
                //string Body = obj.Body;  
                //mail.Body = Body;  
                //mail.IsBodyHtml = true;  
                //SmtpClient smtp = new SmtpClient();  
                //smtp.Host = "smtp.gmail.com";  
                //smtp.Port = 587;  
                //smtp.UseDefaultCredentials = false;  
                //smtp.Credentials = new System.Net.NetworkCredential("rk.singh9646@gmail.com", "10904070"); // Enter seders User name and password  
                //smtp.EnableSsl = true;  
                //smtp.Send(mail);  
                return View("contactus", obj);  
            } else {  
                return View();  
            }  
        }  
    }
}
