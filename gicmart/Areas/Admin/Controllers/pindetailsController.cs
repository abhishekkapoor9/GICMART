using gicmart.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Areas.Admin.Controllers
{
    [SessionExpire]
    public class pindetailsController : Controller
    {
        //
        // GET: /Admin/pindetails/

        public ActionResult Index()
        {
            return View();
        }

    }
}
