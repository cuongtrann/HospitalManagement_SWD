using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IMedicationService
    {
        List<Medication> GetAllMedications();
        Medication GetMedicationById(int id);
        void CreateMedication(Medication medication);
        void UpdateMedication(Medication medication);
    }
}
