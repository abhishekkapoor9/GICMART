using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.EntityClient;
using System.Data;
using gicmart.Models;
using gicmart.Areas.Admin.Filters;

namespace gicmart.Areas.Admin.Controllers
{
    [SessionExpire]
    public class changepasswordController : Controller
    {
        //
        // GET: /Admin/changepassword/

        public ActionResult Index()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Change Password";
            return View();
        }

    }
}
