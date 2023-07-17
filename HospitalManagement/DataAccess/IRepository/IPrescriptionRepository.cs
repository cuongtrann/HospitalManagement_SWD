using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IPrescriptionRepository
    {
        void Create(Prescription prescription);

        Prescription GetById(int id);
        Prescription GetByIdentifyNumber(string idNo);
        public List<Prescription> GetAll();
        public List<User> GetAllUser();

    }
}
