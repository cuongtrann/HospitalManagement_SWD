using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccess.Repository
{
    public class PatientRepository : IPatientRepository
    {
        SWD392_DBContext _context;

        public PatientRepository(SWD392_DBContext context)
        {
            _context = context;
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.Include(p => p.Profile).ToList();
        }

        public Patient GetById(int patientId)
        {
            return _context.Patients.Include(p => p.Profile).FirstOrDefault(p => p.Id == patientId);
        }

        public Profile GetProfileById(int profileId)
        {
            return _context.Profiles.FirstOrDefault(p => p.Id == profileId);
        }

        public void UpdatePatientProfile(Profile patientProfile)
        {
            _context.Profiles.Update(_context.Profiles.FirstOrDefault(p => p.Id == patientProfile.Id));
            _context.SaveChanges();
        }
    }
}
