using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IPrescriptionService
    {
        public void AddPrescription(Prescription prescription);
        List<Prescription> GetAll();
        Prescription GetById(int prescriptionId);
    }
}
