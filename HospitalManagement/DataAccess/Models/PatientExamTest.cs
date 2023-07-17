using System;
using System.Collections.Generic;

namespace HospitalManagement.DataAccess.Models
{
    public partial class PatientExamTest
    {
        public int Id { get; set; }
        public int? MedicalExaminationCardId { get; set; }
        public int? ServiceId { get; set; }
        public DateTime? Date { get; set; }

        public virtual MedicalExaminationCard? MedicalExaminationCard { get; set; }
        public virtual Service? Service { get; set; }
    }
}
