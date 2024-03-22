using IHSDC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Controllers
{
    public class LoanApplicationController : Controller
    {
        DBConnection con = new DBConnection();

        // GET: LoanApplication
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult upload()
        {
            ViewBag.Mess1=TempData["info"];
            return View();
        }
        public ActionResult download()
        {
            return View();
        }
        public ActionResult status()
        {
            return View();
        }
        [HttpPost]
        public ActionResult upload(FormCollection collection)
        {

            if (collection["ltype"] == "Car/Pc")
            {
                CarPcModel data = new CarPcModel();
                CarPcModel carPc = new CarPcModel();
                data.Army_No = collection["armyno"].Trim();
                data = con.carPcModel.FirstOrDefault(x => x.Army_No == data.Army_No);
                
                if (data != null)
                {
                    if (data.ApplicationForm == null)
                    {

                        return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = data.Application_Id, callaction = "upload" });
                    }
                    else
                    {
                        ViewBag.result = "Files have already been Uploaded.";
                        return View();
                    }
                }
            }
            ViewBag.result = "Application correcponding to your ArmyNo Not Found. Please Fill the Application from a link given in menu bar.";
            return View();

        }

        [HttpPost]
        public ActionResult download(FormCollection collection)
        {

            if (collection["ltype"] == "Car/Pc")
            {
                CarPcModel data = new CarPcModel();
                CarPcModel carPc = new CarPcModel();
                data.Army_No = collection["armyno"].Trim();
                data = con.carPcModel.FirstOrDefault(x => x.Army_No == data.Army_No);
                if (data != null)
                {
                    return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = data.Application_Id ,callaction= "download" });
                }
            }
            ViewBag.result = "Application correcponding to your ArmyNo Not Found. Please Fill the Application from a link given in menu bar.";
            return View();

        }


        [HttpPost]
        public ActionResult status(FormCollection collection)
        {

            if (collection["ltype"] == "Car/Pc")
            {
                CarPcModel data = new CarPcModel();
                CarPcModel carPc = new CarPcModel();
                data.Army_No = collection["armyno"].Trim();
                var data1 = con.carPcModel.Where(x => x.Army_No == data.Army_No).ToList();
                data = con.carPcModel.FirstOrDefault(x => x.Army_No == data.Army_No);
                if (data != null)
                {
                    ViewBag.status = data1;
                    return View();
                }
            }
            ViewBag.result = "Application correcponding to your ArmyNo Not Found. Please Fill the Application from a link given in menu bar.";
            return View();

        }

        public ActionResult Search1(string result)
        {
            ViewBag.result = result;
            return View("Search");
        }
    }
}