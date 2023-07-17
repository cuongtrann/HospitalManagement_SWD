using System;
using System.Collections.Generic;

namespace HospitalManagement.DataAccess.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            MedicalExaminationCards = new HashSet<MedicalExaminationCard>();
            PrescriptionDetails = new HashSet<PrescriptionDetail>();
        }

        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual ICollection<MedicalExaminationCard> MedicalExaminationCards { get; set; }
        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
