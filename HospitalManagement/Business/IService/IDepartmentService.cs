using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IDepartmentService
    {
        List<Department> LoadAll();
        Department GetById(int id);
    }
}
