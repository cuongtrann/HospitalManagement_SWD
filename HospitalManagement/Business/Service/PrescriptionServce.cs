using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.DataAccess.Repository;

namespace HospitalManagement.Business.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        SWD392_DBContext _context;
        IPrescriptionRepository repo;
        public PrescriptionService(SWD392_DBContext context)
        {
            _context = context;
            repo = new PrescriptionRepository(_context);
        }
        public void AddPrescription(Prescription prescription)
        {
            repo.Create(prescription);
        }

        public List<Prescription> GetAll()
        {
            return repo.GetAll();
        }

        public Prescription GetById(int prescriptionId)
        {
            return repo.GetById(prescriptionId);
        }
    }
}
