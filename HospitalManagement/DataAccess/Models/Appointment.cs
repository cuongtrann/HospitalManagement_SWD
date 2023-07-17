using System;
using System.Collections.Generic;

namespace HospitalManagement.DataAccess.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
