using System;
using System.Collections.Generic;

namespace HospitalManagement.DataAccess.Models
{
    public partial class Invoice
    {
        public int MedicalExaminationCardId { get; set; }
        public DateTime? CreateAt { get; set; }
        public decimal? TotalCost { get; set; }
        public string? InsuranceInfo { get; set; }
        public bool? Status { get; set; }
        public string? PaymentMethod { get; set; }

        public virtual MedicalExaminationCard MedicalExaminationCard { get; set; } = null!;
    }
}
