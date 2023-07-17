using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface ISymptonRepository
    {
        Sympton GetSympton(int symptonId);
    }
}
