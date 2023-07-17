using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IDiseaseRepository
    {
        Disease GetDisease(int diseaseId);
    }
}
