using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class MedicalExaminationCard
    {
        public MedicalExaminationCard()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            PatientExamTests = new HashSet<PatientExamTest>();
        }

        public int Id { get; set; }
        public int? MedicalRecordId { get; set; }
        public int? DoctorId { get; set; }
        public int? DiseaseId { get; set; }
        public int? SymptonId { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual Disease? Disease { get; set; }
        public virtual User? Doctor { get; set; }
        public virtual Invoice IdNavigation { get; set; } = null!;
        public virtual MedicalRecord? MedicalRecord { get; set; }
        public virtual Prescription? Prescription { get; set; }
        public virtual Sympton? Sympton { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<PatientExamTest> PatientExamTests { get; set; }
    }
}
