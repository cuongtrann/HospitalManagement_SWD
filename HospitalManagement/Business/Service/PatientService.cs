using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.DataAccess.Repository;

namespace HospitalManagement.Business.Service
{
    public class PatientService : IPatientService
    {
        SWD392_DBContext _context;
        IPatientRepository repo;
        public PatientService(SWD392_DBContext context)
        {
            _context = context;
            repo = new PatientRepository(_context);
        }

        public void AddPatient(Patient patient)
        {
            repo.AddPatient(patient);
        }

        public List<Patient> GetAll()
        {
            return repo.GetAll();
        }

        public Patient GetById(int patientId)
        {
            return repo.GetById(patientId);
        }

        public Profile GetProfileById(int profileId)
        {
            return repo.GetProfileById(profileId);
        }

        public void UpdatePatientProfile(Profile patientProfile)
        {
            repo.UpdatePatientProfile(patientProfile);
        }
    }
}
