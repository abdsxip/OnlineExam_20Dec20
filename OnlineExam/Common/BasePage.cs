using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace OnlineExam.Common
{
    public abstract class BasePage : Page
    {
        #region Constructors

        public BasePage()
        {
            base.Init += new EventHandler(Page_Init);
            base.Load += new EventHandler(Page_Load);
            base.PreRender += new EventHandler(Page_PreRender);
            base.Unload += new EventHandler(Page_Unload);
        }

        #endregion Constructors

        #region Delegates and Events

        protected new virtual event EventHandler Init;

        protected new virtual event EventHandler Load;

        protected new virtual event EventHandler PreRender;

        protected new virtual event EventHandler Unload;

        #endregion Delegates and Events

        #region Page Events
        protected new virtual void OnInit(EventArgs e)
        {
            // Check if the user has been already logged in
            // If not perform user authentication
            //check if user logged in

            //if (!IsPostBack)
            //{
            //check if user logged in
            if (CurrentSession.CurrStudent.StudentId == 0)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (Init != null)
                Init(this, e);
        }

        protected new virtual void OnLoad(EventArgs e)
        {

            if (Load != null)
                Load(this, e);
        }

        protected new virtual void OnPreRender(EventArgs e)
        {
            if (PreRender != null)
                PreRender(this, e);
        }

        protected new virtual void OnUnload(EventArgs e)
        {
            if (Unload != null)
                Unload(this, e);
        }


        private void Page_Init(object sender, EventArgs e)
        {
            OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            OnLoad(e);
        }

        private void Page_PreRender(object sender, EventArgs e)
        {
            OnPreRender(e);
        }

        private void Page_Unload(object sender, EventArgs e)
        {
            OnUnload(e);
        }


        #endregion
    }
}