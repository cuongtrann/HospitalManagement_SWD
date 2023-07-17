using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IDiseaseRepository
    {
        List<Disease> GetAll();

        Disease GetById(int id);
    }
}
