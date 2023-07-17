using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IUserRepository
    {
        User GetUser(int userId);
    }
}
