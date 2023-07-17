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

        public Disease GetDisease(int diseaseId)
        {
            Disease disease = context.Diseases.FirstOrDefault(d => d.Id == diseaseId);
            return disease;
        }
    }
}
