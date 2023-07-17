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

        public Prescription GetPrescription(int prescriptionId)
        {
            Prescription prescription = context.Prescriptions.FirstOrDefault(p =>  p.Id == prescriptionId);
            return prescription;
        }
    }
}
