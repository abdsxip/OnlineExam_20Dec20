using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class QnStudExamResult
    {
        #region Public Properties
        public int ExResId { get; set; }

        public int AnswerNo { get; set; }

        public QnStudentExamDet QnStudentExamDet
        {
            get
            {
                if (_ExamDet == null)
                {
                    _ExamDet = new QnStudentExamDet();
                }
                return _ExamDet;
            }
            set
            {
                _ExamDet = value;
            }
        }
        #endregion

        #region Private Properties
        private QnStudentExamDet _ExamDet;
        #endregion
    }
}
