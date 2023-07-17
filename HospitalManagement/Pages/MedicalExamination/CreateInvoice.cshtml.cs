using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.MedicalExamination
{
    public class CreateInvoiceModel : PageModel
    {

        public List<DataAccess.Models.Service> Services { get; set; }

        IServiceRepository serviceRepository;
        IInvoiceService invoiceService;

        public CreateInvoiceModel(IServiceRepository serviceRepository, IInvoiceService invoiceService)
        {
            this.serviceRepository = serviceRepository;
            this.invoiceService = invoiceService;
        }

        public void OnGet()
        {
            Services = serviceRepository.GetAllServices();
        }

        public IActionResult OnPost(int medicalcardid)
        {
            List<DataAccess.Models.Service> services = new List<DataAccess.Models.Service>();
            var selectedServices = Request.Form["services"];
            foreach (var value in selectedServices)
            {
                DataAccess.Models.Service service = serviceRepository.GetService(Int32.Parse(value));
                services.Add(service);
            }
            invoiceService.CreateInvoice(medicalcardid, services);

            return RedirectToPage();
        }
    }
}
