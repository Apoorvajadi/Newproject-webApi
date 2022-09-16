using System;
using System.Collections.Generic;

#nullable disable

namespace Newproject.Context
{
    public partial class TblDoctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public decimal? Salary { get; set; }
    }
}
