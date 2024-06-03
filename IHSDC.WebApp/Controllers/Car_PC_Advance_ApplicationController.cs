using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Presentation;
using IHSDC.WebApp.Models;
using Access = Microsoft.Office.Interop.Access;

namespace IHSDC.WebApp.Controllers
{

    public class Car_PC_Advance_ApplicationController : Controller
    {
        //private IHSDCAGIFDBEntities db = new IHSDCAGIFDBEntities();
        DBConnection con = new DBConnection();

        
        // GET: Car_PC_Advance_Application
        [Authorize]
        public ActionResult Index()
        {
            try
            { 
                if (Session["UserIntId"] != null)
                {
                    List model = new List();
                    model.carPcModel = con.getApplication();
                    List<CarPcModel> lst = new List<CarPcModel>();
                    foreach (var data in model.carPcModel)
                    {
                        CarPcModel carPc = new CarPcModel();

                        carPc = data;

                        carPc.Loanee_Name = EncryptDecrypt.DecryptionData(data.Loanee_Name);
                        carPc.AadharNo = EncryptDecrypt.DecryptionData(data.AadharNo);
                        carPc.PANNo = EncryptDecrypt.DecryptionData(data.PANNo);

                        carPc.Regt_Corps = EncryptDecrypt.DecryptionData(data.Regt_Corps);
                        carPc.Unit = EncryptDecrypt.DecryptionData(data.Unit);
                        carPc.CDA_Account_No = EncryptDecrypt.DecryptionData(data.CDA_Account_No);

                        //carPc.Pers_Address_Line1 = EncryptDecrypt.DecryptionData(data.Pers_Address_Line1);
                        //carPc.Pers_Address_Line2 = EncryptDecrypt.DecryptionData(data.Pers_Address_Line2);
                        //carPc.Pers_Address_Line3 = EncryptDecrypt.DecryptionData(data.Pers_Address_Line3);
                        //carPc.Pers_Address_Line4 = EncryptDecrypt.DecryptionData(data.Pers_Address_Line4);
                        carPc.Pin_Code = EncryptDecrypt.DecryptionData(data.Pin_Code);

                        carPc.Payee_Account_No = EncryptDecrypt.DecryptionData(data.Payee_Account_No);

                        carPc.IFSC_Code = EncryptDecrypt.DecryptionData(data.IFSC_Code);
                        carPc.Unit_Pin = EncryptDecrypt.DecryptionData(data.Unit_Pin);
                        carPc.CDA_PAO = EncryptDecrypt.DecryptionData(data.CDA_PAO);
                        carPc.Army_No = EncryptDecrypt.DecryptionData(data.Army_No);
                        carPc.Old_Army_No = EncryptDecrypt.DecryptionData(data.Old_Army_No);

                        int rankId = Convert.ToInt32(data.Rank);

                        var ranks = new IHSDC.WebApp.Models.DropDownClass().LoadRanks(); // Retrieve all ranks
                        var rank = ranks.FirstOrDefault(r => r.Value == Convert.ToString(rankId)); // Find rank by ID

                        var rank1 = rank.Text;
                        carPc.Rank = rank1;


                        lst.Add(carPc);
                    }

                    return View(lst);
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
        public ActionResult JqAJAX(CarPcModel model)
        {
            try
            {

          CarPcModel car_PC_Advance_ = con.carPcModel.FirstOrDefault(x=>x.ApplicationType== model.ApplicationType && x.Old_Army_No == model.Old_Army_No);
                if (car_PC_Advance_ != null)
                {
                    return Json(new
                    {
                        msg = "You have already Taken loan in this category."
                    });
                }
                else
                {
                    return Json(new
                    {
                        msg = "Successfully added " + model.Army_No
                    });
                }

            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Modal()
        {
            return PartialView();
        }
        // GET: Car_PC_Advance_Application/new
        public ActionResult ChangeStatus(String id)
        {
            try
            {
                //Nitesh 15-02-23
                int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));

                ViewBag.Active = new List<SelectListItem> {
                     new SelectListItem { Text = "New Application", Value = "New Application"},
                     new SelectListItem { Text = "Approved", Value = "Approved"},
                      new SelectListItem { Text = "Under Process", Value = "Under Process"},
                     new SelectListItem { Text = "Returned", Value = "Returned"}
                 };
                //Nitesh 15-02-23
                CarPcModel car_PC_Advance_Application = con.carPcModel.Find(NewId);
                return View(car_PC_Advance_Application);
            }
            catch
            {
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult ChangeStatus(CarPcModel car_PC_Advance_Application)
        {
            try
            {
                //EncryptDecrypt.Encryption(car_PC_Advance_Application.Application_Id.ToString())
                CarPcModel car_PC_Advance_ = con.carPcModel.Find(car_PC_Advance_Application.Application_Id);
                car_PC_Advance_.Status = car_PC_Advance_Application.Status;
                car_PC_Advance_.Remark = car_PC_Advance_Application.Remark;
                //car_PC_Advance_.Application_Id = car_PC_Advance_Application.Application_Id;
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        //// GET: Car_PC_Advance_Application/Details/5
        [AllowAnonymous]
        public ActionResult Details(String id)
        {
            try
            { 
                //Nitesh 15-02-23
                int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //Nitesh 15-02-23
                CarPcModel car_PC_Advance_Application = con.carPcModel.Find(NewId);
                if (car_PC_Advance_Application == null)
                {
                    return HttpNotFound();
                }
                //string a = car_PC_Advance_Application.Status.TrimEnd();

                //if (a == "New Application")
                //{
                //    car_PC_Advance_Application.Status = "Approved";
                //}

                //if (a == "Approved")
                //{
                //    car_PC_Advance_Application.Status = "Under Process";
                //}
                //else
                //{
                //    if (a == "Under Process")
                //    {
                //        car_PC_Advance_Application.Status = "Returned";
                //    }
                //    else
                //    {
                //        if (a == "Returned")
                //        {
                //            car_PC_Advance_Application.Status = "Approved";
                //        }
                //    }
                //}
                //db.SaveChanges();

                //var RankList = con.rankList();
                //List<SelectListItem> items = RankList.Select(r => new SelectListItem
                //{
                //    Value = r.Id.ToString(),
                //    Text = r.rank
                //}).ToList();
                int rankId = Convert.ToInt32(car_PC_Advance_Application.Rank);

                var ranks = new IHSDC.WebApp.Models.DropDownClass().LoadRanks(); // Retrieve all ranks
                var rank = ranks.FirstOrDefault(r => r.Value == Convert.ToString(rankId)); // Find rank by ID

                var rank1 = rank.Text;
                car_PC_Advance_Application.Rank = rank1;

                car_PC_Advance_Application.Loanee_Name = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Loanee_Name);
                car_PC_Advance_Application.AadharNo = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.AadharNo);
                car_PC_Advance_Application.PANNo = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.PANNo);

                car_PC_Advance_Application.Mobile_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Mobile_No);
                car_PC_Advance_Application.E_Mail_Id = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.E_Mail_Id);

                car_PC_Advance_Application.Regt_Corps = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Regt_Corps);
                car_PC_Advance_Application.Unit = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Unit);
                car_PC_Advance_Application.CDA_Account_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.CDA_Account_No);

                car_PC_Advance_Application.Pers_Address_Line1 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line1);
                car_PC_Advance_Application.Pers_Address_Line2 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line2);
                car_PC_Advance_Application.Pers_Address_Line3 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line3);
                car_PC_Advance_Application.Pers_Address_Line4 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line4);
                car_PC_Advance_Application.Pin_Code = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pin_Code);

                car_PC_Advance_Application.Payee_Account_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Payee_Account_No);

                car_PC_Advance_Application.IFSC_Code = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.IFSC_Code);
                car_PC_Advance_Application.Unit_Pin = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Unit_Pin);
                car_PC_Advance_Application.CDA_PAO = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.CDA_PAO);

                car_PC_Advance_Application.Army_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Army_No);
                car_PC_Advance_Application.Old_Army_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Old_Army_No);

                string a = car_PC_Advance_Application.Status.TrimEnd();
                return View(car_PC_Advance_Application);
            }
            catch
            {
                return View("Error");
            }
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static string stringReverseString3b(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
            {
                chars[i] = str[j];
                chars[j] = str[i];
            }
            return new string(chars);
        }

        public ActionResult ExportToCsv()
        {
            try
            { 
                //var gv = new GridView();

                DataTable dt = ToDataTable((from n in con.carPcModel.ToList()
                                            select new {n.Army_No, n.Old_Army_No,n.Loanee_Name,n.Rank 
                                                ,n.Regt_Corps ,n.Unit ,n.CDA_PAO ,n.ApplicationForm,
                                                Date_Of_Birth = n.Date_Of_Birth,
                                                Enrollment_Date =n.Enrollment_Date,
                                                Promotion_Date= n.Promotion_Date,
                                                Retirement_Date= n.Retirement_Date,
                                                n.Year_Of_Service 
                                                ,n.Residual_Service ,n.ApplicationType ,n.CarLoanType
                                                ,n.AadharNo ,n.PANNo ,n.Salary_Slip_Month_Year 
                                                ,n.CDA_Account_No ,n.Basic_Salary ,n.Rank_Grade_Pay 
                                                ,n.MSP ,n.NPA_X_Pay ,n.Tech_Pay ,n.DA ,n.TPTL_Pay 
                                                ,n.MISC_Pay ,n.PLI ,n.Rev_IT ,n.AGIF
                                                ,n.Income_Tax_Monthly ,n.DSOP_AFPP ,n.MISC 
                                                ,n.Total ,n.Salary_After_Deduction 
                                                ,n.Dealer_Name ,n.Vehicle_Name ,n.Vehicle_Make 
                                                ,n.Total_Cost ,n.Amount_Applied_For_Loan 
                                                ,n.No_Of_EMI_Applied  ,n.Pers_Address_Line1 
                                                ,n.Pers_Address_Line2 ,n.Pers_Address_Line3 
                                                ,n.Pers_Address_Line4 ,n.Pin_Code 
                                                ,n.Payee_Account_No ,n.IFSC_Code 
                                                ,n.Mobile_No ,n.E_Mail_Id ,n.Previous_Loan_Purpose 
                                                ,n.Amount ,n.EMI ,n.Previous_Loan_Is_Paid }).Where(x=>x.ApplicationForm!=null).Distinct().ToList());

        


                dt.Columns.Add("Pfx", typeof(System.String)).SetOrdinal(2);
                dt.Columns.Add("ArmyNo", typeof(System.String)).SetOrdinal(3);
                dt.Columns.Add("Sfx", typeof(System.String)).SetOrdinal(4);
                dt.Columns.Add("opfx", typeof(System.String));
                dt.Columns.Add("OldArmyNo", typeof(System.String));
                dt.Columns.Add("osfx", typeof(System.String));
                //gv.DataSource = db.Claims_Maturity.ToList();
                //gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=Car/ClaimsMaturityExcel.csv");
                Response.ContentType = "text/csv";
                Response.AddHeader("Pragma", "public");
                //    Response.Charset = "";
          
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        //add separator
                        if (k == 0)
                        {
                            string army = dt.Rows[i][k].ToString();
                            int count = 0;
                            int first = 0;
                            int secound = 0;
                            foreach (char c in army)
                            {
                                if (char.IsNumber(c))
                                {
                                    if (first == 0)
                                    {
                                       // army = army.Insert(count, "~");
                                        dt.Rows[i]["Pfx"] = Regex.Match(army.Substring(0, 3), @"([a-zA-Z .&'-]+)").Value;
                                        dt.Rows[i]["ArmyNo"] = Regex.Match(army, @"\d+").Value;
                                        dt.Rows[i]["Sfx"] = Regex.Match(army.Substring(army.Length - 1, 1), @"([a-zA-Z .&'-]+)").Value;
                                        first = 1;
                                    }

                                }
                                if (first == 1)
                                {
                                    if (!char.IsNumber(c))
                                    {
                                        if (secound == 0)
                                        {
                                           // army = army.Insert(count + 1, "~");
                                            secound = 1;
                                        }
                                    }
                                }
                                count++;
                            }
                            dt.Rows[i][k] = army;

                        }
                        if (k == 1)
                        {
                            string army = dt.Rows[i][k].ToString();
                            int count = 0;
                            int first = 0;
                            int secound = 0;
                            foreach (char c in army)
                            {
                                if (char.IsNumber(c))
                                {
                                    if (first == 0)
                                    {
                                      //  army = army.Insert(count, "~");
                                        dt.Rows[i]["opfx"] = Regex.Match(army.Substring(0, 3), @"([a-zA-Z .&'-]+)").Value;
                                        dt.Rows[i]["OldArmyNo"] = Regex.Match(army, @"\d+").Value;
                                        dt.Rows[i]["osfx"] = Regex.Match(army.Substring(army.Length - 1, 1), @"([a-zA-Z .&'-]+)").Value;

                                        first = 1;
                                    }

                                }
                                if (first == 1)
                                {
                                    if (!char.IsNumber(c))
                                    {
                                        if (secound == 0)
                                        {
                                           // army = army.Insert(count + 1, "~");
                                            secound = 1;
                                        }
                                    }
                                }
                                count++;
                            }
                            dt.Rows[i][k] = army;

                        }
                 
                       // dt.Columns.RemoveAt(1);
                        //dt.Columns.Remove("Army_No");
                        //dt.Columns.Remove("Old_Army_No");
                       // sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + '~');
                 
                    }
                    //append new line
                    //sb.Append("\r\n");
                }


                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(0);
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Columns[k].ColumnName + '~');
                }
                //append new line
                sb.Append("\r\n");

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        //add separator
                        // dt.Columns.RemoveAt(1);
                        //dt.Columns.Remove("Army_No");
                        //dt.Columns.Remove("Old_Army_No");
                        sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + '~');

                    }
                    //append new line
                    sb.Append("\r\n");
                }
                Response.Output.Write(sb.ToString());
                Response.Flush();
                Response.End();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult ExportToCsvDateWise(FormCollection collections)
        {
            try
            { 
                //string selectedDate = collections["date"].ToString();
                DateTime date = DateTime.Parse(collections["date"]);
                //var gv = new GridView();
                DataTable dt = ToDataTable((from n in con.carPcModel.ToList() 
                                            select new { n.Army_No, n.Old_Army_No,
                                                DateTimeUpdated= n.DateTimeUpdated.Value.ToString("dd/MM/yyyy"), n.Loanee_Name,
                                                n.Rank, n.Regt_Corps,n.ApplicationForm, n.Unit,
                                                n.CDA_PAO,
                                                Date_Of_Birth = n.Date_Of_Birth,
                                                Enrollment_Date = n.Enrollment_Date,
                                                Promotion_Date = n.Promotion_Date,
                                                Retirement_Date = n.Retirement_Date,
                                                n.Year_Of_Service,
                                                n.Residual_Service,
                                                n.ApplicationType,
                                                n.CarLoanType, n.AadharNo, n.PANNo,
                                                n.Salary_Slip_Month_Year, n.CDA_Account_No,
                                                n.Basic_Salary, n.Rank_Grade_Pay, n.MSP,
                                                n.NPA_X_Pay, n.Tech_Pay, n.DA, n.TPTL_Pay,
                                                n.MISC_Pay, n.PLI, n.Rev_IT, n.AGIF,
                                                n.Income_Tax_Monthly, n.DSOP_AFPP,
                                                n.MISC, n.Total, n.Salary_After_Deduction,
                                                n.Dealer_Name, n.Vehicle_Name, n.Vehicle_Make,
                                                n.Total_Cost, n.Amount_Applied_For_Loan,
                                                n.No_Of_EMI_Applied, n.Pers_Address_Line1,
                                                n.Pers_Address_Line2, n.Pers_Address_Line3,
                                                n.Pers_Address_Line4, n.Pin_Code,
                                                n.Payee_Account_No, n.IFSC_Code,
                                                n.Mobile_No, n.E_Mail_Id,
                                                n.Previous_Loan_Purpose,
                                                n.Amount, n.EMI,
                                                n.Previous_Loan_Is_Paid  }).Where(x=>x.ApplicationForm!=null && x.DateTimeUpdated==date.ToString("dd/MM/yyyy")).Distinct().ToList());
                dt.Columns.Add("apfx", typeof(System.String));
                dt.Columns.Add("ano", typeof(System.String));
                dt.Columns.Add("asfx", typeof(System.String));
                dt.Columns.Add("opfx", typeof(System.String));
                dt.Columns.Add("ono", typeof(System.String));
                dt.Columns.Add("osfx", typeof(System.String));
                // gv.DataSource = db.Claims_Maturity.ToList();
                //gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=Car/ClaimsMaturityExcel.csv");
                Response.ContentType = "text/csv";
                Response.AddHeader("Pragma", "public");
                //    Response.Charset = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        //add separator
                        if (k == 0)
                        {
                            string army = dt.Rows[i][k].ToString();
                            int count = 0;
                            int first = 0;
                            int secound = 0;
                            foreach (char c in army)
                            {
                                if (char.IsNumber(c))
                                {
                                    if (first == 0)
                                    {
                                        // army = army.Insert(count, "~");
                                        dt.Rows[i]["apfx"] = Regex.Match(army.Substring(0, 3), @"([a-zA-Z .&'-]+)").Value;
                                        dt.Rows[i]["ano"] = Regex.Match(army, @"\d+").Value;
                                        dt.Rows[i]["asfx"] = Regex.Match(army.Substring(army.Length - 1, 1), @"([a-zA-Z .&'-]+)").Value;
                                        first = 1;
                                    }

                                }
                                if (first == 1)
                                {
                                    if (!char.IsNumber(c))
                                    {
                                        if (secound == 0)
                                        {
                                            // army = army.Insert(count + 1, "~");
                                            secound = 1;
                                        }
                                    }
                                }
                                count++;
                            }
                            dt.Rows[i][k] = army;

                        }
                        if (k == 1)
                        {
                            string army = dt.Rows[i][k].ToString();
                            int count = 0;
                            int first = 0;
                            int secound = 0;
                            foreach (char c in army)
                            {
                                if (char.IsNumber(c))
                                {
                                    if (first == 0)
                                    {
                                        //  army = army.Insert(count, "~");
                                        dt.Rows[i]["opfx"] = Regex.Match(army.Substring(0, 3), @"([a-zA-Z .&'-]+)").Value;
                                        dt.Rows[i]["ono"] = Regex.Match(army, @"\d+").Value;
                                        dt.Rows[i]["osfx"] = Regex.Match(army.Substring(army.Length - 1, 1), @"([a-zA-Z .&'-]+)").Value;

                                        first = 1;
                                    }

                                }
                                if (first == 1)
                                {
                                    if (!char.IsNumber(c))
                                    {
                                        if (secound == 0)
                                        {
                                            // army = army.Insert(count + 1, "~");
                                            secound = 1;
                                        }
                                    }
                                }
                                count++;
                            }
                            dt.Rows[i][k] = army;

                        }

                        // dt.Columns.RemoveAt(1);
                        //dt.Columns.Remove("Army_No");
                        //dt.Columns.Remove("Old_Army_No");
                        // sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + '~');

                    }
                    //append new line
                    //sb.Append("\r\n");
                }


                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(0);

                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(dt.Columns[k].ColumnName + '~');
                }
                //append new line
                sb.Append("\r\n");

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        //add separator
                        // dt.Columns.RemoveAt(1);
                        //dt.Columns.Remove("Army_No");
                        //dt.Columns.Remove("Old_Army_No");
                        sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + '~');

                    }
                    //append new line
                    sb.Append("\r\n");
                }

                Response.Output.Write(sb.ToString());
                Response.Flush();
                Response.End();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        //public ActionResult ExportToExcel()
        //{
        //    var gv = new GridView();
        //    gv.DataSource = db.Car_PC_Advance_Application.ToList();
        //    gv.DataBind();



        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment; filename=Car/PcAdvanceExcel.xls");
        //    Response.ContentType = "application/vnd.ms-excel";
        //    Response.Charset = "";
        //    StringWriter objStringWriter = new StringWriter();
        //    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
        //    gv.RenderControl(objHtmlTextWriter);
        //    Response.Output.Write(objStringWriter.ToString());
        //    Response.Flush();
        //    Response.End();
        //    return RedirectToAction("Index");
        //}

        public ActionResult CARequirement()
        {
            try
            { 
                return View("Requirement");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult PCARequirement()
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

        public ActionResult EditA(String id)
        {
            try
            { 
                //Nitesh 15-02-23
                int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //Nitesh 15-02-23
                CarPcModel car_PC_Advance_Application = con.carPcModel.Find(NewId);
                if (car_PC_Advance_Application == null)
                {
                    return HttpNotFound();
                }
                string a = car_PC_Advance_Application.Status.TrimEnd();

                if (a == "Approved")
                {
                    car_PC_Advance_Application.Status = "Under Process";
                }
                else
                {
                    if (a == "Under Process")
                    {
                        car_PC_Advance_Application.Status = "Returned";
                    }
                    else
                    {
                        if (a == "Returned")
                        {
                            car_PC_Advance_Application.Status = "Approved";
                        }
                    }
                }
                con.SaveChanges();
                return RedirectToAction("ChangeStatus");
            }
            catch
            {
                return View("Error");
            }
        }

        //// GET: Car_PC_Advance_Application/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Message = TempData["message"];
                CarPcModel carPcModel = new CarPcModel();
                return View(carPcModel);
            }
            catch
            {
                return View("Error");
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


                int NewId = 48;

                //int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));
                //int NewId = Convert.ToInt32(id);

              
                //int newid = convert.toint32(encryptdecrypt.decryption(id));
                //int NewId = Convert.ToInt32(id);

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CarPcModel car_PC_Advance_Application = con.carPcModel.Find(NewId);
                if (car_PC_Advance_Application == null)
                {
                    return HttpNotFound();
                }

                int rankId = Convert.ToInt32(car_PC_Advance_Application.Rank);

                var ranks = new IHSDC.WebApp.Models.DropDownClass().LoadRanks(); // Retrieve all ranks
                var rank = ranks.FirstOrDefault(r => r.Value == Convert.ToString(rankId)); // Find rank by ID

                var rank1 = rank.Text;
                car_PC_Advance_Application.Rank = rank1;

                car_PC_Advance_Application.Loanee_Name = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Loanee_Name);
                car_PC_Advance_Application.AadharNo = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.AadharNo);
                car_PC_Advance_Application.PANNo = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.PANNo);

                car_PC_Advance_Application.Mobile_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Mobile_No);
                car_PC_Advance_Application.E_Mail_Id = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.E_Mail_Id);



                car_PC_Advance_Application.Regt_Corps = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Regt_Corps);
                car_PC_Advance_Application.Unit = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Unit);
                car_PC_Advance_Application.CDA_Account_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.CDA_Account_No);

                car_PC_Advance_Application.Pers_Address_Line1 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line1);
                car_PC_Advance_Application.Pers_Address_Line2 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line2);
                car_PC_Advance_Application.Pers_Address_Line3 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line3);
                car_PC_Advance_Application.Pers_Address_Line4 = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pers_Address_Line4);
                car_PC_Advance_Application.Pin_Code = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Pin_Code);

                car_PC_Advance_Application.Payee_Account_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Payee_Account_No);

                car_PC_Advance_Application.IFSC_Code = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.IFSC_Code);
                car_PC_Advance_Application.Unit_Pin = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Unit_Pin);

                car_PC_Advance_Application.CDA_PAO = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.CDA_PAO);

                car_PC_Advance_Application.Army_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Army_No);
                car_PC_Advance_Application.Old_Army_No = EncryptDecrypt.DecryptionData(car_PC_Advance_Application.Old_Army_No);

                string a = car_PC_Advance_Application.Status.TrimEnd();
                return View(car_PC_Advance_Application);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }


        public ActionResult Search1(String id, string status)
        {
            try
            { 
                switch (status)
                {
                    case "mess1":
                        ViewBag.Message1 = "File Uploaded Successfully!!";
                        break;
                    case "mess2":
                        ViewBag.Message2 = "File Uploaded Successfully!!";
                        break;
                    case "mess3":
                        ViewBag.Message3 = "File Uploaded Successfully!!";
                        break;
                    case "mess4":
                        ViewBag.Message4 = "File Uploaded Successfully!!";
                        break;
                    case "mess5":
                        ViewBag.Message5 = "File Uploaded Successfully!!";
                        break;
                }

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CarPcModel model = new CarPcModel();
                return View("Search", model);
            }
            catch
            {
                return View("Error");
            }
        }

        #region message
        public void DisplayMessage(string message, string midMsg, string messageStatus_s_e_w_i_Or_blank)
        {
            string status = messageStatus_s_e_w_i_Or_blank.ToLower();
            TempData["Message"] = message;
            TempData["messagemidStatus"] = midMsg;
            if (status == "s")
                TempData["messageStatus"] = "success";
            else if (status == "e")
                TempData["messageStatus"] = "error";
            else if (status == "w")
                TempData["messageStatus"] = "warning";
            else if (status == "i")
                TempData["messageStatus"] = "info";
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadApplicationForm(HttpPostedFileBase[] file, FormCollection collection)
        {
            try
            {
                  // string data = TempData["info"].ToString();


                    int count = 0;
                    var RC = "";
                    var Insurance = "";
                    var DrivingLicense = "";
                    var CopyofAadharCard = "";
                    var CopyofPANCard = "";
                    if (collection["ApplicationType"] == "2")
                    {
                        collection["ApplicationType"] = "CA";
                        DrivingLicense = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[4].FileName), "DrivingLicense", Path.GetExtension(file[0].FileName));
                        //CopyofAadharCard = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[5].FileName), "CopyofAadharCard", Path.GetExtension(file[0].FileName));
                        //CopyofPANCard = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[6].FileName), "CopyofPANCard", Path.GetExtension(file[0].FileName));
                    }
                    if (collection["ApplicationType"] == "3")
                    {
                        collection["ApplicationType"] = "PCA";
                    }
                    if (collection["ApplicationType"] == "4")
                    {
                        DrivingLicense = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[4].FileName), "DrivingLicense", Path.GetExtension(file[0].FileName));
                        //CopyofAadharCard = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[5].FileName), "CopyofAadharCard", Path.GetExtension(file[0].FileName));
                        //CopyofPANCard = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[6].FileName), "CopyofPANCard", Path.GetExtension(file[0].FileName));
                        collection["ApplicationType"] = "OLDCAR";
                        RC = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[0].FileName), "RC", Path.GetExtension(file[0].FileName));
                        Insurance = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[0].FileName), "Insurance", Path.GetExtension(file[0].FileName)); 
                    }
                    var ApplicationForm = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[0].FileName), "ApplicationForm", Path.GetExtension(file[0].FileName));
                   var ExtentionfileUpload  = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[0].FileName), "ExtentionfileUpload", Path.GetExtension(file[0].FileName));
                   var MonthlyPaySlip = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[1].FileName), "Quotation", Path.GetExtension(file[0].FileName));
                    var Quotation = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[2].FileName), "MonthlyPaySlip", Path.GetExtension(file[0].FileName));
                    var CancelledCheque = string.Format("{1}{2}", Path.GetFileNameWithoutExtension(file[3].FileName), "CancelledCheque", Path.GetExtension(file[0].FileName));

                CarPcModel carPcModel = new CarPcModel();
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
                {
                    foreach (HttpPostedFileBase fileobj in file)
                    {
                        if (fileobj.ContentType == "application/pdf")
                        {
                            if (fileobj != null)
                            {
                                string _FileName = null;
                                if (count == 0)
                                {
                                    _FileName = Path.GetFileName(ApplicationForm);
                                }
                                if (count == 1)
                                {
                                    _FileName = Path.GetFileName(ExtentionfileUpload);
                                }

                                if (count == 2)
                                {
                                    _FileName = Path.GetFileName(MonthlyPaySlip);
                                }
                                if (count == 3)
                                {
                                    _FileName = Path.GetFileName(Quotation);
                                }
                                if (count == 4)
                                {
                                    _FileName = Path.GetFileName(CancelledCheque);
                                }
                                if (count == 5)
                                {
                                    _FileName = Path.GetFileName(DrivingLicense);
                                }
                                if (count == 6)
                                {
                                    _FileName = Path.GetFileName(CopyofAadharCard);
                                }
                                if (count == 7)
                                {
                                    _FileName = Path.GetFileName(CopyofPANCard);
                                }
                                if (count == 8)
                                {
                                    _FileName = Path.GetFileName(RC);
                                }
                                if (count == 9)
                                {
                                    _FileName = Path.GetFileName(Insurance);
                                }


                            

                                //if(carPcModel.ApplicationForm!=null)
                                //{ 
                                if(_FileName!="")
                                {
                                    carPcModel.ApplicationForm = collection["ApplicationType"] + collection["Army_No"];
                                    carPcModel.Application_Id = Convert.ToInt32(collection["Application_Id"]);
                                    string _path = Path.Combine(Server.MapPath("~/upload/" + collection["ApplicationType"] + collection["Army_No"]), _FileName);
                                    bool exists = System.IO.Directory.Exists(Server.MapPath("~/upload/" + collection["ApplicationType"] + collection["Army_No"]));
                                    if (!exists)
                                        System.IO.Directory.CreateDirectory(Server.MapPath("~/upload/" + collection["ApplicationType"] + collection["Army_No"]));
                                    fileobj.SaveAs(_path);
                                    //}
                                    //else
                                    //{
                                    //    ViewBag.Message1 = "File upload failed!!";
                                    //    return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = collection["Application_Id"].TrimEnd() });
                                    //}
                                }

                                count++;

                            }
                        }
                        else
                        {
                            ts.Dispose();                            
                            DisplayMessage("File Format Not Supported!! Please Select pdf only", "", "i");
                        //    return RedirectToAction("upload", "LoanApplication");
                            return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = collection["Application_Id"].TrimEnd(), callaction = "upload"});
                        }
                    }
                }
                  con.updateApplication(carPcModel);

              //  con.Entry(carPcModel).State = EntityState.Modified;
              //  con.SaveChanges();

                ViewBag.Message1 = "File Uploaded Successfully!!";
                DisplayMessage("File Uploaded Successfully!!", "", "i");
                return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = EncryptDecrypt.Encryption(collection["Application_Id"].TrimEnd()) , callaction = "upload" });
                // return View("Search");
                //return RedirectToAction("Search1", "Car_PC_Advance_Application", new { id = collection["Application_Id"].TrimEnd(), status = "mess1" });
            }
            catch (Exception ex)
            {
                ViewBag.Message1 = "File upload failed!!";
                return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = collection["Application_Id"].TrimEnd() });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ExtentionfileUpload , [Bind(Include = "Application_Id,ApplicationType,DateTimeUpdated," +
    "Loanee_Name,Army_No,Old_Army_No," +
    "Rank,Regt_Corps,Unit,CDA_PAO,Date_Of_Birth,Enrollment_Date," +
    "Promotion_Date,Retirement_Date,Year_Of_Service," +
    "Residual_Service,Salary_Slip_Month_Year," +
    "CDA_Account_No,Basic_Salary," +
    "Rank_Grade_Pay,DSOP_AFPP,MSP," +
    "AGIF,NPA_X_Pay,Income_Tax_Monthly," +
    "Tech_Pay,TPTL_Pay,PLI,DA," +
    "MISC,MISC_Pay,Total,Salary_After_Deduction,Dealer_Name,Vehicle_Name,Vehicle_Make," +
    "Total_Cost,Amount_Applied_For_Loan,No_Of_EMI_Applied,Inst_No1_Amount," +
    "Inst_No1_Date,Inst_No2_Amount,Inst_No2_Date,Inst_No3_Amount," +
    "Inst_No3_Date,Inst_No4_Amount,Inst_No4_Date,Inst_No5_Amount," +
    "Inst_No5_Date,Pers_Address_Line1,Pers_Address_Line2," +
    "Pers_Address_Line3,Pers_Address_Line4,Pin_Code," +
    "Site_Address_Line1,Site_Address_Line2,Site_Address_Line3," +
    "Site_Address_Line4,Site_City,Site_Pin,Payee_Account_No," +
    "IFSC_Code,Mobile_No,E_Mail_Id,Payable_In_Favour_Of," +
    "Dispatch_Type,City_Branch_Code_Search,Payable_To," +
    "Dispatch_Address_Line1,Dispatch_Address_Line2,Dispatch_Address_Line3," +
    "Dispatch_Address_Line4,CarLoanType,Previous_Loan_Source,Previous_Loan_Purpose," +
    "Amount,EMI,Previous_Loan_Is_Paid,Status,UpdatedBy,AadharNo,PANNo," +
    "FrequencyOfLoan,Loan_amount_admissible,Next_Fmn_Hq,Unit_Pin,Unit_Address,Extension_of_Service_in_Present_Rank,Veh_Type,Amt_Eligible_for_loan,EMI_Eligible_for_loan")] CarPcModel car_PC_Advance_Application, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    if (collection["prefixnum"] == "ok")
                    {
                        collection["prefixnum"] = "";
                    }

                    if (collection["oldprefixnum"] == "ok")
                    {
                        collection["oldprefixnum"] = "";
                    }

<<<<<<< HEAD
=======
                   
                   
                    car_PC_Advance_Application.Army_No = collection["prefixnum"] + collection["IC"] + collection["sufixnum"];

                    car_PC_Advance_Application.Old_Army_No = collection["prefixnum"] + collection["oldIC"] + collection["oldsufixnum"];
>>>>>>> cc0fd982df66e8895ac39474586d345b2433c359


                    car_PC_Advance_Application.Army_No = collection["prefixnum"] + collection["IC"] + collection["sufixnum"];

                    car_PC_Advance_Application.Old_Army_No = collection["Oldprefixnum"] + collection["oldIC"] + collection["oldsufixnum"];


                    //CarPcModel carPc = con.carPcModel.FirstOrDefault(x => x.Army_No == car_PC_Advance_Application.Army_No && x.ApplicationType == car_PC_Advance_Application.ApplicationType);


                    //if (carPc == null)
                    //{
                        car_PC_Advance_Application.DateTimeUpdated = DateTime.Now;
                        car_PC_Advance_Application.UpdatedBy = User.Identity.Name;
                        car_PC_Advance_Application.Status = "New Application";

                        car_PC_Advance_Application.Loanee_Name = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Loanee_Name);
                        car_PC_Advance_Application.AadharNo = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.AadharNo);
                        car_PC_Advance_Application.PANNo = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.PANNo);

                        car_PC_Advance_Application.Mobile_No = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Mobile_No);
                        car_PC_Advance_Application.E_Mail_Id = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.E_Mail_Id);


                    car_PC_Advance_Application.Regt_Corps = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Regt_Corps);
                    car_PC_Advance_Application.Unit = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Unit);
                    car_PC_Advance_Application.CDA_Account_No = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.CDA_Account_No);

                    car_PC_Advance_Application.Pers_Address_Line1 = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Pers_Address_Line1);
                    car_PC_Advance_Application.Pers_Address_Line2 = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Pers_Address_Line2);
                    car_PC_Advance_Application.Pers_Address_Line3 = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Pers_Address_Line3);
                    car_PC_Advance_Application.Pers_Address_Line4 = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Pers_Address_Line4);
                    car_PC_Advance_Application.Pin_Code = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Pin_Code);

                    car_PC_Advance_Application.Payee_Account_No = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Payee_Account_No);

                    car_PC_Advance_Application.IFSC_Code = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.IFSC_Code);
                    car_PC_Advance_Application.Unit_Pin = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Unit_Pin);

                    car_PC_Advance_Application.CDA_PAO = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.CDA_PAO);

                    car_PC_Advance_Application.Army_No = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Army_No);
                    car_PC_Advance_Application.Old_Army_No = EncryptDecrypt.EncryptionData(car_PC_Advance_Application.Old_Army_No);

                    con.carPcModel.Add(car_PC_Advance_Application);
                        con.SaveChanges();

                        int id = Convert.ToInt32(car_PC_Advance_Application.Application_Id);
                        TempData["ApplicationId"] = id;
                        ModelState.Clear();
                        TempData["Message"] = "Application Successfully Submit!!";

                        return RedirectToAction("Search", "Car_PC_Advance_Application", new { id = EncryptDecrypt.Encryption(car_PC_Advance_Application.Application_Id.ToString()), callaction = "download" });
                    //}
                    //else
                    //{
                    //    ViewBag.Message = "You have already applied for a loan in this category.";
                    //    ModelState.Clear();
                    //    return View(car_PC_Advance_Application);
                    //}
                }
                //catch (Exception ex)
                //{
                //    //Exception.ex;
                //    return RedirectToAction("Create");
                //}
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                    // Redirect to the Create page with error message
                    TempData["message"] = "Something went wrong while processing your request. Please try again.";
                    ModelState.Clear();
                    return RedirectToAction("Create"); // re-throw the exception to let it bubble up and be handled by the global exception handler or catch block higher up in the call stack
                }
            }
            else
            {
                TempData["message"] = "Something went wrong while processing your request. Please try again. !!";
                ModelState.Clear();
                //return View(car_PC_Advance_Application);
                return RedirectToAction("Create");
            }
       
          
        }

        

        // GET: Car_PC_Advance_Application/Edit/5
        public ActionResult Edit(String id)
        {
            try
            { 
                //Nitesh 15-02-23
                int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //Nitesh 15-02-23
                CarPcModel car_PC_Advance_Application = con.carPcModel.Find(NewId);
                if (car_PC_Advance_Application == null)
                {
                    return HttpNotFound();
                }
                return View(car_PC_Advance_Application);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Car_PC_Advance_Application/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Application_Id,DateTimeUpdated,Loanee_Name,Army_No,Old_Army_No,Rank,Regt_Corps,Unit,CDA_PAO,Date_Of_Birth,Enrollment_Date,Promotion_Date,Retirement_Date,Year_Of_Service,Residual_Service,Salary_Slip_Month_Year,CDA_Account_No,Basic_Salary,Rank_Grade_Pay,DSOP_AFPP,MSP,AGIF,NPA_X_Pay,Income_Tax_Monthly,Tech_Pay,Rev_IT,TPTL_Pay,PLI,DA,MISC,MISC_Pay,Total,Salary_After_Deduction,Dealer_Name,Vehicle_Name,Vehicle_Make,Total_Cost,Amount_Applied_For_Loan,No_Of_EMI_Applied,Inst_No1_Amount,Inst_No1_Date,Inst_No2_Amount,Inst_No2_Date,Inst_No3_Amount,Inst_No3_Date,Inst_No4_Amount,Inst_No4_Date,Inst_No5_Amount,Inst_No5_Date,Pers_Address_Line1,Pers_Address_Line2,Pers_Address_Line3,Pers_Address_Line4,Pin_Code,Site_Address_Line1,Site_Address_Line2,Site_Address_Line3,Site_Address_Line4,Site_City,Site_Pin,Payee_Account_No,IFSC_Code,Mobile_No,E_Mail_Id,Payable_In_Favour_Of,Dispatch_Type,City_Branch_Code_Search,Payable_To,Dispatch_Address_Line1,Dispatch_Address_Line2,Dispatch_Address_Line3,Dispatch_Address_Line4,Previous_Loan_Source,Previous_Loan_Purpose,Amount,EMI,Previous_Loan_Is_Paid,Status,UpdatedBy")] CarPcModel car_PC_Advance_Application)
        {
            if (ModelState.IsValid)
            {
                con.Entry(car_PC_Advance_Application).State = EntityState.Modified;
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car_PC_Advance_Application);
        }


       // POST: Car_PC_Advance_Application/Edit/5
         //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         //more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditA([Bind(Include = "Status")] CarPcModel car_PC_Advance_Application)
        {
            if (ModelState.IsValid)
            {

                con.Entry(car_PC_Advance_Application).State = EntityState.Modified;
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car_PC_Advance_Application);
        }


        // GET: Car_PC_Advance_Application/Delete/5
        public ActionResult Delete(String id)
        {
            try
            { 
                //Nitesh 15-02-23
                int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //Nitesh 15-02-23
                CarPcModel car_PC_Advance_Application = con.carPcModel.Find(NewId);
                if (car_PC_Advance_Application == null)
                {
                    return HttpNotFound();

                }
                return View(car_PC_Advance_Application);
            }
            catch
            {
                return View("Error");
            }
        }
        public List<FileInf> GetFile(string folderName)
        {

            List<FileInf> listFiles = new List<FileInf>();

            string fileSavePath = System.Web.Hosting.HostingEnvironment.MapPath("~/upload/" + folderName);

            DirectoryInfo dirInfo = new DirectoryInfo(fileSavePath);

            int i = 0;

            try
            {
                foreach (var item in dirInfo.GetFiles())
                {
                    listFiles.Add(new FileInf()
                    {

                        FileId = i + 1,

                        FileName = item.Name,

                        FilePath = dirInfo.FullName + @"\" + item.Name

                    });

                    i = i + 1;

                }
            }
            catch(Exception ex)
            {
                ViewBag.Data = "Already Download.";
            }

            return listFiles;

        }
        public static void Empty(DirectoryInfo directory)
        {
            if (directory != null)
            {
                foreach (FileInfo file in directory.GetFiles()) file.Delete();
                foreach (DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
            }
        }
        public ActionResult Download(string folderName)
        {
            try
            {
                folderName = folderName.Trim();
                var filesCol = GetFile(folderName).ToList();

                using (var memoryStream = new MemoryStream())
                {
                    using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        for (int i = 0; i < filesCol.Count; i++)
                        {
                            ziparchive.CreateEntryFromFile(filesCol[i].FilePath, filesCol[i].FileName);

                        }
                    }
                    string fileSavePath = System.Web.Hosting.HostingEnvironment.MapPath("~/upload/" + folderName);
                    DirectoryInfo attachments_AR = new DirectoryInfo(fileSavePath);
                    Empty(attachments_AR);
                    Directory.Delete(fileSavePath);

                    return File(memoryStream.ToArray(), folderName + "/zip", folderName + ".zip");

                }
            }
            catch
            {
                return View("Error");
            }

        }

        // POST: Car_PC_Advance_Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id)
        {
            try
            {
                //Nitesh 15-02-23
                int NewId = Convert.ToInt32(EncryptDecrypt.Decryption(id));
                //Nitesh 15-02-23
                CarPcModel car_PC_Advance_Application = con.carPcModel.Find(NewId);

                con.carPcModel.Remove(car_PC_Advance_Application);
                con.SaveChanges();
                return RedirectToAction("Index");
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
                // Redirect to the Create page with error message
                TempData["message"] = "Something went wrong while processing your request. Please try again.";
                ModelState.Clear();
                return RedirectToAction("Create"); // re-throw the exception to let it bubble up and be handled by the global exception handler or catch block higher up in the call stack
            }
            //catch
            //{
            //    return View("Error");
            //}
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                con.Dispose();
            }
            base.Dispose(disposing);
        }



        public ActionResult LoadDropdownOptions(string parameter)
        {
            // Use the parameter as needed in your method
            DBConnection con = new DBConnection();
            var data = con.CDA_PAOList(parameter);
        
            return Json(data, JsonRequestBehavior.AllowGet);
        }
<<<<<<< HEAD
       
=======

        
>>>>>>> cc0fd982df66e8895ac39474586d345b2433c359
        [HttpGet]
        public ActionResult CheckArmyNo(string frequency)
        {
            DBConnection con = new DBConnection();
            var data = con.CheckArmyNo(frequency);/* parameter*/

            return Json(data, JsonRequestBehavior.AllowGet);
            
        }
    }
}
