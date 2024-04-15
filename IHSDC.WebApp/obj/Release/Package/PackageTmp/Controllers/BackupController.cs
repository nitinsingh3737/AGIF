using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Controllers
{
    [Authorize]
    public class BackupController : Controller
    {
        private DBConnection con = new DBConnection();
        // GET: Backup
        public ActionResult Index()
        {
            try
            {
                //Nitesh 10-02-2023
                if (Session["UserIntId"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult BackupDatabase()
        {
            try
            {
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult BackupDatabaseFile()
        {
            try
            { 
            string dbPath = Server.MapPath("~/App_Data/DBBackup.bak");
            using (var db = new  DBConnection())
            {
                var cmd = String.Format("BACKUP DATABASE {0} TO DISK='{1}' WITH FORMAT, MEDIANAME='DbBackups', MEDIADESCRIPTION='Media set for {0} database';"
                    , "IHSDCAG", dbPath);
                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(dbPath);
            string fileName = "DBBackup.bak";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch
            {
                return View("Error");
            }
            //return new File(dbPath, "application/octet-stream");
        }
        public ActionResult RestoreDatabase()
        {
            try
            { 
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]

        public ActionResult RestoreDatabaseFromFile(HttpPostedFileBase file )
        {
            try
            { 
                string dbPath = Server.MapPath("~/App_Data/" + file.FileName);
                using (var db = new DBConnection())
                {
                    var cmd = String.Format("ALTER DATABASE IHSDCAG  SET offline with ROLLBACK IMMEDIATE  use master    RESTORE DATABASE [IHSDCAG] FROM  DISK = '" + dbPath + "' WITH REPLACE ");

                    db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                }
                return View("RestoreDatabase");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}