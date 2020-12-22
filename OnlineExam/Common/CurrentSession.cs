using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OE.Business.Entities;

namespace OnlineExam.Common
{
    public class CurrentSession
    {
        /// <summary>
        /// Gets or sets the user session.
        /// </summary>
        /// <value>User entity.</value>
        public static Student CurrStudent
        {
            get
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["USER"] == null)
                {
                    Student _user = new Student();
                    return _user;
                }
                return (Student)HttpContext.Current.Session["USER"];
            }
            set { HttpContext.Current.Session["USER"] = value; }
        }
        public static string ExamPrevId
        {
            get {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["ExamPrevId"] == null)
                {
                    return ""; 
                }
                return (string)HttpContext.Current.Session["ExamPrevId"];
            }
            set { HttpContext.Current.Session["ExamPrevId"] = value; }
        }
        public static string FileName
        {
            get
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["FileName"] == null)
                {
                    return "";
                }
                return (string)HttpContext.Current.Session["FileName"];
            }
            set { HttpContext.Current.Session["FileName"] = value; }
        }
        public static void RemoveSession(string SessionName)
        {
            HttpContext.Current.Session.Remove(SessionName);
        }
        public static void Logout()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}