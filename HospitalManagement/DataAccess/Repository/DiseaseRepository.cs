using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class DiseaseRepository : IDiseaseRepository
    {
        SWD392_DBContext context;

        public DiseaseRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public List<Disease> GetAll()
        {
            return context.Diseases.ToList();
        }

        public Disease GetById(int id)
        {
            return context.Diseases.FirstOrDefault(d => d.Id == id);
        }
    }
}
