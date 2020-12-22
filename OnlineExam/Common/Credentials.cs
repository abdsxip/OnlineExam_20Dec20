using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

namespace OnlineExam.Common
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class Credentials : IReportServerCredentials
    {
        string _userName, _password, _domain;
        public Credentials(string userName, string Password, string domain)
        {
            _userName = userName;
            _password = Password;
            _domain = domain;
        }

        #region IReportServerCredentials Members

        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            //userName = _userName;
            //password = _password;
            //authority = _domain;
            //authCookie = new System.Net.Cookie(".ASPXAUTH", ".ASPXAUTH", "/", "Domain");
            //return true;
            authCookie = null;
            userName = password = authority = null;
            return false;

        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public System.Net.ICredentials NetworkCredentials
        {
            get { return new System.Net.NetworkCredential(_userName, _password, _domain); }
        }

        #endregion
    }
}