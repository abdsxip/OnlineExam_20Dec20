using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class ExamResultDetail
    {
        public int ExmResultDetailId { get; set; }
        public DateTime ExamDate { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int AttemptNo { get; set; }
        public bool IsDispatched { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool isResultMailSent { get; set; }
        public string FileName { get; set; }
        public bool IsAttended { get; set; }
        public int Marks { get; set; }
        public int status { get; set; }
        public Semester Semester
        {
            get
            {
                if (_semester == null)
                {
                    _semester = new Semester();
                }
                return _semester;
            }
            set
            {
                _semester = value;
            }
        }

        #region PrivateProperties

        private Semester _semester;

        #endregion

    }
}
