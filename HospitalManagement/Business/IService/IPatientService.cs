using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IPatientService
    {
        public void AddPatient(Patient patient);
        List<Patient> GetAll();
        Patient GetById(int patientId);
        void UpdatePatientProfile(Profile patientProfile);
        Profile GetProfileById(int profileId);
    }
}
