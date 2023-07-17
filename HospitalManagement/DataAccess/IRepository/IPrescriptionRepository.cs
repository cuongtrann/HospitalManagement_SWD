using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IPrescriptionRepository
    {
        void Create(Prescription prescription);
    }
}
