using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHSDC.WebApp.Controllers
{
    public class LoanCertController : Controller
    {
        // GET: LoanCert
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

        [HttpPost]
        public ActionResult Index1(FormCollection collections)
        {
            try
            { 
                string[] fileArray = Directory.GetFiles(Server.MapPath("/loanCert"));

                foreach(var path in fileArray)
                {
                    if(path.Contains(collections["FolioNo"]))
                    {
                   

                        byte[] fileBytes = GetFile(path);
                        return File(
                            fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(path));
                    }
                
                    
                
                }
                DisplayMessage("Your LoanCert does not exists!!", "", "i");
                return View("Index");
            }
            catch
            {
                return View("Error");
            }

        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
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

    }
}