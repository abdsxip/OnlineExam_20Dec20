using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OE.Business.Entities;
using OE.Business.Components;
using OnlineExam.Common;

namespace OnlineExam
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtUName.Text = "";
            lblInvalid.Text = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Welcome.aspx");
            string username, password;
            bool isModExm = chkIsModExam.Checked;
            username = txtUName.Text.Trim();
            password = txtPass.Text.Trim();
            var ucs = new ExamUserComponent();
            Student usr = ucs.StudExmUserLogin(username, password, isModExm);
            
            if (usr == null)
            {
               lblInvalid.Text="Invalid Credentials";
              //  WrongCredentialsError.Attributes.Add("style", "visibility:inline");
            }
            else
            {
                if (usr.StudentId == 0)
                {
                    lblInvalid.Text = "Invalid Credentials";
                  //  emptyError.Visible = false;
                   // WrongCredentialsError.Attributes.Add("style", "visibility:inline");
                }
                else if (usr.isExpired == true)
                {
                    lblInvalid.Text = "Your exam period has not yet started or has been expired ";
                }
                else if (usr.isStatus == false)
                {
                    lblInvalid.Text = "You have already taken your exam or it is not yet published";
                }
                else
                {
                    CurrentSession.CurrStudent = usr;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Close", "StartExam()", true);
                    //int centreId = CurrentSession.CurrUser.Centre.CentreId;
                    //string menustr = ucs.GetUserMenu(usr.UserType.Id.ToString(), centreId);

                    //CurrentSession.UserMenu = menustr;
                    //Response.Redirect("Welcome.aspx");
                }
            }
            
        }
    }
}