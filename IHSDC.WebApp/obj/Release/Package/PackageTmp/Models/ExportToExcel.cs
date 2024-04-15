using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using System.Data;

namespace IHSDC.WebApp.Models
{
    public class ExportToExcel:Controller
    {
       // private IHSDCAGIFDBEntities db = new IHSDCAGIFDBEntities();
        //public void export(DataSet ds)
        //{
        //    var gv = new GridView();
        //    gv.DataSource = db.Car_PC_Advance_Application.ToList();
        //    gv.DataBind();
        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.Charset = "";
        //    StringWriter objStringWriter = new StringWriter();
        //    HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
        //    gv.RenderControl(objHtmlTextWriter);
        //    Response.Output.Write(objStringWriter.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
    }
}