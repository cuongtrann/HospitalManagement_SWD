using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class SymptonRepository : ISymptonRepository
    {
        SWD392_DBContext context;

        public SymptonRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public List<Sympton> GetAll()
        {
            return context.Symptons.ToList();
        }

        public Sympton GetById(int id)
        {
            return context.Symptons.FirstOrDefault(s => s.Id == id);    
        }
    }
}
