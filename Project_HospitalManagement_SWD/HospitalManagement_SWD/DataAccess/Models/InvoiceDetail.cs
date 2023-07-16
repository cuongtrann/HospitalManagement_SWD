using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class InvoiceDetail
    {
        public int Id { get; set; }
        public int? MedicalExaminationCardId { get; set; }
        public int? ServiceId { get; set; }

        public virtual MedicalExaminationCard? MedicalExaminationCard { get; set; }
        public virtual Service? Service { get; set; }
    }
}
