using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IHSDC.WebApp.Models;

namespace IHSDC.WebApp.Controllers
{
    public class Car_PC_Advance_Application1Controller : Controller
    {
        //private IHSDCAGIFDBEntities db = new IHSDCAGIFDBEntities();

        //// GET: Car_PC_Advance_Application1
        //public ActionResult Index()
        //{
        //    return View(db.Car_PC_Advance_Application1.ToList());
        //}

        //// GET: Car_PC_Advance_Application1/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Car_PC_Advance_Application1 car_PC_Advance_Application1 = db.Car_PC_Advance_Application1.Find(id);
        //    if (car_PC_Advance_Application1 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(car_PC_Advance_Application1);
        //}

        //// GET: Car_PC_Advance_Application1/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Car_PC_Advance_Application1/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Application_Id,DateTimeUpdated,Loanee_Name,Army_No,Old_Army_No,Rank,Regt_Corps,Unit,CDA_PAO,Date_Of_Birth,Enrollment_Date,Promotion_Date,Retirement_Date,Year_Of_Service,Residual_Service,Salary_Slip_Month_Year,CDA_Account_No,Basic_Salary,Rank_Grade_Pay,DSOP_AFPP,MSP,AGIF,NPA_X_Pay,Income_Tax_Monthly,Tech_Pay,Rev_IT,TPTL_Pay,PLI,DA,MISC,MISC_Pay,Total,Salary_After_Deduction,Dealer_Name,Vehicle_Name,Vehicle_Make,Total_Cost,Amount_Applied_For_Loan,No_Of_EMI_Applied,Inst_No1_Amount,Inst_No1_Date,Inst_No2_Amount,Inst_No2_Date,Inst_No3_Amount,Inst_No3_Date,Inst_No4_Amount,Inst_No4_Date,Inst_No5_Amount,Inst_No5_Date,Pers_Address_Line1,Pers_Address_Line2,Pers_Address_Line3,Pers_Address_Line4,Pin_Code,Site_Address_Line1,Site_Address_Line2,Site_Address_Line3,Site_Address_Line4,Site_City,Site_Pin,Payee_Account_No,IFSC_Code,Mobile_No,E_Mail_Id,Payable_In_Favour_Of,Dispatch_Type,City_Branch_Code_Search,Payable_To,Dispatch_Address_Line1,Dispatch_Address_Line2,Dispatch_Address_Line3,Dispatch_Address_Line4,Previous_Loan_Source,Previous_Loan_Purpose,Amount,EMI,Previous_Loan_Is_Paid,Status,UpdatedBy")] Car_PC_Advance_Application1 car_PC_Advance_Application1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Car_PC_Advance_Application1.Add(car_PC_Advance_Application1);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(car_PC_Advance_Application1);
        //}

        //// GET: Car_PC_Advance_Application1/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Car_PC_Advance_Application1 car_PC_Advance_Application1 = db.Car_PC_Advance_Application1.Find(id);
        //    if (car_PC_Advance_Application1 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(car_PC_Advance_Application1);
        //}

        //// POST: Car_PC_Advance_Application1/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Application_Id,DateTimeUpdated,Loanee_Name,Army_No,Old_Army_No,Rank,Regt_Corps,Unit,CDA_PAO,Date_Of_Birth,Enrollment_Date,Promotion_Date,Retirement_Date,Year_Of_Service,Residual_Service,Salary_Slip_Month_Year,CDA_Account_No,Basic_Salary,Rank_Grade_Pay,DSOP_AFPP,MSP,AGIF,NPA_X_Pay,Income_Tax_Monthly,Tech_Pay,Rev_IT,TPTL_Pay,PLI,DA,MISC,MISC_Pay,Total,Salary_After_Deduction,Dealer_Name,Vehicle_Name,Vehicle_Make,Total_Cost,Amount_Applied_For_Loan,No_Of_EMI_Applied,Inst_No1_Amount,Inst_No1_Date,Inst_No2_Amount,Inst_No2_Date,Inst_No3_Amount,Inst_No3_Date,Inst_No4_Amount,Inst_No4_Date,Inst_No5_Amount,Inst_No5_Date,Pers_Address_Line1,Pers_Address_Line2,Pers_Address_Line3,Pers_Address_Line4,Pin_Code,Site_Address_Line1,Site_Address_Line2,Site_Address_Line3,Site_Address_Line4,Site_City,Site_Pin,Payee_Account_No,IFSC_Code,Mobile_No,E_Mail_Id,Payable_In_Favour_Of,Dispatch_Type,City_Branch_Code_Search,Payable_To,Dispatch_Address_Line1,Dispatch_Address_Line2,Dispatch_Address_Line3,Dispatch_Address_Line4,Previous_Loan_Source,Previous_Loan_Purpose,Amount,EMI,Previous_Loan_Is_Paid,Status,UpdatedBy")] Car_PC_Advance_Application1 car_PC_Advance_Application1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(car_PC_Advance_Application1).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(car_PC_Advance_Application1);
        //}

        //// GET: Car_PC_Advance_Application1/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Car_PC_Advance_Application1 car_PC_Advance_Application1 = db.Car_PC_Advance_Application1.Find(id);
        //    if (car_PC_Advance_Application1 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(car_PC_Advance_Application1);
        //}

        //public ActionResult DownloadFile(string url)
        //{
        //    using (var client = new WebClient())
        //    {
        //        client.DownloadFile(url,"test");
        //    }
        //    return View();
        //}

        //// POST: Car_PC_Advance_Application1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Car_PC_Advance_Application1 car_PC_Advance_Application1 = db.Car_PC_Advance_Application1.Find(id);
        //    db.Car_PC_Advance_Application1.Remove(car_PC_Advance_Application1);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        ////public void ExportCSV_Employee()
        ////{
        ////    var sb = new StringBuilder();
        ////    // You can write sql query according your need  
        ////    string qry = "Select * from Employee");
        ////    IEnumerable<Employee> query = odbe.Database.SqlQuery<Employee>(qry);
        ////    var list = query.ToList();
        ////    sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6}", "First Name", "Last Name", "Address ", "BirdthDate", "City", "Salry", Environment.NewLine);
        ////    foreach (var item in list)
        ////    {
        ////        sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6}", item.FirstName, item.LastName, item.Address, item.BirthDate.Value.ToShortDateString(), item.City, Item.salary, item.ExportedTime, Environment.NewLine);
        ////    }
        ////    //Get Current Response  
        ////    var response = System.Web.HttpContext.Current.Response;
        ////    response.BufferOutput = true;
        ////    response.Clear();
        ////    response.ClearHeaders();
        ////    response.ContentEncoding = Encoding.Unicode;
        ////    response.AddHeader("content-disposition", "attachment;filename=Employee.CSV ");
        ////    response.ContentType = "text/plain";
        ////    response.Write(sb.ToString());
        ////    response.End();
        ////}






        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
