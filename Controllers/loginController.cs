using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gicmart.Models;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace gicmart.Controllers
{
    public class loginController : Controller
    {
        //
        // GET: /lohin/
        public ActionResult Index()
        {
            return View();
        }
        // GET: /login/
        public class User
        {
            public string UserName { get; set; }
            public string Role { get; set; }
            public string Password { get; set; }
            public int? UserId { get; set; }
            public string joinDate { get; set; }
        }
        public ActionResult login()
        {
            return View("login");
        }
        [HttpPost]
        public ActionResult login(login model)
        {
            User user = new User();
            user = GetUserDetails(model);
            if (user.Role != null)
            {
                FormsAuthentication.SetAuthCookie(model.userName, false);
                var authTicket = new FormsAuthenticationTicket(1, model.userName, DateTime.Now, DateTime.Now.AddMinutes(30), false, user.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                ViewBag.Message = "Success";
                if (user.Role=="Admin")
                {
                    System.Web.HttpContext.Current.Session["userId"]  = model.userName;
                    System.Web.HttpContext.Current.Session["userName"] = user.UserName;
                    System.Web.HttpContext.Current.Session["joindate"] = user.joinDate;
                    return RedirectToAction("index", "dashboard", new { area = "Admin" });
                }
                else
                {
                    System.Web.HttpContext.Current.Session["userId"] = model.userName;
                    System.Web.HttpContext.Current.Session["userName"] = user.UserName;
                    System.Web.HttpContext.Current.Session["joindate"] = user.joinDate;
                    return RedirectToAction("index", "userdashboard", new { area = "User" });
                }
            }
            else
            {
                ViewBag.Message = "Fail";
            }
            return View("login");
        }
        public static User GetUserDetails(login user)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            string role = null;
            string userName = null;
            string date = null;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            int status = 0;
            SqlDataReader rdr = null;
            bool isActive = false;
            string usersp2 = "sp_CheckLogin";
            SqlCommand cmd4 = new SqlCommand(usersp2, con);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@user_name", user.userName);
            cmd4.Parameters.AddWithValue("@user_pw", user.userPassword);
            rdr = cmd4.ExecuteReader();
            while (rdr.Read())
            {
                role = rdr["role"].ToString();
                userName = rdr["name"].ToString();
                date = rdr["assignedDate"].ToString();   
            }
            var loginRole = new User
            {
                Role = role,
                UserName = userName,
                joinDate=date
            };
            rdr.Close();
            con.Close();
            return (loginRole);
        }
    }

}
