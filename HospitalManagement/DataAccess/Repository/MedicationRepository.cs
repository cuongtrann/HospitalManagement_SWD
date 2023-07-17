using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class MedicationRepository : IMedicationRepository
    {
        SWD392_DBContext context;

        public MedicationRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public Medication GetMedication(int medicationId)
        {
            Medication medication = context.Medications.FirstOrDefault(m =>  m.Id == medicationId);
            return medication;
        }
    }
}
