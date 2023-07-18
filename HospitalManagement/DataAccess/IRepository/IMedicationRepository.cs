using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IMedicationRepository
    {
        List<Medication> GetMedication();
        void CreateMedication(Medication medication);
        void UpdateMedication(Medication medication);
    }
}
