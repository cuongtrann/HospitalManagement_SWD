using System;
using System.Collections.Generic;

namespace HospitalManagement.DataAccess.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Patients = new HashSet<Patient>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? IdNo { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
