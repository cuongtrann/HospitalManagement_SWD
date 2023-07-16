using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class MedicalRecord
    {
        public MedicalRecord()
        {
            MedicalExaminationCards = new HashSet<MedicalExaminationCard>();
        }

        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string? MedicalHistory { get; set; }
        public string? FamilyHistory { get; set; }

        public virtual Patient? Patient { get; set; }
        public virtual ICollection<MedicalExaminationCard> MedicalExaminationCards { get; set; }
    }
}
