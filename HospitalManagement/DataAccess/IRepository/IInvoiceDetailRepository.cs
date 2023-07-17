using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IInvoiceDetailRepository
    {
        List<InvoiceDetail> GetInvoiceDetailsByExaminationCard(int examinationCardId);

    }
}
