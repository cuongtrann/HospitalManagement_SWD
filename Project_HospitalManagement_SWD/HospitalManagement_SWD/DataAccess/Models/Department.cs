using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class Department
    {
        public Department()
        {
            Appointments = new HashSet<Appointment>();
            Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
