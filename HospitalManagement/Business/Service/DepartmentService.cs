using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.Service
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository) {
            _departmentRepository = departmentRepository;
        }

        public List<Department> LoadAll()
        {
            try
            {
                return _departmentRepository.LoadAll();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
