using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.IO;
//using iTextSharp.text.html.simpleparser;
using Microsoft.Reporting;
using Microsoft.Reporting.WebForms;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Compression.Zip;
using IHSDC.WebApp.Models;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace IHSDC.WebApp.Controllers
{
    public class ITCERTController : Controller
    {
        //  private IHSDCAGIFDBEntities db = new IHSDCAGIFDBEntities();
        // GET: ITCERT

        DBConnection con = new DBConnection();

        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult upload()
        {
            return View("UploadITCERTData");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentType == "text/plain")
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        file.SaveAs(_path);
                    }

                    if (Path.GetFileName(file.FileName) != "LOANEE.txt")
                    {
                        certModel model = new certModel();
                        string[] numbers = Regex.Split(Path.GetFileName(file.FileName), @"\D+");
                        model.certType = Path.GetFileName(file.FileName).Substring(0, 6);
                        model.year = numbers[1];
                        con.insertcert(model);
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View("UploadITCERTData");
                }
                else
                {
                    ViewBag.Message = "Please Upload txt file only!!";
                    return View("UploadITCERTData");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.StackTrace;
                return View("UploadITCERTData");
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
        public ActionResult Index1(FormCollection collections)
        {
            bool folio = false;
            string no = (collections["FolioNo"]).ToUpper();
            foreach (char c in  collections["FolioNo"].ToString().ToUpper())
            {
                if(c=='/')
                {
                    folio = true;
                }
            }

            if (folio == false)
            {
                collections["FolioNo"] = Regex.Match(collections["FolioNo"].ToString(), @"\d+").Value;
            }

            string str = collections["FolioNo"].ToString().ToUpper();

            if (str != "")
            {
                string[] lines1 = System.IO.File.ReadAllLines(Path.Combine(Server.MapPath("~/UploadedFiles/LOANEE.txt")));

                string[] result1 = null ;
                foreach (string data1 in lines1)
                {
                    string[] dd = data1.Split('~');

                    var results = Array.FindAll(dd, s => s.Equals(str));
                    
                    if(results.Length!=0)
                    {
                        result1 = dd;
                        str = result1[5];
                    }
                }

                if (result1 != null)
                {

                    string[] rows1 = result1; //result1[0].Split('~');
                    //if (rows1[1] == str || rows1[5] == str)
                    //{

                        if (collections["ltype"].ToString() == "Final")
                        {
                            try
                            {
                                string[] lines = System.IO.File.ReadAllLines(Path.Combine(Server.MapPath("~/UploadedFiles/HBAFIN.txt")));
                                //var result = lines.Where(x => x==rows1[5]).ToList();

                                string[] rows = null;

                                foreach (string singleRow in lines)
                                {
                                    string[] singleRow1 = singleRow.Split('~');

                                    var results = Array.FindAll(singleRow1, s => s.Equals(rows1[5]));

                                    if (results.Length != 0)
                                    {
                                        rows = singleRow1;
                                    }
                                }

                              //  string[] rows = result[0].Split('~');


                                var data1 = new List<FinalITCERT> {
                //finalITCERT = finalITCERT as IEnumerable<FinalITCERT>;
                new FinalITCERT(){
                type = rows[0],
            foliono = rows[1],
            fromdate = rows[2],
            todate = rows[3],
            rank = rows[5],
            name = rows[6],
            typeofloan = rows[7],
            totalloanAmt = rows[8],
            loancategory = rows[9],
            totalpaid = rows[10],
            principlepaid = rows[11],
            interestpaid = rows[12],
            priemipaid = rows[13],
            frompriemidate = rows[14],
            uptopriemidate = rows[15],
            totalprincipleoutstanding = rows[17],
            currentDate = DateTime.Now.ToString("dd-MMM-yyyy")
        }
        };
                                LocalReport localreport = new LocalReport();
                                localreport.ReportPath = Server.MapPath("~/Report/Final.rdlc");

                                ReportDataSource reportDataSource = new ReportDataSource();
                                reportDataSource.Name = "DataSet1";
                                reportDataSource.Value = data1;
                                localreport.DataSources.Add(reportDataSource);
                                String reportingitem = ".pdf";
                                String mimeType;
                                String encoding;
                                String[] stream;
                                Warning[] warning;
                                byte[] renderedbyte;
                                renderedbyte = localreport.Render("PDF", "", out mimeType, out encoding, out reportingitem, out stream, out warning);
                                Response.AddHeader("content-disposition", "attachment;filename=Final." + reportingitem);
                                return File(renderedbyte, reportingitem);
                            }
                            catch
                            {
                                ViewBag.data = "Not Found!";
                                return View("Index");
                            }

                        }
                        else
                        {
                            try
                            {
                                string[] lines = System.IO.File.ReadAllLines(Path.Combine(Server.MapPath(("~/UploadedFiles/HBAPRO.txt"))));

                              //  var result = lines.FirstOrDefault(x => x.Contains(collections["FolioNo"].ToString()));

                                string[] rows = null;

                                foreach (string singleRow in lines)
                                {
                                    string[] singleRow1 = singleRow.Split('~');

                                    var results = Array.FindAll(singleRow1, s => s.Equals(str));

                                    if (results.Length != 0)
                                    {
                                        rows = singleRow1;
                                    }
                                }

                               // string[] rows = result.Split('~');


                                var data1 = new List<FinalITCERT> {
                //finalITCERT = finalITCERT as IEnumerable<FinalITCERT>;
                new FinalITCERT(){
                type = rows[0],
            foliono = rows[1],
            fromdate = rows[2],
            todate = rows[3],
            rank = rows[5],
            name = rows[6],
            typeofloan = rows[7],
            totalloanAmt = rows[8],
            loancategory = rows[9],
            totalpaid = rows[10],
            principlepaid = rows[11],
            interestpaid = rows[12],
            principleAmtduefornextyear = rows[14],
            interest = rows[15],
            currentDate = DateTime.Now.ToString("dd-MMM-yyyy")
        }
        };
                                LocalReport localreport = new LocalReport();
                                localreport.ReportPath = Server.MapPath("~/Report/Pro.rdlc");

                                ReportDataSource reportDataSource = new ReportDataSource();
                                reportDataSource.Name = "DataSet1";
                                reportDataSource.Value = data1;
                                localreport.DataSources.Add(reportDataSource);
                                String reportingitem = ".pdf";
                                String mimeType;
                                String encoding;
                                String[] stream;
                                Warning[] warning;
                                byte[] renderedbyte;
                                renderedbyte = localreport.Render("PDF", "", out mimeType, out encoding, out reportingitem, out stream, out warning);
                                Response.AddHeader("content-disposition", "attachment;filename=Pro." + reportingitem);
                                return File(renderedbyte, reportingitem);
                            }
                            catch (Exception ex)
                            {
                                ViewBag.data = "Not Found";
                                return View("Index");

                            }
                        }
                    //}
                    //else
                    //{
                    //    DisplayMessage("Your ITCert does not exists!!", "", "i");
                    //}
                }
                {
                    DisplayMessage("Your ITCert does not exists!!", "", "i");
                }
            }
            else
            {
                DisplayMessage("Your ITCert does not exists!!", "", "i");
            }
            return View("Index");
        }



        public ActionResult dw()
        {
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Server.MapPath("~/Report/it.pdf"));
            loadedDocument = new PdfLoadedDocument(Server.MapPath("~/Report/it1.pdf"));
            //Create zip file     
            ZipArchive zipArchive = new ZipArchive();
            for (int i = 0; i < loadedDocument.Pages.Count; i++)
            {
                //Create a new PDF document
                PdfDocument document = new PdfDocument();
                //Imports loaded document page to the new document
                document.ImportPage(loadedDocument, i);
                //Save the document
                MemoryStream stream = new MemoryStream();
                document.Save(stream);
                //Add the files you want to zip
                zipArchive.AddItem(i + ".pdf", stream, false, FileAttributes.Normal);
            }
            //Zips the filename 
            MemoryStream memoryStream = new MemoryStream();
            zipArchive.Save(memoryStream, false);
            return File(memoryStream.ToArray(), "application/zip", "Attachments.zip");
        }
    }
}