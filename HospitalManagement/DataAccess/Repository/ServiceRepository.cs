using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        SWD392_DBContext context;

        public ServiceRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public List<Service> GetAllServices()
        {
            List<Service> services = context.Services.ToList();
            return services;
        }

        public Service GetService(int serviceId)
        {
            Service service = context.Services.FirstOrDefault(s => s.Id == serviceId);
            return service;
        }
    }
}
