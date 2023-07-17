using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IInvoiceService
    {
        void CreateInvoice(int examinationCardId);

    }
}
