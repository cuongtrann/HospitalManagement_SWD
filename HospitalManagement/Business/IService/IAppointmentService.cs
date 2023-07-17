using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IAppointmentService
    {
        List<Appointment> LoadAll();
    }
}
