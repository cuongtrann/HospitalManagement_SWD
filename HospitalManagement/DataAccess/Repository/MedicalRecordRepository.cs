using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        SWD392_DBContext context;

        public MedicalRecordRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public void Create(MedicalRecord record)
        {
            context.MedicalRecords.Add(record);
            context.SaveChanges();
        }

        public MedicalRecord GetByPatientId(int patientId)
        {
            return context.MedicalRecords.FirstOrDefault(m => m.PatientId == patientId);
        }

        public MedicalRecord GetMedicalRecord(int medicalRecordId)
        {
            MedicalRecord record = context.MedicalRecords.FirstOrDefault(m => m.Id == medicalRecordId);
            return record;

        }
    }
}
