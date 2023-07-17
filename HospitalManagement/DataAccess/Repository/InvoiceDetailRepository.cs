using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {

        SWD392_DBContext context;

        public InvoiceDetailRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public List<InvoiceDetail> GetInvoiceDetailsByExaminationCard(int examinationCardId)
        {
            List<InvoiceDetail> invoiceDetails 
                = context.InvoiceDetails.Where(i => i.MedicalExaminationCardId == examinationCardId).ToList();
            return invoiceDetails;
        }
    }
}
