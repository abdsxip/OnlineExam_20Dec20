using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
  public  class Region
    {
      
        public int RegionId { get; set; }      
        public string RegionName { get; set; }      
        public bool RegionIsHo { get; set; }
    }
}
