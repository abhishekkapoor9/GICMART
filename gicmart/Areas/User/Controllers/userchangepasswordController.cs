using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using gicmart.Models;
using gicmart.Areas.User.Filters;
using gicmart.Areas.User.Models;

namespace gicmart.Areas.User.Controllers
{
    [SessionExpire]
    public class userchangepasswordController : Controller
    {
        //
        // GET: /User/userchangepassword/

        public ActionResult Index()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Change Password";
            return View();
        }

        [HttpPost]
        public ActionResult Index(changePassword model)
        {
            if (ModelState.IsValid)
            {
                SqlDataReader rdr = null;
                int changes = 0;
                TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
                TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string usersp2 = "sp_updatePasswrd";
                SqlCommand cmd4 = new SqlCommand(usersp2, con);
                cmd4.CommandType = CommandType.StoredProcedure;

                cmd4.Parameters.AddWithValue("@user_id", System.Web.HttpContext.Current.Session["userId"]);
                cmd4.Parameters.AddWithValue("@user_pw", model.changePass);
                cmd4.Parameters.AddWithValue("@user_old", model.oldPass);
                //cmd4.ExecuteNonQuery(); // MISSING
                //getting reference_user_Id
                try
                {
                    rdr = cmd4.ExecuteReader();
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        changes = Convert.ToInt32(rdr["Table1"].ToString());
                    }
                    if (changes == 1)
                    {
                        ViewBag.Message = "Success";
                    }
                    else
                    {
                        ViewBag.Message = "Fail";
                    }
                    rdr.Close();
                }
                catch (Exception e1)
                {
                    ViewBag.Message = "Fail";
                }
            } 
            else
            {
                ViewBag.Message = "Password";

            }
           
            return View();
        }
    }
}
