using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.PrescriptionV
{
    public class ViewPrescriptionModel : PageModel
    {

        public List<PrescriptionDetail> lst = new List<PrescriptionDetail>();
        public List<Prescription> lstPre = new List<Prescription>();
        public List<User> UserList = new List<User>();
        public List<Patient> PatientList = new List<Patient>();
        public List<Medication> MedicationList = new List<Medication>();
        public void OnGet(int id)
        {
            SWD392_DBContext context = new SWD392_DBContext();
            lst = context.PrescriptionDetails.Where(x => x.PrescriptionId == id).ToList();
            lstPre = context.Prescriptions.ToList();
            PatientList = context.Patients.ToList();
            UserList = context.Users.ToList();
            MedicationList = context.Medications.ToList();
        }

    }
}
