using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Controllers
{
    public class loginController : Controller
    {
        //
        // GET: /login/

        public string loginmethod()
        {
            return "welcome to login";
        }

        public ActionResult login()
        {
            return View("login");
        }
    }
}
