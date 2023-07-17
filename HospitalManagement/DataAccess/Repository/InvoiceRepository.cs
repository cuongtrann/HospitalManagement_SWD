using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        SWD392_DBContext context;

        public InvoiceRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public void CreateInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
        }

        public Invoice GetInvoice(int examinationCardId)
        {
            Invoice invoice = context.Invoices.FirstOrDefault(i => i.MedicalExaminationCardId == examinationCardId);
            return invoice;
        }

        
    }
}
