using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccess.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly SWD392_DBContext _context;

        public DepartmentRepository(SWD392_DBContext context)
        {
            _context = context;
        }

        public Department GetById(int id)
        {
            return _context.Departments.Include(x => x.Assignments).Include(x => x.Appointments).FirstOrDefault(x => x.Id == id);
        }

        public List<Department> LoadAll()
        {
            return _context.Departments.Include(x => x.Assignments).Include(x => x.Appointments).ToList();
        }
    }
}
