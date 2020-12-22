using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Business.Entities
{
    [Serializable]
    public class Semester
    {
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
    }
}
