using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;
using System.Data;
using System.IO;
using System.Configuration;
using OnlineExam.Common;

namespace OnlineExam
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            if (objErr is HttpException) return;
            //log.Fatal(objErr.Message, objErr);

            StreamWriter sw = CreateFile(); //cretating Log File and Returns the file handler.
            sw.Write("\r\nApplication Started : ");
            sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            for (int i = 0; i < 200; i++)
                sw.Write("-");
            sw.WriteLine();
            sw.WriteLine("ResDetId = " + CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId.ToString());
            sw.WriteLine(objErr.Message.ToString());
            sw.WriteLine(objErr.ToString());
            sw.Close();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static StreamWriter CreateFile()
        {
            string fileName = "IIHTOLExmLog" + DateTime.Now.ToString("MMyyyy");
            string fileLoc = ConfigurationManager.AppSettings["logfile"].ToString() + fileName + ".txt";
            fileLoc = fileLoc.Replace("\\\\", "\\");
            // HostingEnvironment.MapPath()
            // This text is added only once to the file.
            if (!File.Exists(fileLoc))
            {
                // Create a file to write to.
                StreamWriter sw = File.CreateText(fileLoc);
                return sw;

            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                StreamWriter sw = File.AppendText(fileLoc);
                return sw;

            }
        }
    }
}