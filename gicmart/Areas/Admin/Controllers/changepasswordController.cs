using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.EntityClient;
using System.Data;
using gicmart.Models;

namespace gicmart.Areas.Admin.Controllers
{
    public class changepasswordController : Controller
    {
        //
        // GET: /Admin/changepassword/

        public ActionResult Index()
        {
            return View();
        }

    }
}
