using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IAppointmentRepository
    {
        bool AddAppointment(Appointment appointment);
        List<Appointment> LoadAll();
    }
}
