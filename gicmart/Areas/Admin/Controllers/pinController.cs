using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Areas.Admin.Controllers
{
    public class pinController : Controller
    {
        //
        // GET: /Admin/pin/

        public ActionResult newPin()
        {
            return View();
        }

    }
}
