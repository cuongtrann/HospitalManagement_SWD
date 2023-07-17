using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface ISymptonRepository
    {
        List<Sympton> GetAll();

        Sympton GetById(int id);
    }
}
