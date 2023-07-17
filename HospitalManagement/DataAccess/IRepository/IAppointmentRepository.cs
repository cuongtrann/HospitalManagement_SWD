using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IAppointmentRepository
    {
        List<Appointment> LoadAll();
    }
}
