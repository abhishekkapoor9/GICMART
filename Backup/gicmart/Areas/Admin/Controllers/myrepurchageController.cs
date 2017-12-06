using gicmart.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Areas.Admin.Controllers
{
    [SessionExpire]
    public class myrepurchageController : Controller
    {
        //
        // GET: /Admin/myrepurchage/

        public ActionResult Index()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "My Repurchage";
            return View();
        }

    }
}
