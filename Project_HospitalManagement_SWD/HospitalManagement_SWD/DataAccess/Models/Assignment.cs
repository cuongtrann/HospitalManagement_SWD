using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class Assignment
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public virtual Department? Department { get; set; }
        public virtual User? Doctor { get; set; }
    }
}
