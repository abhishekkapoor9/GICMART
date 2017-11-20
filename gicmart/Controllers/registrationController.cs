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
        public string role;
        public bool status;
        // GET: /registration/
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(users usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string usersp2 = "sp_checkforPinStatus";
                    SqlCommand cmd4 = new SqlCommand(usersp2, con);
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@pin_no", usr.pin);
                    SqlParameter parm2 = new SqlParameter("@status", SqlDbType.Bit);
                    parm2.Direction = ParameterDirection.Output;
                    cmd4.Parameters.Add(parm2);
                    cmd4.ExecuteNonQuery(); // MISSING
                    bool isActive =(bool)(parm2.Value);
                    if (isActive == true)
                    {
                        //getting reference_user_Id
                        SqlDataReader rdr = null;
                        int status = 0;
                        string reference_user_id = null;
                        string usersp9 = "sp_getUserId";
                        SqlCommand cmd9 = new SqlCommand(usersp9, con);
                        cmd9.CommandType = CommandType.StoredProcedure;
                        cmd9.Parameters.AddWithValue("@sponserId", usr.sponsorid);
                        try
                        {
                            rdr = cmd9.ExecuteReader();
                            // iterate through results, printing each to console
                            while (rdr.Read())
                            {
                                reference_user_id = rdr["user_id"].ToString();
                            }
                        }
                        catch (Exception e1)
                        {
                            reference_user_id = null;
                        }
                        rdr.Close();
                        //getting user_id
                        string usersp = "user_sp";
                        SqlCommand cmd1 = new SqlCommand(usersp, con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@user_name", usr.userid);
                        cmd1.Parameters.AddWithValue("@role", "user");
                        cmd1.Parameters.AddWithValue("@user_pw", usr.password);
                        cmd1.Parameters.AddWithValue("@referenced_user_id", reference_user_id);
                        SqlParameter parm = new SqlParameter("@user_ids", SqlDbType.NVarChar, 50);
                        parm.Direction = ParameterDirection.Output;
                        cmd1.Parameters.Add(parm);
                        cmd1.ExecuteNonQuery(); // MISSING
                        string userId = parm.Value.ToString();
                        userId = "ESI" + userId;
                        //getting user details
                        string registersp = "registration_sp";
                        SqlCommand cmd = new SqlCommand(registersp, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", userId);
                        cmd.Parameters.AddWithValue("@address", usr.address);
                        cmd.Parameters.AddWithValue("@password", usr.password);
                        cmd.Parameters.AddWithValue("@name", usr.name);
                        cmd.Parameters.AddWithValue("@nomineename", usr.nomineename);
                        cmd.Parameters.AddWithValue("@state", usr.state);
                        cmd.Parameters.AddWithValue("@city", usr.city);
                        cmd.Parameters.AddWithValue("@pancardno", usr.pancardno);
                        cmd.Parameters.AddWithValue("@mobileno", usr.mobileno);
                        int wq = cmd.ExecuteNonQuery();
<<<<<<< HEAD
                        // getting SponserId
=======


                        // getting PinId

>>>>>>> 496e80296dd94a79f68d24807e71c8a53a9f5694
                        string pinsp = "pin_sp";
                        SqlCommand cmd11 = new SqlCommand(pinsp, con);
                        SqlParameter parm1 = new SqlParameter("@pin_no", SqlDbType.NVarChar, 50);
                        parm1.Direction = ParameterDirection.Output;
                        cmd11.Parameters.Add(parm1);
                        cmd11.CommandType = CommandType.StoredProcedure;
                        cmd11.ExecuteNonQuery(); // MISSING
                        string pinNo = parm1.Value.ToString();
                        pinNo = "PNI" + pinNo;

                        //For User Sponser
                        string userspn = "user_sponsor_sp";
                        SqlCommand cmd2 = new SqlCommand(userspn, con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@user_id", userId);
                        cmd2.Parameters.AddWithValue("@sponsor_id", usr.sponsorid);
                        cmd2.Parameters.AddWithValue("@pin_no", pinNo);
                        int w = cmd2.ExecuteNonQuery();
<<<<<<< HEAD
=======

                        //For Update Pin
>>>>>>> 496e80296dd94a79f68d24807e71c8a53a9f5694
                        string updatePin  = "sp_updatePinNo";
                        SqlCommand cmd8 = new SqlCommand(updatePin, con);
                        cmd8.CommandType = CommandType.StoredProcedure;
                        cmd8.Parameters.AddWithValue("@pin_No", usr.pin);
                        int w9 = cmd8.ExecuteNonQuery();
<<<<<<< HEAD
=======

                        string userPin = "sp_setuserpin";
                        SqlCommand cmd10 = new SqlCommand(userPin, con);
                        cmd10.CommandType = CommandType.StoredProcedure;
                        cmd10.Parameters.AddWithValue("@updatedpin_no", usr.pin);
                        cmd10.Parameters.AddWithValue("@userdId", userId);
                        cmd10.Parameters.AddWithValue("@pin_no", pinNo);

                        int w10 = cmd10.ExecuteNonQuery();

>>>>>>> 496e80296dd94a79f68d24807e71c8a53a9f5694
                        ViewBag.Message = "Success";
                        con.Close();
                        usr = null;                    }
                    else
                    {
                        ViewBag.Pin = "Fail";
                    }
                }
                else
                {
                    ViewBag.Message = "Fail";
                }
            }
            catch (Exception e1)
            {
                ViewBag.Message = "Fail";    
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                //getting pin_no
                string pinsp = "pin_sp";
                SqlCommand cmd1 = new SqlCommand(pinsp, con);
                SqlParameter parm1 = new SqlParameter("@pin_no", SqlDbType.NVarChar,50);
                parm1.Direction = ParameterDirection.Output;
                cmd1.Parameters.Add(parm1);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.ExecuteNonQuery(); // MISSING
                string retunvalue1 = parm1.Value.ToString();
                //getting user_id
                string usersp = "user_sp";
                SqlCommand cmd2 = new SqlCommand(usersp, con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@password", usr.password);
                cmd2.Parameters.AddWithValue("@name", usr.name);
                cmd2.Parameters.AddWithValue("@role", "user");
                SqlParameter parm2 = new SqlParameter("@user_id", SqlDbType.NVarChar, 50);
                parm2.Direction = ParameterDirection.Output;
                cmd2.Parameters.Add(parm2);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.ExecuteNonQuery(); // MISSING
                string retunvalue2 = parm2.Value.ToString();
                //getting sponsor_id
                string sponsorsp = "sponsor_sp";
                SqlCommand cmd3 = new SqlCommand(sponsorsp, con);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@sponsorname", usr.sponsorname);
                int spi = cmd3.ExecuteNonQuery();
                //getting user details
                string registersp = "registration_sp";
                SqlCommand cmd = new SqlCommand(registersp, con);
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
        [HttpPost]
        public JsonResult GetPinStatus(string pinId)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            int status = 0;
            bool isActive = false;
            string usersp2 = "sp_checkforPinStatus";
            SqlCommand cmd4 = new SqlCommand(usersp2, con);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@pin_no", pinId);
            SqlParameter parm2 = new SqlParameter("@status", SqlDbType.Bit);
            parm2.Direction = ParameterDirection.Output;
            cmd4.Parameters.Add(parm2);
            cmd4.ExecuteNonQuery(); // MISSINz
            try
            {
                isActive = (bool)(parm2.Value);
            }
            catch(Exception )
            {

            }
            if(isActive==true)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
           
            var data = new
            {
               Finalstatus=status
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetSponsorName(string sponsorId)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlDataReader rdr = null;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            int status = 0;
            string sponserName=null;
            string usersp2 = "sp_getSponserName";
            SqlCommand cmd4 = new SqlCommand(usersp2, con);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@sponserId", sponsorId);
            try
            {
                rdr = cmd4.ExecuteReader();
                while (rdr.Read())
                {
                    sponserName= rdr["sponsor_name"].ToString();
                }
            }
            catch (Exception e1)
            {
                sponserName = null;
            }
            rdr.Close();
            var data = new
            {
                SpoinserName = sponserName
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
