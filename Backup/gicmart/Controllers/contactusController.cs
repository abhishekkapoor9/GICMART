﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.Mail;
using gicmart.Models;


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
        public ViewResult contactus(gicmart.Models.contactus obj)
        {  
            if (ModelState.IsValid) {  
                MailMessage mail = new MailMessage();  
                mail.To.Add("rk.singh9646@gmail.com");  
                mail.From = new MailAddress(obj.email);  
                mail.Subject = "enquery";  
                string Body = obj.message;  
                mail.Body = Body;  
                mail.IsBodyHtml = true;  
                SmtpClient smtp = new SmtpClient();  
                smtp.Host = "smtp.gmail.com";  
                smtp.Port = 587;  
                smtp.UseDefaultCredentials = false;  
                smtp.Credentials = new System.Net.NetworkCredential("rk.singh9646@gmail.com", "10904070"); // Enter seders User name and password  
                smtp.EnableSsl = true;  
                smtp.Send(mail);  
                return View("contactus", obj);  
            } else {  
                return View();  
            }  
        }  
    }
}
