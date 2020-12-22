using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class QuestionOptions
    {


        #region Public Properties

        public int OptionId { get; set; }
        public int SequenceNo { get; set; }
        public String Description { get; set; }
        public bool IsAnswer { get; set; }


        public QuestionMaster QuestionMaster
        {
            get
            {
                if (_questionmaster == null)
                {
                    _questionmaster = new QuestionMaster();
                }
                return _questionmaster;
            }
            set
            {
                _questionmaster = value;
            }
        }

        #endregion

        #region Private Properties

        public QuestionMaster _questionmaster;

        #endregion
    }
}
