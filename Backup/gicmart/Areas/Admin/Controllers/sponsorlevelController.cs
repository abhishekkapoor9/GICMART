using gicmart.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Areas.Admin.Controllers
{
    [SessionExpire]
    public class sponsorlevelController : Controller
    {
        //
        // GET: /Admin/sponsorlevel/

        public ActionResult Index()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Sponsor Level";
            return View();
        }

    }
}
