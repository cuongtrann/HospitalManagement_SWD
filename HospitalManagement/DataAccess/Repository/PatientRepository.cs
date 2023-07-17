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
            return context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public Patient GetByIdentifyNumber(string idNo)
        {
            return context.Patients
                .Include(p => p.Profile)
                .FirstOrDefault(p => p.Profile.IdNo.Equals(idNo));
        }
    }
}
