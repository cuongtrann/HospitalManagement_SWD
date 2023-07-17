using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Prescription> GetAll()
        {
            return context.Prescriptions.ToList();
        }

        public List<User> GetAllUser()
        {
            return context.Users.ToList();
        }

        public Prescription GetById(int id)
        {
            return context.Prescriptions.Include(p => p.Id).FirstOrDefault(p => p.Id == id);
        }

        public Prescription GetByIdentifyNumber(string idNo)
        {
            throw new NotImplementedException();

        }
    }
}
