using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.Common
{
    public class ViewPatientProfileModel : PageModel
    {
        IPatientService patientService;

        public ViewPatientProfileModel(IPatientService patientService)
        {
            this.patientService = patientService;
        }
        public List<Patient> patientList;
        public void OnGet()
        {
            patientList = patientService.GetAll();
        }
    }
}
