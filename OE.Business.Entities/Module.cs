using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class Module
    {
        #region Properties

        public int UniqueId { get; set; }

        public string Name { get; set; }

        public bool IsFranchShare { get; set; }


        public bool STApplicable { get; set; }


        public DateTime ValidFrom { get; set; }


        public DateTime ValidTo { get; set; }

        public string Description { get; set; }


        public int BufferDays { get; set; }


        public DateTime UpdatedOn { get; set; }


        public bool IsActive { get; set; }


        public bool IsModule { get; set; }


        public int Duration { get; set; }

        public int TotalRecordCount { get; set; }

        #endregion
    }
}



       

