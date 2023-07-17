using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly SWD392_DBContext _context;

        public AppointmentRepository(SWD392_DBContext context)
        {
            _context = context;
        }

        public List<Appointment> LoadAll()
        {
            throw new NotImplementedException();
        }
    }
}
