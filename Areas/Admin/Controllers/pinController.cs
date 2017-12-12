using gicmart.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gicmart.Areas.Admin.Controllers
{
    [SessionExpire]
    public class pinclass
    {
        public string sno { get; set; }
        public string pinNo { get; set; }
        public string assignedDate { get; set; }
    } 
    public class pinController : Controller
    {
        //
        // GET: /Admin/pin/

        public ActionResult newPin()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Generate Pin";
            return View();
        }
        [HttpPost]
        public JsonResult GetPinNo()
        {

            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string pinsp = "pin_sp";
            SqlCommand cmd11 = new SqlCommand(pinsp, con);
            SqlParameter parm1 = new SqlParameter("@pin_no", SqlDbType.NVarChar, 50);
            parm1.Direction = ParameterDirection.Output;
            cmd11.Parameters.Add(parm1);
            cmd11.CommandType = CommandType.StoredProcedure;
            cmd11.ExecuteNonQuery(); // MISSING
            string pinNo = parm1.Value.ToString();
            pinNo = "PNI" + pinNo;

            string userPin = "sp_setuserpin";
            SqlCommand cmd10 = new SqlCommand(userPin, con);
            cmd10.CommandType = CommandType.StoredProcedure;
            cmd10.Parameters.AddWithValue("@updatedpin_no", "testing");
            cmd10.Parameters.AddWithValue("@userdId", System.Web.HttpContext.Current.Session["userId"]);
            cmd10.Parameters.AddWithValue("@pin_no", pinNo);

            int w10 = cmd10.ExecuteNonQuery();
            return Json(pinNo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPin(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            List<pinclass> pinClass = new List<pinclass>();
            //EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            //var Cardslist = (from cards in entity.Card1
            //                 join packages in entity.Packages
            //                 on cards.PackagesId equals packages.PackagesId
            //                 where cards.Activate == true
            //                 select new { cards, packages }).AsEnumerable().Select(row => new
            //                 {
            //                     CardId = row.cards.CardId,
            //                     CardName = row.cards.CardName,
            //                     ValidFrom = Convert.ToDateTime(row.cards.ValidFrom).ToString("yyyy-MM-dd"),
            //                     ValidTo = Convert.ToDateTime(row.cards.ValidTo).ToString("yyyy-MM-dd"),
            //                     discountPer = row.cards.discountPer,
            //                     Activate = (row.cards.Activate == true) ? "Activate" : "Deactivate",
            //                     PackageName = row.packages.PackageName
            //                 })
            SqlDataReader rdr = null;
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string pinsp = "user_pin_sp";
            SqlCommand cmd11 = new SqlCommand(pinsp, con);
            cmd11.Parameters.AddWithValue("@user_id", System.Web.HttpContext.Current.Session["userId"]);
            cmd11.CommandType = CommandType.StoredProcedure;
            try
            {
                rdr = cmd11.ExecuteReader();
                while (rdr.Read())
                {
                    pinClass.Add(new pinclass
                    {
                        sno= rdr["userpinId"].ToString(),
                        pinNo = rdr["pin_no"].ToString(),
                        assignedDate = rdr["assignedDate"].ToString()
                    });
                }
            }
            catch(Exception e1) { }
            //string pinNo = parm1.Value.ToString();
            //pinNo = "PNI" + pinNo;
            int totalRecords = pinClass.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = pinClass
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult usedPin()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "Used Pin";
            return View();
        }

        public JsonResult GetusedPin(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            List<pinclass> pinClass = new List<pinclass>();
            //EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = 0;
            SqlDataReader rdr = null;
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string pinsp = "sp_getPins";
            SqlCommand cmd11 = new SqlCommand(pinsp, con);
            cmd11.Parameters.AddWithValue("@user_id", System.Web.HttpContext.Current.Session["userId"]);
            cmd11.Parameters.AddWithValue("@intCode", 0);
            cmd11.CommandType = CommandType.StoredProcedure;
            try
            {
                rdr = cmd11.ExecuteReader();
                while (rdr.Read())
                {
                    pinClass.Add(new pinclass
                    {
                        sno = rdr["userpinId"].ToString(),
                        pinNo = rdr["pin_no"].ToString(),
                        assignedDate = rdr["assignedDate"].ToString()
                    });
                }
            }
            catch (Exception e1) { }
            //string pinNo = parm1.Value.ToString();
            //pinNo = "PNI" + pinNo;
            if (pinClass != null)
            {
                 totalRecords = pinClass.Count();

            }
            else
            {
                totalRecords = 0;
            }
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = pinClass
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult unUsedPin()
        {
            TempData["userId"] = System.Web.HttpContext.Current.Session["userId"];
            TempData["userName"] = System.Web.HttpContext.Current.Session["userName"];
            ViewBag.sectionName = "UnUsed Pin";
            return View();
        }

        public JsonResult GetunusedPin(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            List<pinclass> pinClass = new List<pinclass>();
            //EComsDBEntity db = new EComsDBEntity();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            SqlDataReader rdr = null;
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string pinsp = "sp_getPins";
            SqlCommand cmd11 = new SqlCommand(pinsp, con);
            cmd11.Parameters.AddWithValue("@user_id", System.Web.HttpContext.Current.Session["userId"]);
            cmd11.Parameters.AddWithValue("@intCode",1 );
            cmd11.CommandType = CommandType.StoredProcedure;
            try
            {
                rdr = cmd11.ExecuteReader();
                while (rdr.Read())
                {
                    pinClass.Add(new pinclass
                    {
                        sno = rdr["userpinId"].ToString(),
                        pinNo = rdr["pin_no"].ToString(),
                        assignedDate = rdr["assignedDate"].ToString()
                    });
                }
            }
            catch (Exception e1) { }
            //string pinNo = parm1.Value.ToString();
            //pinNo = "PNI" + pinNo;
            int totalRecords = pinClass.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = pinClass
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
