using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IPatientRepository
    {
        Patient GetById(int id);
        Patient GetByIdentifyNumber(string idNo);

    }
}
