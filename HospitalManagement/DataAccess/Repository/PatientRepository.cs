using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccess.Repository
{
    public class PatientRepository : IPatientRepository
    {
        SWD392_DBContext context;

        public PatientRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public Patient GetById(int id)
        {
            return context.Patients.Include(p => p.Profile).FirstOrDefault(p => p.Id == id);
        }

        public Patient GetByIdentifyNumber(string idNo)
        {
            return context.Patients
                .Include(p => p.Profile)
                .FirstOrDefault(p => p.Profile.IdNo.Equals(idNo));
        }
        public void AddPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
        }

        public List<Patient> GetAll()
        {
            return context.Patients.Include(p => p.Profile).ToList();
        }

        public Profile GetProfileById(int profileId)
        {
            return context.Profiles.FirstOrDefault(p => p.Id == profileId);
        }

        public void UpdatePatientProfile(Profile patientProfile)
        {
            context.Profiles.Update(context.Profiles.FirstOrDefault(p => p.Id == patientProfile.Id));
            context.SaveChanges();
        }
    }
}
