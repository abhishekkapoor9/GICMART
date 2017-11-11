using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Controllers
{
    public class contactusController : Controller
    {
        //
        // GET: /contact us/

        public string contactusmethod()
        {
            return "welcome to contact us";
        }
        public ActionResult contactus()
        {
            return View("contactus");
        }
    }
}
