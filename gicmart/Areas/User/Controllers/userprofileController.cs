using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using gicmart.Models;
using gicmart.Areas.User.Models;

namespace gicmart.Areas.User.Controllers
{
    public class userprofileController : Controller
    {
        //
        // GET: /User/userprofile/

        public ActionResult Index()
        {
            List<userprofile> imagelst = new List<userprofile>();
            SqlDataReader rdr = null;
            var profileinfo =new userprofile();

            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Dashboard";
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string usersp2 = "sp_ProfileInfo";
            SqlCommand cmd4 = new SqlCommand(usersp2, con);
            cmd4.CommandType = CommandType.StoredProcedure;

            cmd4.Parameters.AddWithValue("@empid", System.Web.HttpContext.Current.Session["userId"]);
            //cmd4.ExecuteNonQuery(); // MISSING
            //getting reference_user_Id
            try
            {
                rdr = cmd4.ExecuteReader();
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    profileinfo = new userprofile
                    {
                        sponsorid = rdr["sponsor_id"].ToString(),
                        userid= rdr["user_id"].ToString(),
                        pin= rdr["pin_no"].ToString(),
                        city= rdr["city"].ToString(),
                        pancardno= rdr["pancardno"].ToString(),
                        state= rdr["state"].ToString(),
                        nominee = rdr["nomineename"].ToString(),
                        address= rdr["address"].ToString(),
                        name= rdr["name"].ToString(),
                        mobileno= rdr["mobileno"].ToString(),
                        password = rdr["user_pw"].ToString(),
                    };
                }
                rdr.Close();
            }
            catch (Exception e1)
            {
                //reference_user_id = null;
            }
           
            return View(profileinfo);
        }
    }

}

