using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IDepartmentRepository
    {
        List<Department> LoadAll();

    }
}
