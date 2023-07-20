using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.Service
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public bool AddAppointment(Appointment appointment)
        {
            try
            {
                return _appointmentRepository.AddAppointment(appointment);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Appointment> LoadAll()
        {
            try
            {
                return _appointmentRepository.LoadAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool updateStatus(int? appointmentId, int? appointmentStatus)
        {
            try
            {
                if(appointmentId != null && appointmentStatus != null) {
                    return _appointmentRepository.updateStatus(appointmentId, appointmentStatus);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
