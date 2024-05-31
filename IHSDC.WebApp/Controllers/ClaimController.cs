using IHSDC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Controllers
{
    public class ClaimController : Controller
    {
       
        DBConnection con = new DBConnection();

        // GET: Claim
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            try
            {
                Claim claim = new Claim();
                return View(claim);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Application_Id,Army_No,Rank,Name,Regt_Corps,Unit,Enrollment_Date,Date_Of_Birth,Year_Of_Service,Email_Id,Adhar_No,Pan_No,Mobile_No,Purpose_of_withdrawal," +
            "House_Building_Advance_Loan,Conveyance_Advance_Loan,Computer_Advance_Loan ,House_Building_Date_of_Loan_taken,House_Building_Duration_of_Loan,House_Building_Amount_Taken,Conveyance_Date_of_Loan_taken,Conveyance_Duration_of_Loan,Conveyance_Amount_Taken,Computer_Date_of_Loan_taken,Computer_Duration_of_Loan,"+
            "Computer_Amount_Taken,Amount_of_withdrawal,Name_of_Child,date_of_Birth_Child,DO_Part_II_No,DO_Part_II_Date,Attach_Part_II_Order,Presently_studying,Course,College_Name,Attach_College_doc,"+
            "Total_Expenditure_Amount,Attach_Expenditure_doc,Age,Date_of_Mairrage,Attach_Mairrage_doc,Address,Name_of_Property_holder,Estimated_Cost_of_Expenditure,Attach_document_Expenditure_doc,Date_of_Retirement,No_of_withdrawal,Reason_for_first_withdrawal,Amount_Paid,Date_of_withdrawal,Name_of_Bank,Attach_Bank_Pay_Slip,Branch_Name,Account_No,Attach_Cancel_Check_Passbook,IFSC_Code,Bank_Address,Contact_No_of_Bank")] Claim claim_Application )
        {
            if(ModelState.IsValid)
            {
                try
                {
                    //Claim  claims  = con.tbl_Claim.FirstOrDefault(x => x.Army_No == claim_Application.Army_No);
                    //if (claims == null)
                    //{
                    claim_Application.DateTimeUpdated = DateTime.Now;
                    con.Claims.Add(claim_Application);
                        con.SaveChanges();

                        ModelState.Clear();
                        TempData["Message"] = "Application Successfully Submit!!";

                        return RedirectToAction("Search", "Claim", new { id = EncryptDecrypt.Encryption(claim_Application.Application_Id.ToString()), callaction = "download" });

                    //}
                    //else
                    //{
                    //    ViewBag.Message = "You have already applied for a loan in this category.";
                    //    ModelState.Clear();
                    //    return View(claim_Application);

                    //}

                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                    throw; // re-throw the exception to let it bubble up and be handled by the global exception handler or catch block higher up in the call stack
                }
            }
            else
            {
                return View(claim_Application);
            }
            
        }




        public ActionResult Search(string id, string callaction)
        {
            try
            {
                //id = "MzY%3d";
                //callaction = "download";
                string ipAddress = Request.UserHostAddress;
                ViewBag.IpAddress = ipAddress;

                ViewBag.time = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy HH:mm").Trim();


                ViewBag.action = callaction;
                ViewBag.Mess1 = TempData["info"];
                ViewBag.Message = TempData["message"];
                ViewBag.ApplicationId = TempData["ApplicationId"];


                //int NewId = 48;

                int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));
                //int NewId = Convert.ToInt32(id);

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Claim Claim_Application  = con.Claims.Find(NewId);
                if (Claim_Application == null)
                {
                    return HttpNotFound();
                }
                //Claim_Application.Name = EncryptDecrypt.DecryptionData(Claim_Application.Name);
                ////Claim_Application.Adhar_No = EncryptDecrypt.DecryptionData(Claim_Application.Adhar_No);
                //Claim_Application.Pan_No = EncryptDecrypt.DecryptionData(Claim_Application.Pan_No);

                ////Claim_Application.Mobile_No = Convert.ToInt32(EncryptDecrypt.DecryptionData(Claim_Application.Mobile_No);
                //Claim_Application.Email_Id = EncryptDecrypt.DecryptionData(Claim_Application.Email_Id);


                //string a = Claim_Application.st.TrimEnd();
                return View(Claim_Application);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}