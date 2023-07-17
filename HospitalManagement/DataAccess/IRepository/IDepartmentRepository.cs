using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IDepartmentRepository
    {
        Department GetById(int id);
        List<Department> LoadAll();

    }
}
