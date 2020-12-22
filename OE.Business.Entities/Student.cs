using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OE.Business.Entities
{    
    [Serializable]
    public class Student
    {
        #region properties
     
        public int StudentId { get; set; }
        public bool isModExam { get; set; }
     
        public string StudentRegNo { get; set; }
        public int TotalRecordCount { get; set; }

        public Centre StudentCentre
        {
            get
            {
                if (_studentCentre == null)
                {
                    _studentCentre = new Centre();
                }
                return _studentCentre;
            }
            set
            {
                _studentCentre = value;
            }
        }
       
        // [XmlIgnore]
        public Product Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new Product();
                }
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        public ExamResultDetail ExamResultDetail
        {
            get
            {
                if (_exmresultDtl == null)
                {
                    _exmresultDtl = new ExamResultDetail();
                }
                return _exmresultDtl;
            }
            set
            {
                _exmresultDtl = value;
            }
        }
      

       
        public string StudentName { get; set; }

      
        public DateTime StudentEnrolledOn { get; set; }

       
        public string StudentAddress { get; set; }
      
        public string Courses { get; set; }

    
        public string StudentPhone { get; set; }

        public string StudentMobile { get; set; }

        public string StudentEmailId { get; set; }

        public string StudentGender { get; set; }

        public DateTime StudentDob { get; set; }
  
        public int ExSchId { get; set; }

      //  public string StudentCollege { get; set; }

      //  public decimal StudentMarksPerc { get; set; }

        //public string StudentOrgName { get; set; }

        //public byte[] StudentPhoto { get; set; }
 
      //  public bool studentAdmissionCancelled { get; set; }

      //  public DateTime StudentUpdatedOn { get; set; }

     //   public string StudentUpdatedBy { get; set; }

     
        public bool StudentIsActive { get; set; }

        public String StudentIds { get; set; }


     //   public string AttendStatus { get; set; }

     //   public string StudentRemarks { get; set; }

        public bool isExpired { get; set; }

        public bool isStatus { get; set; }
        public int MaxMarks { get; set; }
        public int PassMarks { get; set; }
        public int Duration { get; set; }
        public DateTime ValidTill { get; set; }

        #endregion

        #region Private Variables
        private Centre _studentCentre;
        private Product _product;
        private ExamResultDetail _exmresultDtl;
      
        #endregion
    }
}
