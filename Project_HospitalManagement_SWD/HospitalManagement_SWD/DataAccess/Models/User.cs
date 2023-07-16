using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Assignments = new HashSet<Assignment>();
            MedicalExaminationCards = new HashSet<MedicalExaminationCard>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? ProfileId { get; set; }
        public string? Specialization { get; set; }
        public string? Degree { get; set; }
        public int? Role { get; set; }

        public virtual Profile? Profile { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<MedicalExaminationCard> MedicalExaminationCards { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
