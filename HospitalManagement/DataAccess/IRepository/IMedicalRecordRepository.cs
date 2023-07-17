using HospitalManagement.DataAccess.Models;
namespace HospitalManagement.DataAccess.IRepository
{
    public interface IMedicalRecordRepository
    {
        MedicalRecord GetByPatientId(int patientId);

        void Create(MedicalRecord record);  
    }
}
