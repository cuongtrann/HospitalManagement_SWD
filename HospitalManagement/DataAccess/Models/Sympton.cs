using System;
using System.Collections.Generic;

namespace HospitalManagement.DataAccess.Models
{
    public partial class Sympton
    {
        public Sympton()
        {
            MedicalExaminationCards = new HashSet<MedicalExaminationCard>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<MedicalExaminationCard> MedicalExaminationCards { get; set; }
    }
}
