using IHSDC.Common.Models;
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
using Access = Microsoft.Office.Interop.Access;

namespace IHSDC.WebApp.Controllers
{

    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {

            string value = Server.HtmlEncode("<script>alert('Boo!')</script>");

            //PdfDocument
            if (Request.Cookies.Count!=0)
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
        }

        public ActionResult ExtendedInsuranceScheme()
        {
            return View();
        }
        public ActionResult MedicalBenefitScheme()
        {
            return View();
        }
        public ActionResult SocialSecurityDepositsScheme()
        {
            return View();
        }

        public ActionResult MDprofile()
        {
            return View();
        }

        public ActionResult Bwin()
        {
            return View();
        }
        public ActionResult InsuranceCover()
        {
            return View();
        }
        public ActionResult AdditionalInsuranceCovertoArmyAviationOfficers()
        {
            return View();
        }
        public ActionResult DisabilityBenefits()
        {
            return View();
        }
        public ActionResult ExGratiaDisabilityAllowance()
        {
            return View();
        }
        public ActionResult MaturityBenefits()
        {
            return View();
        }
        public ActionResult FinalWithdrawalfromMaturityBenefit()
        {
            return View();
        }
        public ActionResult SustenanceAllowancetoDifferentlyAbledChildren()
        {
            return View();
        }
        public ActionResult BafterR()
        {
            return View();
        }

        public ActionResult MATURITY()
        {
            return View();
        }

        public ActionResult DownloadPDF()
        {
          
            return File("~/_forms/mat/RA_OFF_OCT_MAR19", "application/all");
        }
        public ActionResult DownloadPDF1()
        {
            return File("~/_forms/mat/RA_JCOR_OCT_MAR19", "application/all");
        }
        public ActionResult DownloadPDF2()
        {
            return File("~/_forms/mat/TA_OFF_OCT_MAR19", "application/all");
        }
        public ActionResult DownloadPDF3()
        {
            return File("~/_forms/mat/TA_JCOR_OCT_MAR19", "application/all");
        }
        public ActionResult DownloadPD4()
        {
            return File("~/_forms/mat/APSD_OFF_OCT_MAR19", "application/all");
        }
        public ActionResult DownloadPDF5()
        {
            return File("~/_forms/mat/APSD_JCOR_OCT_MAR19", "application/all");
        }
        public ActionResult DownloadPDF6()
        {
            return File("~/_forms/mat/DSC_JCOR_OCT_MAR19", "application/all");
        }

        public ActionResult LatestNews()
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

        public ActionResult importantLetter()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/PRE-EMI REVISION.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult importantLetter1()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/AGIF Loan  Inward Payment Using NEFT.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult importantLetter2()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/REVISION OF POLICY FOR GRANT OF HBA.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult importantLetter3()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/Review of HBA.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult importantLetter4()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/Provisioning of IT Rebate Certificate .pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult importantLetter5()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/Benevolent Reserve Fund.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult importantLetter6()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/FRAUD.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult ImportantLetter7()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/AGI Journal.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }




        public ActionResult ImportantLetter8()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/REVISED NOMINATION FORM.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }


        public ActionResult faq()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_claims.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult Faq1()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_advances_general.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult Faq2()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_HBA.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult faq3()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_CA.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult faq4()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/faq/faq_PCA.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ITCERT()
        {
            return View("Index","ITCERT");
        }

        public ActionResult HBAApplication()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/HBA/HBA Form/HBA Application.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }

        public ActionResult SavingElements()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/Saving Element.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }
        public ActionResult MessagefromAGIF()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/important/SMS.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }

        public ActionResult TelNoAgif()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/UploadedFiles/Tele No AGIF.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }


        public ActionResult Guidelines()
        {
            PdfReader PDFReader = new PdfReader(Server.MapPath("/HBA/General Guidelines/GENERAL_GUIDELINES.pdf"));
            openPdf(PDFReader);
            return File("~/faq/test.pdf", "application/pdf");
        }

        public void openPdf(PdfReader PDFReader)
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
    }
}