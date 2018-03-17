using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eie_project.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;


namespace eie_project.Controllers
{
    public class AdminController : Controller
    {

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["projectdb"].ConnectionString);

        // GET: Admin 
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult CreateAdmin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(AdminAccount account)
        {
            if (ModelState.IsValid)
            {

                conn.Open();
                SqlCommand command = new SqlCommand("Insert into dbo.ADMIN values('" +
                account.FirstName + "','" + account.LastName + "','" + account.Email + "','" + account.Username + "','" + account.Password + "','" + account.Status + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();

                ModelState.Clear();
                //ViewBag.Message = account.LastName + " " + account.FirstName + " Successfully Enrolled";

            }
            return View();

        }

        //Login
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminAccount user)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select Status, Username, Password FROM dbo.ADMIN WHERE Username = '" + user.Username + "' and Password = '" + user.Password + "';", conn);
            //int res = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {

                Session["Status"] = rd["Status"].ToString();
                Session["Username"] = rd["Username"].ToString();
                if (Session["Status"].ToString() == "admin1")
                {
                    //Main Administration Section
                    return RedirectToAction("LoggedIn", "Admin");
                }
                else if (Session["Status"].ToString() == "admin2")
                {
                    //Sub Administration Section
                    return RedirectToAction("Index", "Home");
                }

                conn.Close();
            }
            else
            {
                ViewData["error"] = "Incorrect Username or Password";
                return View();
            }
            return View();
        }


        public ActionResult LoggedIn()
        {
            ViewBag.welcome = Session["FirstName"];

            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }

        public ActionResult Student()
        {
            conn.Open();
            List<UserAccount> _User = new List<UserAccount>();
            SqlDataAdapter da = new SqlDataAdapter("select * FROM dbo.STUDENTS", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _User.Add(new UserAccount()
                {
                    UserID = int.Parse(dr[0].ToString()),
                    LastName = dr["LastName"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    MatricNumber = dr["MatricNumber"].ToString(),
                    Level = Int32.Parse(dr["Level"].ToString())
                });
            }
            return View(_User);
        }

        
        public ActionResult AdminTable()
        {
            conn.Open();
            List<AdminAccount> _Admin = new List<AdminAccount>();
            SqlDataAdapter da = new SqlDataAdapter("select * FROM dbo.ADMIN", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _Admin.Add(new AdminAccount()
                {
                    UserID = int.Parse(dr[0].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    
                    Status = dr["Status"].ToString()
                });
            }
            return View(_Admin);
        }
    }
}