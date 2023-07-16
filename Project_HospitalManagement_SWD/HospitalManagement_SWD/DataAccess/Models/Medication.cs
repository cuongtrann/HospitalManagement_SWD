using System;
using System.Collections.Generic;

namespace HospitalManagement_SWD.DataAccess.Models
{
    public partial class Medication
    {
        public Medication()
        {
            PrescriptionDetails = new HashSet<PrescriptionDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? DosageForm { get; set; }
        public string? Interaction { get; set; }
        public string? StorageCondition { get; set; }
        public string? SideEffect { get; set; }
        public string? Contraindication { get; set; }

        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
