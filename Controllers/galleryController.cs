using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Controllers
{
    public class galleryController : Controller
    {
        //
        // GET: /gallery/

        public ActionResult gallery()
        {
            return View("gallery");
        }
        public string gallerymethod()
        {
            return "welcome to galery";
        }


    }
}
