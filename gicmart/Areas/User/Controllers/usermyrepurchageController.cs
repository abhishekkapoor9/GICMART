using gicmart.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Areas.User.Controllers
{
    [SessionExpire]
    public class usermyrepurchageController : Controller
    {
        //
        // GET: /User/usermyrepurchage/

        public ActionResult Index()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "User MyRepur";
            return View();
        }

    }
}
