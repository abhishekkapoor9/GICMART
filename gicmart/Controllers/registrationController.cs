using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Controllers
{
    public class registrationController : Controller
    {
        //
        // GET: /registration/

        public string registrationmethod()
        {
            return "welcome to registration ";
        }
        public ActionResult registration()
        {
            return View("registration");
        }

    }
}
