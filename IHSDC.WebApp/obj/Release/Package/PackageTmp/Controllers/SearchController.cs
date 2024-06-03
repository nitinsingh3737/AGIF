using IHSDC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Controllers
{
    public class SearchController : Controller
    {
       // private IHSDCAGIFDBEntities db = new IHSDCAGIFDBEntities();
        DBConnection con = new DBConnection();

        // GET: Search
        public ActionResult Index()
        {
            try
            { 
                //Nitesh 10-02-2023
                if (Session["UserIntId"] != null)
                {
                    return View("Search");
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


        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            { 
                if(collection["ltype"] == "Car/Pc")
                {
                    CarPcModel obj = new CarPcModel();
                    obj.Army_No = collection["armyno"].Trim();
                   // obj.carPcModel = con.getApplicationDetailById(obj);

                
                    if (obj.Army_No != null)
                    {
                        return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = obj.Army_No });
                    }

                }
                //if(collection["ltype"] == "Claim")
                //{
                //    Claims_Maturity obj = new Claims_Maturity();
                //    obj.ArmyNumber = collection["armyno"].Trim();
                //    Claims_Maturity data = db.Claims_Maturity.FirstOrDefault(x => x.ArmyNumber == obj.ArmyNumber);
                //    if (data != null)
                //    {
                //        return RedirectToAction("Search", "Claims_Maturity", new { id = data.Application_ID });
                //    }
                //}

                //if(collection["ltype"] == "HBA")
                //{
                //    House_Building_Advance_Application obj = new House_Building_Advance_Application();
                //    obj.Army_No = collection["armyno"].Trim();
                //    House_Building_Advance_Application data = db.House_Building_Advance_Application.FirstOrDefault(x => x.Army_No == obj.Army_No);
                //    if (data != null)
                //    {
                //        return RedirectToAction("Search", "House_Building_Advance_Application", new { id = data.Application_Id });
                //    }
                //}

                return View("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            try
            { 
                if (collection["ltype"] == "Car/Pc")
                {
                    CarPcModel data = new CarPcModel();
                    CarPcModel carPc = new CarPcModel();
                    data.Army_No = collection["armyno"].Trim();
                    data  = con.carPcModel.FirstOrDefault(x => x.Army_No == data.Army_No);
                    if (data != null)
                    {
                        return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = data.Application_Id });
                    }


                    //CarPcModel obj = new CarPcModel();
                    //obj.Army_No = collection["armyno"].Trim();
                    //if (obj.Army_No != null)
                    //{
                    //    return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = obj.Army_No });
                    //}

                }
                //if (collection["ltype"] == "Claim")
                //{
                //    Claims_Maturity obj = new Claims_Maturity();
                //    obj.ArmyNumber = collection["armyno"].Trim();
                //    Claims_Maturity data = db.Claims_Maturity.FirstOrDefault(x => x.ArmyNumber == obj.ArmyNumber);
                //    if (data != null)
                //    {
                //        return RedirectToAction("Search", "Claims_Maturity", new { id = data.Application_ID });
                //    }
                //}

                //if (collection["ltype"] == "HBA")
                //{
                //    House_Building_Advance_Application obj = new House_Building_Advance_Application();
                //    obj.Army_No = collection["armyno"].Trim();
                //    House_Building_Advance_Application data = db.House_Building_Advance_Application.FirstOrDefault(x => x.Army_No == obj.Army_No);
                //    if (data != null)
                //    {
                //        return RedirectToAction("Search", "House_Building_Advance_Application", new { id = data.Application_Id });
                //    }
                //}
                ViewBag.result = "Not Found!";
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Search()
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

        public ActionResult Search1(string result)
        {
            try
            { 
                ViewBag.result = result;
                return View("Search");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}