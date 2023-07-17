using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IProfileRepository
    {
        Profile GetProfile(int profileId);
    }
}
