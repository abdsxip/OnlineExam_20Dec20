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
    public partial class Welcome : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNameVal.Text = CurrentSession.CurrStudent.StudentName;
            lblEnrolNoVal.Text = CurrentSession.CurrStudent.StudentRegNo;
            lblCourseVal.Text = CurrentSession.CurrStudent.Product.ProductName;
            lblMaxMarksVal.Text = Convert.ToString(CurrentSession.CurrStudent.MaxMarks);
            lblPassMrkVal.Text = Convert.ToString(CurrentSession.CurrStudent.PassMarks);
            lblValidTillVal.Text = CurrentSession.CurrStudent.ValidTill.ToString("dd/MM/yyyy");
            //hdnStatusId.Value = Convert.ToString(CurrentSession.CurrStudent.ExamResultDetail.status);
        }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Test.aspx");
            //Server.Transfer("Test.aspx");
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Close", "window.open('', '_self', '');window.close();", true);
        }
    }
}