using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace OnlineExam.eReports
{
    public partial class PdfReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["FileName"] != "" && Request.QueryString["FileName"] != null)
                {
                    ShowReport(Request.QueryString["FileName"].ToString());
                }
            }
        }
        private void ShowReport(string fileName)
        {
            string fileExtension = ".pdf";
            string contentType = "";
            if (Request.QueryString["FileExtension"] != null && Request.QueryString["FileExtension"] != "")
            {
                fileExtension = Convert.ToString(Request.QueryString["FileExtension"]);
            }

            if (fileExtension == ".pdf")
            {
                contentType = "application/pdf";
            }
            else
                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    contentType = "application/ms-excel";
                }

            string strFilePath = ConfigurationManager.AppSettings["AttachFile"].ToString() + fileName + fileExtension;
            strFilePath = strFilePath.Replace("\\\\", "\\");
            Response.ContentType = contentType;
            Response.AddHeader("Content-disposition", "inline; filename=" + fileName + fileExtension);
            Response.WriteFile(strFilePath);
            Response.End();
        }
    }
}