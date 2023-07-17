using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(int examinationCardId);

        void CreateInvoice(Invoice invoice);

    }
}
