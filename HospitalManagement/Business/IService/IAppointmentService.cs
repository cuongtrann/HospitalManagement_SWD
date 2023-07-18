using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IAppointmentService
    {
        List<Appointment> LoadAll();
        bool AddAppointment(Appointment appointment);
        bool updateStatus(int? appointmentId, int? appointmentStatus);
    }
}
