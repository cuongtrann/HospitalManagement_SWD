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

        public void AddAll(List<InvoiceDetail> invoiceDetails)
        {
            invoiceDetails.ForEach(invoiceDetail =>
            {
                context.Add(invoiceDetail);
            });
            context.SaveChanges();
        }

        public void AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            context.Add(invoiceDetail);
            context.SaveChanges();
        }

        public List<InvoiceDetail> GetInvoiceDetailsByExaminationCard(int examinationCardId)
        {
            List<InvoiceDetail> invoiceDetails 
                = context.InvoiceDetails.Where(i => i.MedicalExaminationCardId == examinationCardId).ToList();
            return invoiceDetails;
        }
    }
}
