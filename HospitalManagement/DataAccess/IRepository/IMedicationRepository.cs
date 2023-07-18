using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IMedicationRepository
    {
        Medication GetMedication(int medicationId);
        public List<Medication> GetAll();
    }
}
