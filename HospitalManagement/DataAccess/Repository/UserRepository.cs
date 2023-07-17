using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        SWD392_DBContext context;

        public UserRepository(SWD392_DBContext context)
        {
            this.context = context;
        }
        
        public User GetUser(int userId)
        {
            User user = context.Users.FirstOrDefault(u => u.Id == userId);
            return user;
        }
    }
}
