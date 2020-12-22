using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineExam.Common;
using OE.Business.Entities;

namespace OnlineExam
{
    public partial class OnlineExam : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = "Name : " + CurrentSession.CurrStudent.StudentName;
                lblCourse.Text = "Course : " + CurrentSession.CurrStudent.Product.ProductName;
                lblMaxMarks.Text = "Max Time : " + CurrentSession.CurrStudent.Duration + " Mins";
                lblInstName.Text = "Centre : " + CurrentSession.CurrStudent.StudentCentre.CentreName;

                //lblDate.Text = "June 2013";
                //if (string.Compare(Request.Url.LocalPath, "Test.aspx") == 0)
                //{
                //    //    maek your session Null whatever you want
                //}
            }
        }

    }
}