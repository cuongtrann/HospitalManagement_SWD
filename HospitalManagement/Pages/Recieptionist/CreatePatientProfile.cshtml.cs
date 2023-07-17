using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.Recieptionist
{
    public class CreatePatientProfileModel : PageModel
    {
        IPatientService patientService;

        public CreatePatientProfileModel(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public void OnGet()
        {

        }

        public string mess;
        public IActionResult OnPost(string Name, string Gender, DateTime DOB, string Address, string Phone, string IdNo, string Email)
        {
            Profile profile = new Profile();
            profile.Name = Name;
            profile.Gender = (Gender == "1" ? true : false);
            profile.Dob = DOB;
            profile.Address = Address;
            profile.Phone = Phone;
            profile.IdNo = IdNo;
            profile.Email = Email;
            Patient patient = new Patient();
            patient.Profile = profile;
            patientService.AddPatient(patient);
            mess = "Create Success!";
            return Page();
        }
    }
}
