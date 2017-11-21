using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace gicmart.Areas.User.Controllers
{
    public class userprofileController : Controller
    {
        //
        // GET: /User/userprofile/

        public ActionResult Index()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Profile";
            return View();
        }

    }
}
