﻿using DocumentFormat.OpenXml.Office2010.Excel;
using IHSDC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            try
            { 
                return View();
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult upload()
        {
            try
            { 
                ViewBag.Mess1=TempData["info"];
                return View();
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult download()
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
        public ActionResult status()
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
        //[ValidateAntiForgeryToken]
        public ActionResult upload(FormCollection collection)
        {
            try
            {
                if (collection["ltype"] == "Car")
                {
                    CarPcModel data = new CarPcModel();
                    CarPcModel carPc = new CarPcModel();
                    data.Army_No = collection["armyno"].Trim().ToUpper();
                    data.Army_No = EncryptDecrypt.EncryptionData(data.Army_No.ToString());
                    data = con.carPcModel.FirstOrDefault(x => x.Army_No == data.Army_No);

                    if (data != null)
                    {
                        if (data.ApplicationForm == null)
                        {

                            return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = EncryptDecrypt.Encryption(data.Application_Id.ToString()), callaction = "upload" });
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
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult download(FormCollection collection)
        {
            try
            { 
                if (collection["ltype"] == "Car/Pc")
                {
                    CarPcModel data = new CarPcModel();
                    CarPcModel carPc = new CarPcModel();
                    //data.Army_No = collection["armyno"].Trim();

                    data.Army_No = collection["armyno"].Trim().ToUpper();
                    data.Army_No = EncryptDecrypt.EncryptionData(data.Army_No.ToString());
                    data = con.carPcModel.FirstOrDefault(x => x.Army_No == data.Army_No);

                    if (data != null)
                    {
                        return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = EncryptDecrypt.Encryption(data.Application_Id.ToString()), callaction= "download" });
                    }
                }
                ViewBag.result = "Application correcponding to your ArmyNo Not Found. Please Fill the Application from a link given in menu bar.";
                return View();

            }
            catch
            {
                return View("Error");
            }
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult status(FormCollection collection)
        {
            try
            { 
                if (collection["ltype"] == "Car/Pc")
                {
                    CarPcModel data = new CarPcModel();
                    CarPcModel carPc = new CarPcModel();

                    data.Army_No = collection["armyno"].Trim().ToUpper();
                    data.Army_No = EncryptDecrypt.EncryptionData(data.Army_No.ToString());
                    data = con.carPcModel.FirstOrDefault(x => x.Army_No == data.Army_No);

                    var data1 = con.carPcModel.Where(x => x.Army_No == data.Army_No).ToList();

                    if (data != null)
                    {
                        ViewBag.status = data1;
                        return View();
                    }
                }
                ViewBag.result = "Application correcponding to your ArmyNo Not Found. Please Fill the Application from a link given in menu bar.";
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