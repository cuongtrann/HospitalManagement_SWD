using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class PrescriptionDetailRepository : IPrescriptionDetailRepository
    {
        SWD392_DBContext context;

        public PrescriptionDetailRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public List<PrescriptionDetail> GetAllByPrescriptionId(int prescriptionDetailId)
        {
            return context.PrescriptionDetails.Where(p => p.PrescriptionId == prescriptionDetailId).ToList();
        }

        public PrescriptionDetail GetPrescriptionDetail(int prescriptionDetailId)
        {
            PrescriptionDetail prescriptionDetail = context.PrescriptionDetails.FirstOrDefault(p =>  p.Id == prescriptionDetailId);
            return prescriptionDetail;
        }
    }
}
