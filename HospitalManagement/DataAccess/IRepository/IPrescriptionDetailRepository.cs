using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IPrescriptionDetailRepository
    {
        PrescriptionDetail GetPrescriptionDetail(int prescriptionDetailId);

        List<PrescriptionDetail> GetAllByPrescriptionId(int prescriptionDetailId);
    }
}
