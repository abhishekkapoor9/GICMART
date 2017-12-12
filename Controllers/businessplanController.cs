using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Controllers
{
    public class businessplanController : Controller
    {
        //
        // GET: /businessplan/

        public string businessplanmethod()
        {
        
           
            return "welcome";
        }
        public ActionResult mybusinessplan()
        {
            return View("mybusinessplan");
        }

    }
}
