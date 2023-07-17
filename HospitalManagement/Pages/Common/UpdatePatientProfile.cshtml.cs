using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.Common
{
    public class UpdatePatientProfileModel : PageModel
    {
        IPatientService patientService;

        public UpdatePatientProfileModel(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public Profile patientProfile;
        public IActionResult OnGet(int patientId)
        {
            if (patientId == null)
                return Redirect("");
            Patient p = patientService.GetById(patientId);
            if (p == null)
                return Redirect("");
            patientProfile = p.Profile;
            return Page();
        }
        public string mess;
        public IActionResult OnPost(int profileId, string Name, string Gender, DateTime DOB, string Address, string Phone, string IdNo, string Email)
        {
            patientProfile = patientService.GetProfileById(profileId);
            patientProfile.Name = Name;
            patientProfile.Gender = (Gender == "1" ? true : false);
            patientProfile.Dob = DOB;
            patientProfile.Address = Address;
            patientProfile.Phone = Phone;
            patientProfile.IdNo = IdNo;
            patientProfile.Email = Email;
            patientService.UpdatePatientProfile(patientProfile);
            mess = "Update Success!";
            return Page();
        }
    }
}
