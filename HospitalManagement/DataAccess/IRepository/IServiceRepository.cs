using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IServiceRepository
    {
        Service GetService(int serviceId);

        List<Service> GetAllServices();
    }
}
