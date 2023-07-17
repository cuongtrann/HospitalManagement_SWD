using System;
using System.Collections.Generic;

namespace HospitalManagement.DataAccess.Models
{
    public partial class Disease
    {
        public Disease()
        {
            MedicalExaminationCards = new HashSet<MedicalExaminationCard>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Cause { get; set; }
        public string? Treatment { get; set; }
        public string? Prevention { get; set; }
        public string? Complication { get; set; }

        public virtual ICollection<MedicalExaminationCard> MedicalExaminationCards { get; set; }
    }
}
