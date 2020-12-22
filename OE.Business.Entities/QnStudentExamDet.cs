using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class QnStudentExamDet
    {
        #region Public Properties
        public int ExamDetId { get; set; }

        public int SeqNo { get; set; }

        public int Marks { get; set; }

        public int ObtainedMarks { get; set; }

        public DateTime updatedOn { get; set; }

        public int TypeId { get; set; }

        public string Desc { get; set; }

        public bool isSelected { get; set; }

        public int OptionSeqNo { get; set; }

        public Student Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new Student();
                }
                return _student;
            }
            set
            {
                _student = value;
            }
        }
        public ExamResultDetail ExamResultDetail
        {
            get
            {
                if (_ResDet == null)
                {
                    _ResDet = new ExamResultDetail();
                }
                return _ResDet;
            }
            set
            {
                _ResDet = value;
            }
        }
        public QuestionMaster QuestionMaster
        {
            get 
            {
                if (_Question == null)
                {
                    _Question = new QuestionMaster();
                }
                return _Question;
            }
            set
            {
                _Question = value;
            }
        }
        #endregion

        #region Private Properties
        private Student _student;
        private ExamResultDetail _ResDet;
        private QuestionMaster _Question;
        #endregion
    }
}
