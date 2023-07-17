using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IPatientRepository
    {
        public void AddPatient(Patient patient);
        public List<Patient> GetAll();
        Patient GetById(int patientId);
        void UpdatePatientProfile(Profile patientProfile);
        Profile GetProfileById(int profileId);
    }
}
