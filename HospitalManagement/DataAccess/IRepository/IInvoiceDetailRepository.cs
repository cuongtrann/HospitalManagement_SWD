using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IInvoiceDetailRepository
    {
        List<InvoiceDetail> GetInvoiceDetailsByExaminationCard(int examinationCardId);

        void AddInvoiceDetail(InvoiceDetail invoiceDetail);

        void AddAll(List<InvoiceDetail> invoiceDetails);

    }
}
