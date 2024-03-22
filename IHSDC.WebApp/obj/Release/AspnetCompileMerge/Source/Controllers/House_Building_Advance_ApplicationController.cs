using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IHSDC.WebApp.Models;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace IHSDC.WebApp.Controllers
{
    public class House_Building_Advance_ApplicationController : Controller
    {
        //{
        //    private IHSDCAGIFDBEntities db = new IHSDCAGIFDBEntities();

        //    // GET: House_Building_Advance_Application
        //    [Authorize]
        //    public ActionResult Index()
        //    {

        //        return View(db.House_Building_Advance_Application.ToList());
        //    }

        //    //GET : House_Building_Advance_Application/detai
        //    public ActionResult detai()
        //    {
        //        return View();

        //    }


        //    public ActionResult ChangeStatus(int? id)
        //    {
        //        ViewBag.Active = new List<SelectListItem> {
        //             new SelectListItem { Text = "New Application", Value = "New Application"},
        //             new SelectListItem { Text = "Approved", Value = "Approved"},
        //              new SelectListItem { Text = "Under Process", Value = "Under Process"},
        //             new SelectListItem { Text = "Returned", Value = "Returned"}
        //         };

        //        House_Building_Advance_Application house_Building_Advance = db.House_Building_Advance_Application.Find(id);
        //        return View(house_Building_Advance);
        //    }


        //    [HttpPost]
        //    public ActionResult ChangeStatus(House_Building_Advance_Application house_Building_Advance)
        //    {

        //        House_Building_Advance_Application house = db.House_Building_Advance_Application.Find(house_Building_Advance.Application_Id);
        //        house.Status = house_Building_Advance.Status;
        //        house.Remark = house_Building_Advance.Remark;

        //        //car_PC_Advance_.Application_Id = car_PC_Advance_Application.Application_Id;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    // GET: House_Building_Advance_Application/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        House_Building_Advance_Application house_Building_Advance_Application = db.House_Building_Advance_Application.Find(id);
        //        if (house_Building_Advance_Application == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        string a = house_Building_Advance_Application.Status.TrimEnd();

        //        if (a == "Approved")
        //        {
        //            house_Building_Advance_Application.Status = "Under Process";
        //        }
        //        else
        //        {
        //            if (a == "Under Process")
        //            {
        //                house_Building_Advance_Application.Status = "Returned";
        //            }
        //            else
        //            {
        //                if (a == "Returned")
        //                {
        //                    house_Building_Advance_Application.Status = "Approved";
        //                }
        //            }
        //        }
        //        db.SaveChanges();
        //        return View(house_Building_Advance_Application);
        //    }

        // GET: House_Building_Advance_Application/Create
        public ActionResult Create()
        {
            return View();
        }

        //    // POST: House_Building_Advance_Application/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create(HttpPostedFileBase file,[Bind(Include = "Application_Id,DateTimeUpdated,Loanee_Name,Aadhar_No,Army_No,Old_Army_No,Rank,Regt_Corps,Unit,CDA_PAO,Date_Of_Birth,Enrollment_Date,Promotion_Date,Retirement_Date,Year_Of_Service,Residual_Service,Salary_Slip_Month_Year,CDA_Account_No,Basic_Salary,Rank_Grade_Pay,DSOP_AFPP,MSP,AGIF,NPA_X_Pay,Income_Tax_Monthly,Tech_Pay,Rev_IT,TPTL_Pay,PLI,DA,MISC,MISC_Pay,Total,Salary_After_Deduction,Purpose_For_Loan_Applied,Board_Type,Society_City,Authority,Total_Cost,Amount_Applied,No_Of_EMI_Applied,EMI1_Amount,EMI1_Date,EMI2_Amount,EMI2_Date,EMI3_Amount,EMI3_Date,EMI4_Amount,EMI4_Date,EMI5_Amount,EMI5_Date,Pers_Address_Line1,Pers_Address_Line2,Pers_Address_Line3,Pers_Address_Line4,Pin_Code,Site_Address_Line1,Site_Address_Line2,Site_Address_Line3,Site_Address_Line4,Site_City,Site_Pin,Payee_Account_No,IFSC_Code,Mobile_No,E_Mail_Id,Payable_At_Bank_Name,Payable_In_Favour,Dispatch_Address_Type,Payable_To,Dispatch_Address_Line1,Dispatch_Address_Line2,Dispatch_Address_Line3,Dispatch_Address_Line4,Dispatch_Pin_Code,Previous_Loan_Source,Previous_Loan_Purpose,Amount,EMI,Previous_Loan_Is_Paid,Status,UpdatedBy")] House_Building_Advance_Application house_Building_Advance_Application)
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            if (file.ContentLength > 0)
        //            {
        //                string _FileName = Path.GetFileName(file.FileName);
        //                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), house_Building_Advance_Application.Army_No+Path.GetExtension(_FileName));
        //                file.SaveAs(_path);
        //            }


        //            house_Building_Advance_Application.DateTimeUpdated = DateTime.Now;
        //            house_Building_Advance_Application.UpdatedBy = User.Identity.Name;
        //            house_Building_Advance_Application.Status = "New Application";
        //            db.House_Building_Advance_Application.Add(house_Building_Advance_Application);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(house_Building_Advance_Application);
        //    }

        //    // GET: House_Building_Advance_Application/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        House_Building_Advance_Application house_Building_Advance_Application = db.House_Building_Advance_Application.Find(id);
        //        if (house_Building_Advance_Application == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(house_Building_Advance_Application);
        //    }

        //    // POST: House_Building_Advance_Application/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Application_Id,DateTimeUpdated,Loanee_Name,Aadhar_No,Army_No,Old_Army_No,Rank,Regt_Corps,Unit,CDA_PAO,Date_Of_Birth,Enrollment_Date,Promotion_Date,Retirement_Date,Year_Of_Service,Residual_Service,Salary_Slip_Month_Year,CDA_Account_No,Basic_Salary,Rank_Grade_Pay,DSOP_AFPP,MSP,AGIF,NPA_X_Pay,Income_Tax_Monthly,Tech_Pay,Rev_IT,TPTL_Pay,PLI,DA,MISC,MISC_Pay,Total,Salary_After_Deduction,Purpose_For_Loan_Applied,Board_Type,Society_City,Authority,Total_Cost,Amount_Applied,No_Of_EMI_Applied,EMI1_Amount,EMI1_Date,EMI2_Amount,EMI2_Date,EMI3_Amount,EMI3_Date,EMI4_Amount,EMI4_Date,EMI5_Amount,EMI5_Date,Pers_Address_Line1,Pers_Address_Line2,Pers_Address_Line3,Pers_Address_Line4,Pin_Code,Site_Address_Line1,Site_Address_Line2,Site_Address_Line3,Site_Address_Line4,Site_City,Site_Pin,Payee_Account_No,IFSC_Code,Mobile_No,E_Mail_Id,Payable_At_Bank_Name,Payable_In_Favour,Dispatch_Address_Type,Payable_To,Dispatch_Address_Line1,Dispatch_Address_Line2,Dispatch_Address_Line3,Dispatch_Address_Line4,Dispatch_Pin_Code,Previous_Loan_Source,Previous_Loan_Purpose,Amount,EMI,Previous_Loan_Is_Paid,Status,UpdatedBy")] House_Building_Advance_Application house_Building_Advance_Application)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(house_Building_Advance_Application).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(house_Building_Advance_Application);
        //    }

        //    public ActionResult EditA(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        House_Building_Advance_Application house_Building_Advance_Application = db.House_Building_Advance_Application.Find(id);
        //        if (house_Building_Advance_Application == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        string a = house_Building_Advance_Application.Status.TrimEnd();

        //        if (a == "New Application")
        //        {
        //            house_Building_Advance_Application.Status = "Approved";
        //        }

        //        if (a == "Approved")
        //        {
        //            house_Building_Advance_Application.Status = "Under Process";
        //        }

        //        else
        //        {
        //            if (a == "Under Process")
        //            {
        //                house_Building_Advance_Application.Status = "Returned";
        //            }
        //            else
        //            {
        //                if (a == "Returned")
        //                {
        //                    house_Building_Advance_Application.Status = "Approved";
        //                }
        //            }
        //        }
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    // GET: House_Building_Advance_Application/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        House_Building_Advance_Application house_Building_Advance_Application = db.House_Building_Advance_Application.Find(id);
        //        if (house_Building_Advance_Application == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(house_Building_Advance_Application);
        //    }
        //    public ActionResult ExportToExcel()
        //    {
        //        var gv = new GridView();
        //        gv.DataSource = db.Car_PC_Advance_Application.ToList();
        //        gv.DataBind();
        //        Response.ClearContent();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment; filename=Car/HouseBuildingAdvanceExcel.xlsx");
        //        Response.ContentType = "application/ms-excel";
        //        Response.Charset = "";
        //        StringWriter objStringWriter = new StringWriter();
        //        HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
        //        gv.RenderControl(objHtmlTextWriter);
        //        Response.Output.Write(objStringWriter.ToString());
        //        Response.Flush();
        //        Response.End();
        //        return RedirectToAction("Index");
        //    }
        //    // POST: House_Building_Advance_Application/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        House_Building_Advance_Application house_Building_Advance_Application = db.House_Building_Advance_Application.Find(id);
        //        db.House_Building_Advance_Application.Remove(house_Building_Advance_Application);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //    // GET: House_Building_Advance_Application
        //    public ActionResult detailss()
        //    {

        //        return View();
        //    }

    }
}
