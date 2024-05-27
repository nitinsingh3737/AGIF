using IHSDC.WebApp.Models;
using iTextSharp.text.pdf;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
//using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Data;
using static System.Net.WebRequestMethods;
using Access = Microsoft.Office.Interop.Access;

namespace IHSDC.WebApp.Controllers
{

    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            //try
            //{ 
                string value = Server.HtmlEncode("<script>alert('Boo!')</script>");

                //PdfDocument
                if (Request.Cookies.Count != 0)
                {
                    object data = Request.Cookies;
                }
                //Access.Application oAccess = new Access.ApplicationClass();
                //oAccess.OpenCurrentDatabase(@"C:\Users\master\Desktop\TA Dte Final Copy.accdb", true, null);

                //object data = oAccess.Modules["fun"];

                //string data = Session["UserIntId"].ToString();
                using (var db = new ApplicationDbContext())
                {
                    //  ViewBag.TotalUser = db.Users.ToList().Count();
                    //  ViewBag.OnlineUsers = db.Logins.Count(o => o.IsLoggedIn);
                    //   ViewBag.TotalVisits = db.Visits.ToList().Count();
                }
                return View();
            //}
            //catch
            //{
            //    return View("Error");
            //}
        }

        public ActionResult ExtendedInsuranceScheme()
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
        public ActionResult MedicalBenefitScheme()
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
        public ActionResult SocialSecurityDepositsScheme()
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

        public ActionResult MDprofile()
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

        public ActionResult Bwin()
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
        public ActionResult InsuranceCover()
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
        public ActionResult AdditionalInsuranceCovertoArmyAviationOfficers()
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
        public ActionResult DisabilityBenefits()
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
        public ActionResult ExGratiaDisabilityAllowance()
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
        public ActionResult MaturityBenefits()
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
        public ActionResult FinalWithdrawalfromMaturityBenefit()
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
        public ActionResult SustenanceAllowancetoDifferentlyAbledChildren()
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
        public ActionResult BafterR()
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

        public ActionResult MATURITY()
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

        //public ActionResult DownloadPDF()
        //{
        //    try 
        //    { 
        //        return File("~/Home/LetterWatermark?pdf=/_forms/mat/RA_OFF_OCT_MAR19.pdf", "application/pdf");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
        //public ActionResult DownloadPDF1()
        //{
        //    try
        //    { 
        //        return File("~/Home/LetterWatermark?pdf=/_forms/mat/RA_JCOR_OCT_MAR19.pdf", "application/pdf");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
        //public ActionResult DownloadPDF2()
        //{
        //    try
        //    { 
        //        return File("~/Home/LetterWatermark?pdf=/_forms/mat/TA_OFF_OCT_MAR19.pdf", "application/pdf");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
        //public ActionResult DownloadPDF3()
        //{
        //    try
        //    { 
        //        return File("~/Home/LetterWatermark?pdf=/_forms/mat/TA_JCOR_OCT_MAR19.pdf", "application/pdf");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
        //public ActionResult DownloadPD4()
        //{
        //    try
        //    { 
        //        return File("~/Home/LetterWatermark?pdf=/_forms/mat/APSD_OFF_OCT_MAR19.pdf", "application/pdf");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
        //public ActionResult DownloadPDF5()
        //{
        //    try
        //    {
                
        //        return File("~/Home/LetterWatermark?pdf=/_forms/mat/APSD_JCOR_OCT_MAR19.pdf", "application/pdf");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
        //public ActionResult DownloadPDF6()
        //{
        //    try
        //    { 
        //        return File("~/Home/LetterWatermark?pdf=/_forms/mat/DSC_JCOR_OCT_MAR19.pdf", "application/pdf");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}

        public ActionResult LatestNews()
        {
            try
            { 
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument("~/_forms/AGIF LATEST INFO.pdf");
                //Get first page from document
                PdfPageBase loadedPage = loadedDocument.Pages[0];
                //Create PDF graphics for the page
                PdfGraphics graphics = loadedPage.Graphics;
                //Set font for the watermark text
                Syncfusion.Pdf.Graphics.PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                //Save the graphics state for the watermark text
                PdfGraphicsState state = graphics.Save();
                //Set transparency level for the text
                graphics.SetTransparency(0.25f);
                //Rotate the text to -40 Degree
                graphics.RotateTransform(-40);
                //Draw the watermark text to the desired position over the PDF page with red color
                graphics.DrawString("Confidential", font, PdfPens.Red, PdfBrushes.Red, new PointF(0, 250));
                //Save the document
                loadedDocument.Save("watermark.pdf");
                //Close the document
                loadedDocument.Close(true);
                Process.Start("watermark.pdf");

                return File("~/_forms/AGIF LATEST INFO.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }

        
        
        
        
        public ActionResult importantLetter4()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/important/Provisioning of IT Rebate Certificate .pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }
       

        public ActionResult LetterWatermark(string pdf)
        {
            try
            {
                PdfReader PDFReader = new PdfReader(Server.MapPath(pdf));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                return View("Error");
            }
        }
        public ActionResult ImportantLetter7(string pdf)
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/important/AGI Journal.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }

        


        public ActionResult faq()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_claims.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Faq1()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_advances_general.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Faq2()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_HBA.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult faq3()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_CA.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult faq4()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_PCA.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult ContactUs()
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

        public ActionResult AboutUs()
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

        public ActionResult ITCERT()
        {
            try
            { 
                return View("Index","ITCERT");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult HBAApplication()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/HBA/HBA Form/HBA Application.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult SavingElements()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/important/Saving Element.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult MessagefromAGIF()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/important/SMS.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult TelNoAgif()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/UploadedFiles/Tele No AGIF.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult ITRebateCert()
        {
            try
            {
                PdfReader PDFReader = new PdfReader(Server.MapPath("/important/IT Rebate Cert.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Guidelines()
        {
            try
            { 
                PdfReader PDFReader = new PdfReader(Server.MapPath("/HBA/General Guidelines/GENERAL_GUIDELINES.pdf"));
                openPdf(PDFReader);
                return File("~/faq/test.pdf", "application/pdf");
            }
            catch
            {
                return View("Error");
            }
        }

        public void openPdf(PdfReader PDFReader)
        {
            try
            {
                HttpCookie myCookie = Request.Cookies["IpAddress"];
                string ipAddress = Request.UserHostAddress;
                //PdfReader PDFReader = new PdfReader(Server.MapPath("/important/FRAUD.pdf"));
                FileStream Stream = new FileStream(Server.MapPath("/faq/test.pdf"), FileMode.Create, FileAccess.Write);
                PdfStamper PDFStamper = new PdfStamper(PDFReader, Stream);
                for (int iCount = 0; iCount < PDFStamper.Reader.NumberOfPages; iCount++)
                {
                    PdfContentByte PDFData = PDFStamper.GetUnderContent(iCount + 1);
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                    PDFData.BeginText();
                    PDFData.SetColorFill(CMYKColor.LIGHT_GRAY);
                    PDFData.SetFontAndSize(baseFont, 60);
                    if (ipAddress == null)  // if(myCookie == null)
                    {
                        PDFData.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ip Address Not found!", 300, 400, 45);
                    }
                    else
                    {
                        //PDFData.ShowTextAligned(PdfContentByte.ALIGN_CENTER, myCookie.Value.ToString().Trim(new char[] { (char)39 }), 250, 400, 45);
                        PDFData.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ipAddress, 250, 400, 45);
                    }
                    PDFData.ShowTextAligned(PdfContentByte.ALIGN_CENTER, DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy HH:mm").Trim(), 300, 350, 45);
                    PDFData.EndText();
                }
                PDFStamper.FormFlattening = true;
                PDFStamper.Close();
                PDFReader.Close();
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}