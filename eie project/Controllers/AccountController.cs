using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eie_project.Models;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace eie_project.Controllers
{
    public class AccountController : Controller
    {

        string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["projectdb"].ConnectionString;
        //SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["projectdb"].ConnectionString);
        // GET: Account


        /*public ActionResult Students()
        {
            if (ModelState.IsValid)
            {
                //String connectionString = "<THE CONNECTION STRING HERE>";
                String sql = "SELECT * FROM dbo.STUDENTS";


                using (SqlConnection conn = new SqlConnection(connectionString1))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        var UserAccount = new List<Student>();
                        while (rdr.Read())
                        {
                            var model = new Student();
                            model.FirstName = rdr["FirstName"];
                            model.LastName = rdr["LastName"];
                            model.Level = rdr["Level"];


                            UserAccount.Add(model);

                            ModelState.Clear();
                         }
                      }
                }

            }
            return View();
        }
        */
        public ActionResult Index()
        {
           //using (OurDbContext db = new OurDbContext())
           //{
               //return View(db.userAccount.ToList());
           //}
            return View();
        }
        public ActionResult Enrolment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enrolment(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                SqlConnection conn = new SqlConnection(connectionString1);
                conn.Open();
                SqlCommand command = new SqlCommand("Insert into dbo.STUDENTS values('" +
                account.LastName + "','" + account.FirstName + "','" + account.MatricNumber + "','" + account.Level + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();
                /*using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();

                }*/
                ModelState.Clear();
                //ViewBag.Message = account.LastName + " " + account.FirstName + " Successfully Enrolled";

            }
            return View();

        }
        public ActionResult Homepage()
        {
            return View();
        }


        public string connectionString { get; set; }

        public SqlConnection con { get; set; }

        public string ConnectionStrings { get; set; }

        public ActionResult Ta { get; set; }
    }
}