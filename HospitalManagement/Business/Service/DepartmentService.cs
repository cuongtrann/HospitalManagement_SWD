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

        public Department GetById(int id)
        {
            try
            {
                return _departmentRepository.GetById(id);
            }
            catch (Exception)
            {

                return null;
            }
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
