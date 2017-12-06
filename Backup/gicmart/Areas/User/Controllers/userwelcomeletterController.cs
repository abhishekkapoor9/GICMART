using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using gicmart.Models;
using gicmart.Areas.Admin.Filters;

namespace gicmart.Areas.User.Controllers
{
    [SessionExpire]
    public class userwelcomeletterController : Controller
    {
        //
        // GET: /User/userwelcomeletter/

        public ActionResult Index()
        {
            SqlDataReader rdr = null;
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Welcome Letter";
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string usersp2 = "sp_welcomeletter";
            SqlCommand cmd4 = new SqlCommand(usersp2, con);
            cmd4.CommandType = CommandType.StoredProcedure;

            cmd4.Parameters.AddWithValue("@user_id", System.Web.HttpContext.Current.Session["userId"]);
            //cmd4.ExecuteNonQuery(); // MISSING
            //getting reference_user_Id
            try
            {
                rdr = cmd4.ExecuteReader();
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    ViewBag.id = rdr["user_id"].ToString();
                    ViewBag.Name = rdr["name"].ToString();
                    ViewBag.AssignedDate = rdr["assignedDate"].ToString();
                    ViewBag.sponsor_id = rdr["sponsor_id"].ToString();
                    ViewBag.password = rdr["user_pw"].ToString();
                }
               
            }
            catch (Exception e1)
            {
                //reference_user_id = null;
            }
            rdr.Close();
            return View();
        }

    }
}
