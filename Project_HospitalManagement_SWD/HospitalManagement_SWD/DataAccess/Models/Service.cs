using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class Service
    {
        public Service()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            PatientExamTests = new HashSet<PatientExamTest>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<PatientExamTest> PatientExamTests { get; set; }
    }
}
