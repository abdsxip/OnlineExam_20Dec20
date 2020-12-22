using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineExam.Common;
namespace OnlineExam
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = "Name : " + CurrentSession.CurrStudent.StudentName;
                lblCourse.Text = "Course : " + CurrentSession.CurrStudent.Product.ProductName;
                lblMaxMarks.Text = "Max Time : " + CurrentSession.CurrStudent.Duration + " Mins";
                lblInstName.Text = "Centre : " + CurrentSession.CurrStudent.StudentCentre.CentreName;
            }
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            //Response.Redirect("Login.aspx");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Close", "window.open('', '_self', '');window.close();", true);
        }

    }
}