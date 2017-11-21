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

namespace gicmart.Areas.Admin.Controllers
{
    public class dashboardController : Controller
    {
        public class images
        {
            public string name { get; set; }
            public string id { get; set; }
            public string joindate { get; set; }
        }
        //
        // GET: /Admin/dashboard/
        [SessionExpire]
        public ActionResult Index()
        {
            List<images> imagelst = new List<images>();
            SqlDataReader rdr = null;
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Dashboard";
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string usersp2 = "sp_getclientList";
            SqlCommand cmd4 = new SqlCommand(usersp2, con);
            cmd4.CommandType = CommandType.StoredProcedure;
            
            cmd4.Parameters.AddWithValue("@empid", System.Web.HttpContext.Current.Session["userId"]);
            cmd4.Parameters.AddWithValue("@assigneddatetime", Convert.ToDateTime(System.Web.HttpContext.Current.Session["joindate"]));
            cmd4.ExecuteNonQuery(); // MISSING
                                    //getting reference_user_Id
            try
            {
                rdr = cmd4.ExecuteReader();
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    imagelst.Add(new images
                    {
                        id = rdr["[user_id]"].ToString(),
                        name = rdr["[name]"].ToString(),
                        joindate = rdr["[assignedDate]"].ToString()

                    });
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
