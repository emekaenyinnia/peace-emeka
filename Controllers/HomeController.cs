using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AppFiles.Models;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace File.Controllers
{
    public class HomeController : Controller
    {
        ViewRecords records = null;
        RecordContext dbh = null;
        FileFormat funx = null;

        public HomeController()
        {
            records = new ViewRecords();
            dbh = new RecordContext();
            funx = new FileFormat();
        }
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string Firstname, string Lastname, HttpPostedFileBase UploadFile)
        {

            if (UploadFile != null)
            {
                string fileName = Path.GetFileName(UploadFile.FileName);
                if (UploadFile.ContentLength < 104857600)
                {
                    UploadFile.SaveAs(Server.MapPath("/UploadFiles/" + fileName));

                    string mainConn = ConfigurationManager.ConnectionStrings["RecordContext"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainConn);
                    string sqlquery = "insert into [dbo].[FileFormat] values(@Firstname, @Lastname, @Name, @FilePath)";
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);

                    sqlconn.Open();
                    sqlcomm.Parameters.AddWithValue("@Firstname", Firstname);http://localhost:18969/Properties/
                    sqlcomm.Parameters.AddWithValue("@Lastname", Lastname);
                    sqlcomm.Parameters.AddWithValue("@Name", fileName);
                    sqlcomm.Parameters.AddWithValue("@FilePath", "/UploadFiles/" + fileName);
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                    ViewData["Message"] = "Record Uploaded Successfully..!";
                    return RedirectToAction("ViewFiles", "Home");

                }

            }
            return RedirectToAction("Index");


        }



        public FileResult Downloadfile(string Name)
        {

            string path = Server.MapPath("~/UploadFiles/") + Name;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", Name);
            }
        public ActionResult Delete(int Id)
        {
            var dbh = new RecordContext();

            FileFormat user = dbh.FileFormats.Find(Id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public JsonResult DeleteUser(int Id)
        {
            string result = string.Empty;
            var dbh = new RecordContext();

            FileFormat user = dbh.FileFormats.Find(Id);
            dbh.FileFormats.Remove(user);

            int value = dbh.SaveChanges();

            if (value > 0)
            {
                result = "The row has been successfully deleted.";
               
            }
            else
            {
                result = "The row was not deleted.";
            }
            return Json(result);

        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult ViewFiles()
        {
            records.UsersList = records.ListOfUsers();
            return View(records);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}