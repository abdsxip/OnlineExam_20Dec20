using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using OnlineExam.Common;
using OE.Business.Components;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace OnlineExam
{
    public partial class Result : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateResult();
            }
        }
        private void UpdateResult()
        {
            int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            int StudId = CurrentSession.CurrStudent.StudentId;
            bool IsModuleTest = CurrentSession.CurrStudent.isModExam;
            string getDate = DateTime.Now.ToString("dd-MM-yyyy");
            string getTime = DateTime.Now.ToShortTimeString();
            getTime = getTime.Replace(":", "");
            string fileName = "EXM" + "_" + ResDetId + "_" + getDate + "_" + getTime;
            CurrentSession.FileName = fileName;
            ExamUserComponent ec = new ExamUserComponent();

            int success;
            success = ec.UpdateResult(ResDetId, StudId, fileName, IsModuleTest);
            SaveReport();
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            divView.Visible = false;
            ShowReport();
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            CurrentSession.Logout();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Close", "window.open('', '_self', '');window.close();", true);
        }
        private void SaveReport()
        {
            //clsNum2Word csw = new clsNum2Word();
            ExamUserComponent ec = new ExamUserComponent();
            int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            int StudId = CurrentSession.CurrStudent.StudentId;
            string FileName = CurrentSession.FileName.ToString();
            bool isModExam = CurrentSession.CurrStudent.isModExam;

            DataSet dsComp = ec.GetCompInfo();
            DataSet dsExamRes = ec.GetExamResultPrint(ResDetId, StudId, 1, false);
            DataSet dsExResSum = ec.GetExamResultPrint(ResDetId, StudId, 2, false);

            Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
            rview.ProcessingMode = ProcessingMode.Local;
            rview.LocalReport.ReportPath = Server.MapPath("~/eReports/Rdlc/rpt_examResult.rdlc");

            rview.LocalReport.DataSources.Clear();
            rview.LocalReport.DataSources.Add(new ReportDataSource("dsCompInfo", dsComp.Tables[0]));
            rview.LocalReport.DataSources.Add(new ReportDataSource("dsResPrint", dsExamRes.Tables[0]));
            rview.LocalReport.DataSources.Add(new ReportDataSource("dsExamSum", dsExResSum.Tables[0]));
            rview.LocalReport.Refresh();

            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;

            //Desired format goes here (PDF, Excel, or Image) 
            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            byte[] bytes = rview.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Clear();

            System.IO.FileStream oFileStream = null;
            string strFilePath = string.Empty;
            //strFilePath = ConfigurationManager.AppSettings["AttachFile"].ToString() + FileName + ".pdf";// Server.MapPath("../EmailAttachments/" + filename1 + ".pdf");
            //strFilePath = strFilePath.Replace("\\\\", "\\");
            strFilePath = Server.MapPath("~/AttachFile/" + FileName + ".pdf");
            oFileStream = new System.IO.FileStream(strFilePath, System.IO.FileMode.Create);
            oFileStream.Write(bytes, 0, bytes.Length);
            oFileStream.Close();

            //string script = string.Format("~/eReports/PdfReport.aspx?FileName={0}", FileName);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "openprintwindow", "javascript:window.open('" + ResolveClientUrl(script) + "',null,'width=850px,height=630px,scrollbars=yes,,resizable=yes,toolbar=no,menubar=no,location=no');", true);

        }
        private void ShowReport()
        {
            
            ExamUserComponent ec = new ExamUserComponent();
            int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            int StudId = CurrentSession.CurrStudent.StudentId;
            string isDetailed = "0";
            //if (chkIsDetailed.Checked)
                //isDetailed = "2";
            bool isModExam = CurrentSession.CurrStudent.isModExam;
            string FileName = hdnFileName.Value;

            DataSet dsComp = ec.GetCompInfo();
            DataSet dsExamRes = ec.GetExamResultPrint(ResDetId, StudId,1,false);
            DataSet dsExResSum = ec.GetExamResultPrint(ResDetId, StudId, 2, false);

            Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
            rview.ProcessingMode = ProcessingMode.Local;
            rview.LocalReport.ReportPath = Server.MapPath("~/eReports/Rdlc/rpt_examResult.rdlc");

            rview.LocalReport.DataSources.Clear();
            rview.LocalReport.DataSources.Add(new ReportDataSource("dsCompInfo", dsComp.Tables[0]));
            rview.LocalReport.DataSources.Add(new ReportDataSource("dsResPrint", dsExamRes.Tables[0]));
            rview.LocalReport.DataSources.Add(new ReportDataSource("dsExamSum", dsExResSum.Tables[0]));
            rview.LocalReport.Refresh();

            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;

            //Desired format goes here (PDF, Excel, or Image) 
            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            byte[] bytes = rview.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = mimeType;

            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=Result.PDF");
            System.Web.HttpContext.Current.Response.BinaryWrite(bytes);
            System.Web.HttpContext.Current.Response.End();
        }
    }
}

/*
 private void SaveReport()
        {
            //clsNum2Word csw = new clsNum2Word();
            int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            int StudId = CurrentSession.CurrStudent.StudentId;
            string FileName = CurrentSession.FileName.ToString();
            bool isModExam = CurrentSession.CurrStudent.isModExam;
            Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
            rview.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServer"].ToString());
            System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter> paramList = new System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter>();

            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("ResDetId", ResDetId.ToString(), false));
            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("StudentId", StudId.ToString(), false));
            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("Type", "0", false));
            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("isModExam", isModExam.ToString(), false));
            rview.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "rpt_QnExamResult";
            rview.ServerReport.ReportServerCredentials = new Credentials(ConfigurationManager.AppSettings["ReportUserName"].ToString(), ConfigurationManager.AppSettings["ReportUserPwd"].ToString(), ConfigurationManager.AppSettings["ReportserverDomain"].ToString());
            rview.ServerReport.SetParameters(paramList);
            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;

            //Desired format goes here (PDF, Excel, or Image) 
            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            byte[] bytes = rview.ServerReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Clear();

            System.IO.FileStream oFileStream = null;
            string strFilePath = string.Empty;
            strFilePath = ConfigurationManager.AppSettings["AttachFile"].ToString() + FileName + ".pdf";// Server.MapPath("../EmailAttachments/" + filename1 + ".pdf");
            strFilePath = strFilePath.Replace("\\\\", "\\");
            oFileStream = new System.IO.FileStream(strFilePath, System.IO.FileMode.Create);
            oFileStream.Write(bytes, 0, bytes.Length);
            oFileStream.Close();

            //string script = string.Format("~/eReports/PdfReport.aspx?FileName={0}", FileName);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "openprintwindow", "javascript:window.open('" + ResolveClientUrl(script) + "',null,'width=850px,height=630px,scrollbars=yes,,resizable=yes,toolbar=no,menubar=no,location=no');", true);

        }
        private void ShowReport()
        {
            int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            int StudId = CurrentSession.CurrStudent.StudentId;
            string isDetailed = "0";
            //if (chkIsDetailed.Checked)
                //isDetailed = "2";
            bool isModExam = CurrentSession.CurrStudent.isModExam;
            string FileName = hdnFileName.Value;
            Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();
            rview.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServer"].ToString());
            System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter> paramList = new System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter>();

            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("ResDetId", ResDetId.ToString(), false));
            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("StudentId", StudId.ToString(), false));
            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("Type", isDetailed, false));
            paramList.Add(new Microsoft.Reporting.WebForms.ReportParameter("isModExam", isModExam.ToString(), false));
            rview.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "rpt_QnExamResult";

            rview.ServerReport.ReportServerCredentials = new Credentials(ConfigurationManager.AppSettings["ReportUserName"].ToString(), ConfigurationManager.AppSettings["ReportUserPwd"].ToString(), ConfigurationManager.AppSettings["ReportserverDomain"].ToString());
            rview.ServerReport.SetParameters(paramList);
            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;

            //Desired format goes here (PDF, Excel, or Image) 
            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            byte[] bytes = rview.ServerReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = mimeType;

            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=Result.PDF");
            System.Web.HttpContext.Current.Response.BinaryWrite(bytes);
            System.Web.HttpContext.Current.Response.End();

        }
*/