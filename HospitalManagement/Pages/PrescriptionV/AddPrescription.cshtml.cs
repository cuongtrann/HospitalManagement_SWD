using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.Pages.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.PrescriptionV
{
    public class AddPrescriptionModel : PageModel
    {
        IPrescriptionRepository prescriptionService;
        IPatientRepository patientService;

        public AddPrescriptionModel(IPrescriptionRepository prescriptionService, IPatientRepository patientService)
        {
            this.prescriptionService = prescriptionService;
            this.patientService = patientService;
        }
        public List<Prescription> PrescriptionList;
        public List<Patient> PatientList;
        public List<User> UserList;
        public void OnGet()
        {
            PrescriptionList = prescriptionService.GetAll();
            PatientList = patientService.GetAll();
            UserList = prescriptionService.GetAllUser();
        }
    }
}
