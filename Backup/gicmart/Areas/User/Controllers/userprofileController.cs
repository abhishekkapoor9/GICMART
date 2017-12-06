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
using gicmart.Areas.Admin.Filters;

namespace gicmart.Areas.User.Controllers
{
    [SessionExpire]
    public class userprofileController : Controller
    {
        //
        // GET: /User/userprofile/

        public ActionResult Index()
        {
            List<userprofile> imagelst = new List<userprofile>();
            SqlDataReader rdr = null;
            var profileinfo = new userprofile();

            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "User Profile";
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
                        userid = rdr["user_id"].ToString(),
                        pin = rdr["pin_no"].ToString(),
                        city = rdr["city"].ToString(),
                        pancardno = rdr["pancardno"].ToString(),
                        state = rdr["state"].ToString(),
                        nominee = rdr["nomineename"].ToString(),
                        address = rdr["address"].ToString(),
                        name = rdr["name"].ToString(),
                        mobileno = rdr["mobileno"].ToString(),
                        password = rdr["user_pw"].ToString(),
                        bankname = rdr["bankaccount"].ToString(),
                        accountno= rdr["accountno"].ToString(),
                        holdername= rdr["holdername"].ToString(),
                        ifsccode = rdr["ifsccode"].ToString(),

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
        [HttpPost]
        public ActionResult Index(userprofile model)
        {
            var profileinfo = new userprofile();
            SqlDataReader rdr = null;
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            try
            {
                    string usersp3 = "sp_isert_update_bankdetails";
                    SqlCommand cmd4 = new SqlCommand(usersp3, con);
                    cmd4.CommandType = CommandType.StoredProcedure;

                    cmd4.Parameters.AddWithValue("@user_id", System.Web.HttpContext.Current.Session["userId"]);
                    cmd4.Parameters.AddWithValue("@holdername", model.holdername);
                    cmd4.Parameters.AddWithValue("@accountno", model.accountno);
                    cmd4.Parameters.AddWithValue("@ifsccode", model.ifsccode);
                    cmd4.Parameters.AddWithValue("@bankaccount", model.bankname);
                    cmd4.ExecuteNonQuery(); // MISSING

                string usersp2 = "sp_ProfileInfo";
                SqlCommand cmd5 = new SqlCommand(usersp2, con);
                cmd5.CommandType = CommandType.StoredProcedure;

                cmd5.Parameters.AddWithValue("@empid", System.Web.HttpContext.Current.Session["userId"]);
                cmd5.ExecuteNonQuery(); // MISSING


                rdr = cmd5.ExecuteReader();
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    profileinfo = new userprofile
                    {
                        sponsorid = rdr["sponsor_id"].ToString(),
                        userid = rdr["user_id"].ToString(),
                        pin = rdr["pin_no"].ToString(),
                        city = rdr["city"].ToString(),
                        pancardno = rdr["pancardno"].ToString(),
                        state = rdr["state"].ToString(),
                        nominee = rdr["nomineename"].ToString(),
                        address = rdr["address"].ToString(),
                        name = rdr["name"].ToString(),
                        mobileno = rdr["mobileno"].ToString(),
                        password = rdr["user_pw"].ToString(),
                        bankname = rdr["bankaccount"].ToString(),
                        accountno = rdr["accountno"].ToString(),
                        holdername = rdr["holdername"].ToString(),
                        ifsccode = rdr["ifsccode"].ToString(),
                    };
                }
                rdr.Close();

                ViewBag.Message = "Suuccess";// MISSING
        }
            catch (Exception e1)
            {
                ViewBag.Message = "Fail";
            }
            return View(profileinfo);
        }
    } 
}

