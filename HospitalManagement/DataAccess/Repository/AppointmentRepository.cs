using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccess.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly SWD392_DBContext _context;

        public AppointmentRepository(SWD392_DBContext context)
        {
            _context = context;
        }

        public bool AddAppointment(Appointment appointment)
        {
            try
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Appointment> LoadAll()
        {
            return _context.Appointments.Include(x => x.Department).Include(x=>x.Patient).Include(x => x.Patient.Profile).ToList();
        }

        public bool updateStatus(int? appointmentId, int? appointmentStatus)
        {
            try
            {
                Appointment appointment = _context.Appointments.FirstOrDefault(x => x.Id == appointmentId);
                appointment.Status = appointmentStatus;
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
