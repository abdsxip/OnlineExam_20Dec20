using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class QuestionMaster
    {


        #region

        public int Id { get; set; }
        public string Description { get; set; }
        public char Complexity { get; set; }
        public int Marks { get; set; }
        public bool IsActive { get; set; }
        public bool IsNegativeMark { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string FileName { get; set; }
        public int typeId { get; set; }
        public string ImgFileName { get; set; }   //added in Nov 2020 for imagetype question

        public List<QuestionOptions> LstQuestionOptions
        {
            get
            {
                if (_lstQtnOptions == null)
                {
                    _lstQtnOptions = new List<QuestionOptions>();
                }
                return _lstQtnOptions;
            }
            set
            {
                _lstQtnOptions = value;
            }
        }

        //public QuestionType QuestionType
        //{
        //    get
        //    {
        //        if (_qtnType == null)
        //        {
        //            _qtnType = new QuestionType();
        //        }
        //        return _qtnType;
        //    }
        //    set
        //    {
        //        _qtnType = value;
        //    }
        //}
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

        //public List<QuestDynamic> LstQuestionDynamic
        //{
        //    get
        //    {
        //        if (_lstQtnDynamic == null)
        //        {
        //            _lstQtnDynamic = new List<QuestDynamic>();
        //        }
        //        return _lstQtnDynamic;
        //    }
        //    set
        //    {
        //        _lstQtnDynamic = value;
        //    }
        //}

        #endregion

        #region Private Variables
        //private QuestionType _qtnType;
        private Product _product;
        private Semester _semester;
        private List<QuestionOptions> _lstQtnOptions;
        //private List<QuestDynamic> _lstQtnDynamic;
        #endregion

    }
}
