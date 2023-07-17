using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        SWD392_DBContext context;

        public ProfileRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public Profile GetProfile(int profileId)
        {
            Profile profile = context.Profiles.FirstOrDefault(p => p.Id == profileId);
            return profile;
        }
    }
}
