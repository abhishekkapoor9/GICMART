using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using gicmart.Models;

namespace gicmart.Controllers
{
    public class registrationController : Controller
    {
        //
        // GET: /registration/
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register( users usr)
        {
            if (ModelState.IsValid)
            {
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sp = "registration_sp";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", usr.userid);
                cmd.Parameters.AddWithValue("@address", usr.address);
                cmd.Parameters.AddWithValue("@password", usr.password);
                cmd.Parameters.AddWithValue("@sponsorid", usr.sponsorid);
                cmd.Parameters.AddWithValue("@sponsorname", usr.sponsorname);
                cmd.Parameters.AddWithValue("@pin",usr.pin);
                cmd.Parameters.AddWithValue("@name", usr.name);
                cmd.Parameters.AddWithValue("@nomineename", usr.nomineename);
                cmd.Parameters.AddWithValue("@state", usr.state);
                cmd.Parameters.AddWithValue("@city", usr.city);
                cmd.Parameters.AddWithValue("@pancardno", usr.pancardno);
                cmd.Parameters.AddWithValue("@mobileno", usr.mobileno);
                cmd.Parameters.AddWithValue("@terandcontion", usr.termandcondition);
                int wq = cmd.ExecuteNonQuery();
                ViewBag.Message = string.Format("data inserted successfull");
                con.Close();
            }
            return View(usr);
        }
    }
}
