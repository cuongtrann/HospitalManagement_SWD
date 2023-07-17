using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IInvoiceService
    {
        Invoice CreateInvoice(int examinationCardId, List<DataAccess.Models.Service> services);

    }
}
