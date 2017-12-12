using gicmart.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Areas.User.Controllers
{
    [SessionExpire]
    public class usersponsorlevelController : Controller
    {
        //
        // GET: /User/usersponsorlevel/

        public ActionResult Index()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "User Sponsor Level";
            return View();
        }

    }
}
