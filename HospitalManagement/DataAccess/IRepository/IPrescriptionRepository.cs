using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IPrescriptionRepository
    {
        Prescription GetPrescription(int prescriptionId);
    }
}
