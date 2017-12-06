using gicmart.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace gicmart.Areas.Admin.Controllers
{
    [SessionExpire]
    public class LogoutController : Controller
    {
        //
        // GET: /Admin/Logout/

        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

    }
}
