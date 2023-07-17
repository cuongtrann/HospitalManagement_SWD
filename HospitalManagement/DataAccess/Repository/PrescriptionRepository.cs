using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        SWD392_DBContext context;

        public PrescriptionRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public void Create(Prescription prescription)
        {
            context.Prescriptions.Add(prescription);
            context.SaveChanges();
        }
    }
}
