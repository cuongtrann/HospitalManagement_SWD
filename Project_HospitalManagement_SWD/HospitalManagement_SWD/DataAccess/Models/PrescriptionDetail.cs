using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class PrescriptionDetail
    {
        public int Id { get; set; }
        public int? PrescriptionId { get; set; }
        public int? MedicationId { get; set; }
        public string? MedicationFrequency { get; set; }
        public string? MedicationQuantity { get; set; }

        public virtual Medication? Medication { get; set; }
        public virtual Prescription? Prescription { get; set; }
    }
}
