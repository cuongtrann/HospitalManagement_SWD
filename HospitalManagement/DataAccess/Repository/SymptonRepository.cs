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

        public Sympton GetSympton(int symptonId)
        {
            Sympton sympton = context.Symptons.FirstOrDefault(s => s.Id == symptonId);
            return sympton;
        }
    }
}
